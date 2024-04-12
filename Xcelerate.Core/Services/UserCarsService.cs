namespace Xcelerate.Core.Services
{
	using Microsoft.AspNetCore.Hosting;
	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata;
	using System.Linq.Expressions;
	using Contracts;
	using Models.Ad;
	using Models.UserCars;
	using Infrastructure.Data;
	using Infrastructure.Data.Enums;
	using Infrastructure.Data.Models;
	using static Common.EntityValidation;
	using Xcelerate.Core.Models.Sorting;

	public class UserCarsService : IUserCarsService
	{
		private readonly XcelerateContext _dbContext;
		private readonly IWebHostEnvironment _webHostEnvironment;


		public UserCarsService(XcelerateContext context, IWebHostEnvironment webHostEnvironment)
		{
			_dbContext = context;
			_webHostEnvironment = webHostEnvironment;
		}

		public async Task<AdInformationViewModel> GetCarsInformationAsync(int? carId)
		{
			AdInformationViewModel? car = await _dbContext.Cars
				.Where(c => c.CarId == carId && c.IsForSale == false)
				.Select(car => new AdInformationViewModel
				{
					ImageUrls = car.Images.Select(image => image.ImageUrl).ToList(),
					Brand = car.Brand,
					Model = car.Model,
					Year = car.Year,
					CarId = car.CarId,
					Engine = car.Engine.Model,
					HorsePower = car.Engine.Horsepower,
					Condition = car.Condition,
					EuroStandard = car.EuroStandard,
					FuelType = car.Engine.FuelType,
					Colour = car.Colour,
					Transmission = car.Transmission,
					DriveTrain = car.DriveTrain,
					Weight = car.Weight,
					Mileage = car.Mileage,
					Price = car.Price,
					BodyType = car.BodyType,

					FirstName = car.User.FirstName,
					LastName = car.User.LastName,
					Manufacturer = car.Manufacturer.Name,
					Address = new AddressViewModel
					{
						CountryName = car.Address.CountryName,
						TownName = car.Address.TownName,
						StreetName = car.Address.StreetName,
					}
				}).FirstOrDefaultAsync();

			if (car == null)
			{
				return null;
			}
			return car;
		}

		public async Task<bool> IdExists<TEntity>(int id) where TEntity : class
		{
			DbSet<TEntity> dbSet = _dbContext.Set<TEntity>();

			IProperty? primaryKeyProperty = _dbContext.Model.FindEntityType(typeof(TEntity))
													 .FindPrimaryKey()
													 .Properties
													 .FirstOrDefault();

			if (primaryKeyProperty == null)
			{
				throw new InvalidOperationException($"Entity type {typeof(TEntity).Name} does not have a primary key property.");
			}

			ParameterExpression parameter = Expression.Parameter(typeof(TEntity), "e");
			MemberExpression propertyAccess = Expression.Property(parameter, primaryKeyProperty.PropertyInfo);
			BinaryExpression equality = Expression.Equal(propertyAccess, Expression.Constant(id));
			Expression<Func<TEntity, bool>> lambda = Expression.Lambda<Func<TEntity, bool>>(equality, parameter);

			return await dbSet.AnyAsync(lambda);
		}

		public Task<int> GetUserCarsCountAsync(AdInformationViewModel adPreview, string userId)
		{
			IQueryable<Car> cars = _dbContext.Cars.Where(u => u.UserId == Guid.Parse(userId) && u.IsForSale == false).AsQueryable();

			cars = FilterCars(adPreview, cars);

			return cars.CountAsync();
		}

		public async Task<IEnumerable<AdPreviewViewModel>> GetUserCarsPreviewAsync(Guid userId, AdInformationViewModel adInformation)
		{
			IQueryable<Car> userCars = _dbContext.Cars
				.Include(a => a.User)
				.Where(a => a.IsForSale == false && a.UserId == userId)
				.AsQueryable();

			userCars = FilterCars(adInformation, userCars);

			IEnumerable<AdPreviewViewModel> cars = await userCars
				.Skip((adInformation.Pager.CurrentPage - 1) * adInformation.Pager.PageSize)
				.Take(adInformation.Pager.PageSize)
				.AsNoTracking()
				.Select(car => new AdPreviewViewModel
				{
					CarId = car.CarId,
					ImageUrls = car.Images.Select(car => car.ImageUrl).ToList(),
					Brand = car.Brand,
					Model = car.Model,
					Year = car.Year,
					Engine = car.Engine.Model,
					HorsePower = car.Engine.Horsepower,
					Condition = car.Condition,
					EuroStandard = car.EuroStandard,
					FuelType = car.Engine.FuelType,
					Price = car.Price,
					FirstName = car.User.FirstName,
					LastName = car.User.LastName,
				}).ToListAsync();

			return cars;
		}

		public async Task<UserCarsSellViewModel> GetSellInformationForCarAsync(int? carId)
		{
			var car = await _dbContext.Cars
				.Include(c => c.Engine)
				.Include(c => c.Manufacturer)
				.Include(c => c.Address)
				.Include(c => c.Ad)
				.Include(c => c.CarAccessories)
					.ThenInclude(ca => ca.Accessory)
				.Include(c => c.Images)
				.FirstOrDefaultAsync(c => c.CarId == carId);

			if (car == null)
			{
				throw new ArgumentException("Car not found!");
			}

			UserCarsSellViewModel adViewModel = new UserCarsSellViewModel
			{
				CarId = car.CarId,
				ImageUrls = car.Images.Select(image => image.ImageUrl).ToList(),
				Accessories = car.CarAccessories.Select(accessory => new AccessoryViewModel
				{
					AccessoryId = accessory.AccessoryId,
					Name = accessory.Accessory.Name
				}).ToList(),
				Brand = car.Brand,
				Model = car.Model,
				Year = car.Year,
				Engine = car.Engine.Model,
				HorsePower = car.Engine.Horsepower,
				Condition = car.Condition,
				EuroStandard = car.EuroStandard,
				FuelType = car.Engine.FuelType,
				Colour = car.Colour,
				Transmission = car.Transmission,
				DriveTrain = car.DriveTrain,
				Weight = car.Weight,
				Mileage = car.Mileage,
				Price = car.Price,
				BodyType = car.BodyType,
				Manufacturer = car.Manufacturer.Name,
				Address = new AddressViewModel
				{
					CountryName = car.Address.CountryName,
					TownName = car.Address.TownName,
					StreetName = car.Address.StreetName,
				},
				CarDescription = car?.Ad?.CarDescription,
			};

			List<AccessoryViewModel> accessories = await _dbContext.Accessories
				.Select(accessory => new AccessoryViewModel
				{
					AccessoryId = accessory.AccessoryId,
					Name = accessory.Name
				})
				.ToListAsync();

			adViewModel.Accessories = accessories;

			return adViewModel;
		}

		public async Task<bool> SellCarAsync(UserCarsSellViewModel adViewModel, string userId)
		{
			try
			{
				var car = await _dbContext.Cars
					.Include(c => c.Engine)
					.Include(c => c.Manufacturer)
					.Include(c => c.Address)
					.Include(c => c.Ad)
					.Include(c => c.CarAccessories)
					.Include(c => c.Images)
					.FirstOrDefaultAsync(c => c.CarId == adViewModel.CarId);

				if (car == null)
				{
					throw new ArgumentException("Car not found!");
				}

				if (car.Ad == null)
				{
					car.Ad = new Ad
					{
						UserId = Guid.Parse(userId),
						CarDescription = adViewModel.CarDescription,
						CreatedOn = adViewModel.CreatedOn.ToString(AdEntity.CreatedOnDateFormat)
					};
				}

				car.Brand = adViewModel.Brand;
				car.Model = adViewModel.Model;
				car.Year = adViewModel.Year;
				car.Engine.Model = adViewModel.Engine;
				car.Condition = adViewModel.Condition;
				car.EuroStandard = adViewModel.EuroStandard;
				car.Engine.FuelType = adViewModel.FuelType;
				car.Colour = adViewModel.Colour;
				car.Transmission = adViewModel.Transmission;
				car.DriveTrain = adViewModel.DriveTrain;
				car.Weight = adViewModel.Weight;
				car.Mileage = adViewModel.Mileage;
				car.Price = adViewModel.Price;
				car.BodyType = adViewModel.BodyType;
				car.Manufacturer.Name = adViewModel.Manufacturer;
				car.Ad.CarDescription = adViewModel.CarDescription;
				car.Address.CountryName = adViewModel.Address.CountryName;
				car.Address.TownName = adViewModel.Address.TownName;
				car.Address.StreetName = adViewModel.Address.StreetName;
				car.Ad.CreatedOn = DateTime.Now.ToString(AdEntity.CreatedOnDateFormat);
				car.IsForSale = true;

				var selectedAccessories = adViewModel.SelectedCheckBoxId;
				var existingAccessories = car.CarAccessories.Select(ca => ca.AccessoryId).ToList();

				var accessoriesToAdd = selectedAccessories.Except(existingAccessories);
				var accessoriesToRemove = existingAccessories.Except(selectedAccessories);

				foreach (var accessoryId in accessoriesToAdd)
				{
					await _dbContext.CarAccessories.AddAsync(new CarAccessory()
					{
						CarId = car.CarId,
						AccessoryId = accessoryId
					});
				}

				foreach (var accessoryId in accessoriesToRemove)
				{
					var accessoryToRemove = car.CarAccessories.FirstOrDefault(ca => ca.AccessoryId == accessoryId);
					if (accessoryToRemove != null)
					{
						_dbContext.CarAccessories.Remove(accessoryToRemove);
					}
				}

				foreach (var oldImage in car.Images.ToList())
				{
					var oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, "Images", "Ad", oldImage.ImageUrl);

					if (System.IO.File.Exists(oldImagePath))
					{
						using (var stream = new FileStream(oldImagePath, FileMode.Open, FileAccess.ReadWrite))
						{
						}
						System.IO.File.Delete(oldImagePath);
					}

					_dbContext.Images.Remove(oldImage);
				}

				var adImagesDirectory = Path.Combine(_webHostEnvironment.WebRootPath, "Images", "Ad");
				foreach (var image in adViewModel.UploadedImages)
				{
					if (image != null && image.Length > 0)
					{
						var uniqueFileName = Guid.NewGuid().ToString() + "_" + image.FileName;
						var filePath = Path.Combine(adImagesDirectory, uniqueFileName);
						using (var stream = new FileStream(filePath, FileMode.Create))
						{
							await image.CopyToAsync(stream);
						}

						Image imageToCreate = new Image()
						{
							CarId = car.CarId,
							ImageUrl = uniqueFileName
						};
						await _dbContext.Images.AddAsync(imageToCreate);
					}
				}

				_dbContext.Ads.Add(car.Ad);

				await _dbContext.SaveChangesAsync();

				return true;

			}
			catch (Exception)
			{
				throw new ArgumentException("An error occurred while saving the ad.");
			}
		}

		public async Task<Car> GetCarByIdAsync(int carId)
		{
			var carToFind = await _dbContext.Cars
				.FirstOrDefaultAsync(c => c.CarId == carId);

			if (carToFind == null)
			{
				throw new ArgumentException("Car not found!");
			}

			carToFind.IsForSale = false;

			return carToFind;
		}

		public async Task<bool> CancelSellAdAsync(Car car, int adId)
		{
			var adToRemove = await _dbContext.Ads.FirstOrDefaultAsync(a => a.AdId == adId);

			if (adToRemove != null)
			{
				// Remove associated reviews
				var reviewsToRemove = _dbContext.Reviews.Where(r => r.AdId == adToRemove.AdId);
				_dbContext.Reviews.RemoveRange(reviewsToRemove);

				// Now remove the ad
				_dbContext.Ads.Remove(adToRemove);

				// Update the car
				_dbContext.Cars.Update(car);

				await _dbContext.SaveChangesAsync();
				return true;
			}
			else
			{
				// Handle the case where the associated ad is not found
				return false;
			}
		}

		public async Task<bool> DeleteCarAdAsync(int? carId)
		{
			var car = await _dbContext.Cars
				.Include(c => c.Images)
				.Include(c => c.CarAccessories)
					.ThenInclude(ca => ca.Accessory)
					.Include(m => m.Manufacturer)
					.Include(a => a.Address)
					.Include(e => e.Engine)
				.FirstOrDefaultAsync(c => c.CarId == carId);

			if (car == null)
			{
				throw new ArgumentException("Car not found!");
			}

			try
			{
				foreach (var image in car.Images)
				{
					var imagePath = Path.Combine(_webHostEnvironment.WebRootPath, "Images", "Ad", image.ImageUrl);

					if (System.IO.File.Exists(imagePath))
					{
						try
						{
							using (var stream = new FileStream(imagePath, FileMode.Open, FileAccess.ReadWrite))
							{
								// Close the file stream before deletion
								stream.Close();
							}
							// Attempt to delete the file
							System.IO.File.Delete(imagePath);
						}
						catch (IOException)
						{
							throw new IOException("An error occurred while deleting the ad.");
						}
					}

					_dbContext.Images.Remove(image);
				}

				// Remove associated car accessories
				if (car.CarAccessories != null)
				{
					_dbContext.CarAccessories.RemoveRange(car.CarAccessories);
				}

				// Remove associated address
				if (car.Address != null)
				{
					_dbContext.Addresses.Remove(car.Address);
				}

				// Remove associated manufacturer
				if (car.Manufacturer != null)
				{
					_dbContext.Manufacturers.Remove(car.Manufacturer);
				}

				// Remove associated engine
				if (car.Engine != null)
				{
					_dbContext.Engines.Remove(car.Engine);
				}

				// Remove car entity
				_dbContext.Cars.Remove(car);

				await _dbContext.SaveChangesAsync();

				return true;
			}
			catch (Exception)
			{
				throw new ArgumentException("Delete failed!");
			}
		}
		public IQueryable<Car> FilterCars(AdInformationViewModel adViewModel, IQueryable<Car> cars)
		{
			if (adViewModel.Sorting == SortingEnums.PriceAscending)
			{
				cars = cars.OrderBy(c => c.Price);
			}
			else if (adViewModel.Sorting == SortingEnums.PriceDescending)
			{
				cars = cars.OrderByDescending(c => c.Price);
			}
			else if (adViewModel.Sorting == SortingEnums.YearAscending)
			{
				cars = cars.OrderBy(c => c.Year);
			}
			else if (adViewModel.Sorting == SortingEnums.YearDescending)
			{
				cars = cars.OrderByDescending(c => c.Year);
			}


			if (adViewModel.Brand != BrandsEnum.Default && adViewModel.Brand.HasValue)
			{
				cars = cars.Where(c => c.Brand == adViewModel.Brand);
			}

			if (!string.IsNullOrWhiteSpace(adViewModel.Model))
			{
				cars = cars.Where(c => c.Model.ToLower().Contains(adViewModel.Model.ToLower()));
			}


			if (adViewModel.MinMileage.HasValue && adViewModel.MaxMileage.HasValue)
			{
				cars = cars.Where(c => c.Mileage >= adViewModel.MinMileage && c.Mileage <= adViewModel.MaxMileage);
			}

			if (adViewModel.MinPrice.HasValue && adViewModel.MaxPrice.HasValue)
			{
				cars = cars.Where(c => c.Price >= adViewModel.MinPrice && c.Price <= adViewModel.MaxPrice);
			}

			if (adViewModel.MinHorsePower.HasValue && adViewModel.MaxHorsePower.HasValue)
			{
				cars = cars.Where(c => c.Engine.Horsepower >= adViewModel.MinHorsePower && c.Engine.Horsepower <= adViewModel.MaxHorsePower);
			}

			if (adViewModel.StartYear != 0 && adViewModel.EndYear != 0)
			{
				cars = cars.Where(c => c.Year >= adViewModel.StartYear && c.Year <= adViewModel.EndYear);
			}

			if (adViewModel.EuroStandard != EuroStandardEnum.Default && adViewModel.EuroStandard.HasValue)
			{
				cars = cars.Where(c => c.EuroStandard == adViewModel.EuroStandard);
			}

			if (adViewModel.Transmission != TransmissionEnum.Default && adViewModel.Transmission.HasValue)
			{
				cars = cars.Where(c => c.Transmission == adViewModel.Transmission);
			}

			if (adViewModel.Colour != ColourEnum.Default && adViewModel.Colour.HasValue)
			{
				cars = cars.Where(c => c.Colour == adViewModel.Colour);
			}

			if (adViewModel.FuelType != FuelTypeEnum.Default && adViewModel.FuelType.HasValue)
			{
				cars = cars.Where(c => c.Engine.FuelType == adViewModel.FuelType);
			}

			if (adViewModel.Condition != ConditionEnum.Default && adViewModel.Condition.HasValue)
			{
				cars = cars.Where(c => c.Condition == adViewModel.Condition);
			}

			if (adViewModel.BodyType != BodyTypeEnum.Default && adViewModel.BodyType.HasValue)
			{
				cars = cars.Where(c => c.BodyType == adViewModel.BodyType);
			}

			if (adViewModel.DriveTrain != DriveTrainEnum.Default && adViewModel.DriveTrain.HasValue)
			{
				cars = cars.Where(c => c.DriveTrain == adViewModel.DriveTrain);
			}

			if (!string.IsNullOrWhiteSpace(adViewModel.Manufacturer))
			{
				cars = cars.Where(c => c.Manufacturer.Name.ToLower().Contains(adViewModel.Manufacturer.ToLower()));
			}

			return cars;
		}
	}
}
