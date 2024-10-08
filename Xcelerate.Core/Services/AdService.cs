﻿namespace Xcelerate.Core.Services
{
	using Microsoft.AspNetCore.Hosting;
	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata;
	using System.Globalization;
	using System.Linq.Expressions;
	using System.Net;
	using Contracts;
	using Models.Ad;
	using Models.Sorting;
	using Infrastructure.Data;
	using Infrastructure.Data.Enums;
	using Infrastructure.Data.Models;
	using static Common.EntityValidation;
	using static Common.NotificationMessages.UserMessages;
	using Xcelerate.Core.Models.Timestamp;
	using Microsoft.VisualBasic;

	public class АdService : IAdService
	{
		private readonly XcelerateContext _dbContext;
		private readonly IWebHostEnvironment _webHostEnvironment;
		private readonly Timestamp _timestamp;

		public АdService(XcelerateContext context, IWebHostEnvironment webHostEnvironment)
		{
			_dbContext = context;
			_webHostEnvironment = webHostEnvironment;
			_timestamp = new Timestamp(DateTime.UtcNow);
		}
		public async Task<IEnumerable<AdPreviewViewModel>> GetCarsPreviewAsync(AdInformationViewModel adViewModel)
		{
			IQueryable<Ad> ads = _dbContext.Ads
				.Include(a => a.Car)
				.Include(a => a.User)
				.Where(a => a.Car.IsForSale)
				.AsQueryable();

			ads = FilterCars(adViewModel, ads);

			IEnumerable<AdPreviewViewModel> carAds = await ads
				.Skip((adViewModel.Pager.CurrentPage - 1) * adViewModel.Pager.PageSize)
				.Take(adViewModel.Pager.PageSize)
				.AsNoTracking()
				.Select(ad => new AdPreviewViewModel
				{
					CarId = ad.Car.CarId,
					AdId = ad.AdId,
					ImageUrls = ad.Car.Images.Select(image => image.ImageUrl).ToList(),
					Brand = ad.Car.Brand,
					Model = ad.Car.Model,
					Year = ad.Car.Year,
					Engine = ad.Car.Engine.Model,
					HorsePower = ad.Car.Engine.Horsepower,
					Condition = ad.Car.Condition,
					EuroStandard = ad.Car.EuroStandard,
					FuelType = ad.Car.Engine.FuelType,
					Price = ad.Car.Price,
					FirstName = ad.User.FirstName,
					LastName = ad.User.LastName,
					CreatedOn = DateTime.ParseExact(ad.CreatedOn, AdEntity.CreatedOnDateFormat, CultureInfo.InvariantCulture).ToString(AdEntity.CreatedOnDateFormat)
				})
				.ToListAsync();

			return carAds;
		}

		public async Task<bool> IdExists<TEntity>(int id) where TEntity : class
		{
			DbSet<TEntity> dbSet = _dbContext.Set<TEntity>();

			IProperty? primaryKeyProperty = _dbContext.Model.FindEntityType(typeof(TEntity))
													 .FindPrimaryKey()
													 ?.Properties
													 .FirstOrDefault();

			ParameterExpression parameter = Expression.Parameter(typeof(TEntity), "e");
			MemberExpression propertyAccess = Expression.Property(parameter, primaryKeyProperty.PropertyInfo);
			BinaryExpression equality = Expression.Equal(propertyAccess, Expression.Constant(id));
			Expression<Func<TEntity, bool>> lambda = Expression.Lambda<Func<TEntity, bool>>(equality, parameter);

			return await dbSet.AnyAsync(lambda);
		}

		public Task<int> GetCarAdsCountAsync(AdInformationViewModel adPreview)
		{
			IQueryable<Ad> ads = _dbContext.Ads.AsQueryable();

			ads = FilterCars(adPreview, ads);

			return ads.CountAsync();
		}

		public Task<int> GetUserAdsCountAsync(AdInformationViewModel adPreview, string userId)
		{
			IQueryable<Ad> ads = _dbContext.Ads.Where(u => u.UserId == Guid.Parse(userId)).AsQueryable();

			ads = FilterCars(adPreview, ads);

			return ads.CountAsync();
		}


		public async Task<AdInformationViewModel> GetCarsInformationAsync(int? adId)
		{
			var ad = await _dbContext.Ads
	.Include(ad => ad.Car)
		.ThenInclude(car => car.Images)
	.Include(ad => ad.Car.Engine)
	.Include(ad => ad.Car.Manufacturer)
	.Include(ad => ad.Car.Address)
	.Include(ad => ad.User)
	.Where(ad => ad.AdId == adId)
	.AsNoTracking()
	.Select(ad => new AdInformationViewModel
	{
		ImageUrls = ad.Car.Images.Select(image => image.ImageUrl).ToList(),
		Brand = ad.Car.Brand,
		Model = ad.Car.Model,
		Year = ad.Car.Year,
		AdId = ad.AdId,
		CarId = ad.CarId,
		Engine = ad.Car.Engine.Model,
		HorsePower = ad.Car.Engine.Horsepower,
		Condition = ad.Car.Condition,
		EuroStandard = ad.Car.EuroStandard,
		FuelType = ad.Car.Engine.FuelType,
		Colour = ad.Car.Colour,
		Transmission = ad.Car.Transmission,
		DriveTrain = ad.Car.DriveTrain,
		Weight = ad.Car.Weight,
		Mileage = ad.Car.Mileage,
		Price = ad.Car.Price,
		BodyType = ad.Car.BodyType,
		CreatedOn = DateTime.ParseExact(ad.CreatedOn, AdEntity.CreatedOnDateFormat, CultureInfo.InvariantCulture).ToString(AdEntity.CreatedOnDateFormat),
		FirstName = ad.User.FirstName,
		LastName = ad.User.LastName,
		UserId = ad.UserId,
		Manufacturer = ad.Car.Manufacturer.Name,
		Address = new AddressViewModel
		{
			CountryName = ad.Car.Address.CountryName,
			TownName = ad.Car.Address.TownName,
			StreetName = ad.Car.Address.StreetName,
		},
		CarDescription = ad.CarDescription
	})
	.FirstOrDefaultAsync();

			if (ad == null)
			{
				return null;
			}

			return ad;
		}
		public async Task CreateAdAsync(AdCreateViewModel adViewModel, string userId)
		{
			try
			{
				var car = new Car
				{
					UserId = Guid.Parse(userId),
					Brand = adViewModel.Brand,
					Model = WebUtility.HtmlEncode(adViewModel.Model),
					Year = adViewModel.Year,
					IsForSale = adViewModel.IsForSale = true,
					Engine = new Engine
					{
						Model = WebUtility.HtmlEncode(adViewModel.Engine),
						Horsepower = adViewModel.HorsePower,
						FuelType = adViewModel.FuelType
					},
					Condition = adViewModel.Condition,
					EuroStandard = adViewModel.EuroStandard,
					Colour = adViewModel.Colour,
					Transmission = adViewModel.Transmission,
					DriveTrain = adViewModel.DriveTrain,
					Weight = adViewModel.Weight,
					Mileage = adViewModel.Mileage,
					Price = adViewModel.Price,
					BodyType = adViewModel.BodyType,
					Manufacturer = new Manufacturer { Name = adViewModel.Manufacturer },
					Address = new Address
					{
						CountryName = WebUtility.HtmlEncode(adViewModel.Address.CountryName),
						TownName = WebUtility.HtmlEncode(adViewModel.Address.TownName),
						StreetName = WebUtility.HtmlEncode(adViewModel.Address.StreetName)
					}
				};

				await _dbContext.Cars.AddAsync(car);
				await _dbContext.SaveChangesAsync();

				var ad = new Ad
				{
					UserId = Guid.Parse(userId),
					CarId = car.CarId,
					CarDescription = WebUtility.HtmlEncode(adViewModel.CarDescription),
					CreatedOn = adViewModel.CreatedOn.ToString(AdEntity.CreatedOnDateFormat)
				};

				await _dbContext.Ads.AddAsync(ad);
				await _dbContext.SaveChangesAsync();

				car.AdId = ad.AdId;
				_dbContext.Cars.Update(car);
				await _dbContext.SaveChangesAsync();

				foreach (var accessoryId in adViewModel.SelectedCheckBoxId)
				{
					_dbContext.CarAccessories.Add(new CarAccessory()
					{
						CarId = car.CarId,
						AccessoryId = accessoryId
					});
				}
				await _dbContext.SaveChangesAsync();

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
						await _dbContext.AddAsync(imageToCreate);
					}
				}

				await _dbContext.AddAsync(new Message()
				{
					UserId = Guid.Parse(userId),
					Title = SuccesfulCreateTitle,
					Content = string.Format(SuccesfulCreateContent, car.Brand, car.Model, car.Year),
					CreatedTime = _timestamp.GetTimestamp(),
					IsMessageViewed = false
				});

				await _dbContext.SaveChangesAsync();

				StatisticalData? statisticsUpdate = await _dbContext.StatisticalData.FirstOrDefaultAsync();

				statisticsUpdate.CreatedCars += 1;

				await _dbContext.SaveChangesAsync();
			}
			catch (Exception)
			{
				throw new ArgumentException("Failed to create ad!");
			}
		}

		public async Task<IEnumerable<AdPreviewViewModel>> GetUserAdsAsync(Guid userId, AdInformationViewModel adViewModel)
		{

			IQueryable<Ad> userAds = _dbContext.Ads.
				Include(a => a.Car).
				Where(ad => ad.UserId == userId && ad.Car.IsForSale == true).
				AsQueryable();

			userAds = FilterCars(adViewModel, userAds);

			IEnumerable<AdPreviewViewModel> carAds = await userAds
				.Skip((adViewModel.Pager.CurrentPage - 1) * adViewModel.Pager.PageSize)
				.Take(adViewModel.Pager.PageSize)
				.AsNoTracking()
		.AsNoTracking()
		.Select(car => new AdPreviewViewModel
		{
			AdId = car.AdId,
			CarId = car.CarId,
			ImageUrls = car.Car.Images.Select(car => car.ImageUrl).ToList(),
			Brand = car.Car.Brand,
			Model = car.Car.Model,
			Year = car.Car.Year,
			Engine = car.Car.Engine.Model,
			HorsePower = car.Car.Engine.Horsepower,
			Condition = car.Car.Condition,
			EuroStandard = car.Car.EuroStandard,
			FuelType = car.Car.Engine.FuelType,
			Price = car.Car.Price,
			FirstName = car.User.FirstName,
			LastName = car.User.LastName,
			CreatedOn = DateTime.ParseExact(car.Car.Ad.CreatedOn, AdEntity.CreatedOnDateFormat, CultureInfo.InvariantCulture).ToString(AdEntity.CreatedOnDateFormat),
		})
		.ToListAsync();

			return carAds;
		}

		public async Task<AdEditViewModel> GetEditInformationAsync(int? carId)
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

			AdEditViewModel adViewModel = new AdEditViewModel
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
				CarDescription = car.Ad.CarDescription
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

		public async Task<bool> EditCarAdAsync(AdEditViewModel adViewModel)
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

				car.Brand = adViewModel.Brand;
				car.Model = WebUtility.HtmlEncode(adViewModel.Model);
				car.Year = adViewModel.Year;
				car.Engine.Model = WebUtility.HtmlEncode(adViewModel.Engine);
				car.Engine.Horsepower = adViewModel.HorsePower;
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
				car.Manufacturer.Name = WebUtility.HtmlEncode(adViewModel.Manufacturer);
				car.Ad.CarDescription = WebUtility.HtmlEncode(adViewModel.CarDescription);
				car.Address.CountryName = WebUtility.HtmlEncode(adViewModel.Address.CountryName);
				car.Address.TownName = WebUtility.HtmlEncode(adViewModel.Address.TownName);
				car.Address.StreetName = WebUtility.HtmlEncode(adViewModel.Address.StreetName);

				car.Ad.CreatedOn = DateTime.Now.ToString(AdEntity.CreatedOnDateFormat);

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

				if (adViewModel.UploadedImages == null || !adViewModel.UploadedImages.Any())
				{
				}
				else
				{
					_dbContext.Images.RemoveRange(car.Images);


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
				}

				await _dbContext.AddAsync(new Message()
				{
					UserId = car.UserId,
					Title = SuccesfulEditTitle,
					Content = string.Format(SuccesfulEditContent, car.Brand, car.Model, car.Year),
					CreatedTime = _timestamp.GetTimestamp(),
					IsMessageViewed = false
				});

				await _dbContext.SaveChangesAsync();

				return true;

			}
			catch (Exception)
			{
				throw new ArgumentException("An error occurred while saving the ad.");
			}
		}


		public async Task<bool> DeleteCarAdAsync(int? carId)
		{
			var car = await _dbContext.Cars
				.Include(c => c.Ad)
				.Include(c => c.Images)
				.Include(c => c.CarAccessories)
					.ThenInclude(ca => ca.Accessory)
					.Include(m => m.Manufacturer)
					.Include(a => a.Address)
					.Include(e => e.Engine)
					.Include(r => r.Ad.Reviews)
				.FirstOrDefaultAsync(c => c.CarId == carId);

			if (car == null)
			{
				throw new ArgumentException("Car not found!");
			}

			try
			{
				foreach (var image in car.Images)
				{
					if (image != null && image.ImageUrl != null)
					{
						var imagePath = Path.Combine(_webHostEnvironment.WebRootPath ?? string.Empty, "Images", "Ad", image.ImageUrl);

						if (await Task.Run(() => System.IO.File.Exists(imagePath)))
						{
							bool fileDeleted = false;
							int retries = 3;

							while (!fileDeleted && retries > 0)
							{
								try
								{
									await Task.Run(() => System.IO.File.Delete(imagePath));
									fileDeleted = true;
								}
								catch (IOException)
								{
									await Task.Delay(500);
									retries--;
								}
							}

							if (!fileDeleted)
							{
								throw new IOException("Failed to delete the file because it is in use by another process.");
							}
						}
					}
					_dbContext.Images.Remove(image);
				}

				if (car.Ad != null && car.Ad.Reviews != null)
				{
					_dbContext.Reviews.RemoveRange(car.Ad.Reviews);
				}

				if (car.Ad != null)
				{
					_dbContext.Ads.Remove(car.Ad);
				}

				if (car.CarAccessories != null)
				{
					_dbContext.CarAccessories.RemoveRange(car.CarAccessories);
				}

				if (car.Address != null)
				{
					_dbContext.Addresses.Remove(car.Address);
				}

				if (car.Manufacturer != null)
				{
					_dbContext.Manufacturers.Remove(car.Manufacturer);
				}

				if (car.Engine != null)
				{
					_dbContext.Engines.Remove(car.Engine);
				}

				_dbContext.Cars.Remove(car);

				await _dbContext.SaveChangesAsync();

				await _dbContext.AddAsync(new Message()
				{
					UserId = car.UserId,
					Title = SuccesfulDeleteTitle,
					Content = string.Format(SuccesfulDeleteContent, car.Brand, car.Model, car.Year),
					CreatedTime = _timestamp.GetTimestamp(),
					IsMessageViewed = false
				});

				await _dbContext.SaveChangesAsync();

				return true;
			}
			catch (Exception ex)
			{
				throw new Exception($"Error deleting car ad: {ex.Message}");
			}
		}

		public async Task<bool> BuyCarAsync(Car car, decimal confirmedPrice)
		{
			Ad? adToRemove = await _dbContext.Ads.FirstOrDefaultAsync(a => a.AdId == car.AdId);

			if (adToRemove != null)
			{
				var reviewsToRemove = _dbContext.Reviews.Where(r => r.AdId == adToRemove.AdId);
				_dbContext.Reviews.RemoveRange(reviewsToRemove);

				_dbContext.Ads.Remove(adToRemove);

				_dbContext.Cars.Update(car);

				StatisticalData? statisticsUpdate = await _dbContext.StatisticalData.FirstOrDefaultAsync();

				statisticsUpdate.SoldCars += 1;

				var buyer = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == car.UserId);

				var seller = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == adToRemove.UserId);

				if (buyer.Balance < confirmedPrice)
				{
					// Handle insufficient balance (you might want to return a specific result or throw an exception)
					return false;
				}

				// Update balances
				buyer.Balance -= confirmedPrice;
				seller.Balance += confirmedPrice;

				await _dbContext.AddAsync(new Message()
				{
					UserId = seller.Id,
					Title = SuccesfulSoldTitle,
					Content = string.Format(SuccesfulSoldContent, car.Brand, car.Model, car.Year, buyer.FirstName, buyer.LastName, car.Price),
					CreatedTime = _timestamp.GetTimestamp(),
					IsMessageViewed = false
				});

				await _dbContext.AddAsync(new Message()
				{
					UserId = buyer.Id,
					Title = SuccesfulBoughtTitle,
					Content = string.Format(SuccesfulBoughtContent, car.Brand, car.Model, car.Year, seller.FirstName, seller.LastName, car.Price),
					CreatedTime = _timestamp.GetTimestamp(),
					IsMessageViewed = false
				});

				await _dbContext.SaveChangesAsync();
				return true;
			}
			else
			{
				return false;
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


		public async Task<(AdInformationViewModel firstCar, AdInformationViewModel secondCar)> GetTwoCarsByIdAsync(int firstCarId, int secondCarId)
		{
			var firstCarDataModel = await _dbContext.Cars
				.Where(c => c.CarId == firstCarId)
				.AsNoTracking()
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
					CreatedOn = DateTime.ParseExact(car.Ad.CreatedOn, AdEntity.CreatedOnDateFormat, CultureInfo.InvariantCulture).ToString(AdEntity.CreatedOnDateFormat),
					FirstName = car.User.FirstName,
					LastName = car.User.LastName,
					UserId = car.UserId,
					Manufacturer = car.Manufacturer.Name,
					Address = new AddressViewModel
					{
						CountryName = car.Address.CountryName,
						TownName = car.Address.TownName,
						StreetName = car.Address.StreetName,
					},
					CarDescription = car.Ad.CarDescription
				}).FirstOrDefaultAsync();

			var secondCarDataModel = await _dbContext.Cars
				.Where(c => c.CarId == secondCarId)
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
					CreatedOn = DateTime.ParseExact(car.Ad.CreatedOn, AdEntity.CreatedOnDateFormat, CultureInfo.InvariantCulture).ToString(AdEntity.CreatedOnDateFormat),
					FirstName = car.User.FirstName,
					LastName = car.User.LastName,
					UserId = car.UserId,
					Manufacturer = car.Manufacturer.Name,
					Address = new AddressViewModel
					{
						CountryName = car.Address.CountryName,
						TownName = car.Address.TownName,
						StreetName = car.Address.StreetName,
					},
					CarDescription = car.Ad.CarDescription
				}).FirstOrDefaultAsync();


			if (firstCarDataModel == null || secondCarDataModel == null)
			{
				throw new ArgumentException("One or both cars not found!");
			}

			return (firstCarDataModel, secondCarDataModel);
		}

		public async Task<(string firstName, string lastName)> GetUserFullNameAsync(Guid userId)
		{
			var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == userId);
			if (user != null)
			{
				return (user.FirstName, user.LastName);
			}
			else
			{
				return (null, null);
			}
		}

		public IQueryable<Ad> FilterCars(AdInformationViewModel adViewModel, IQueryable<Ad> cars)
		{
			if (adViewModel.Sorting == SortingEnums.PriceAscending)
			{
				cars = cars.OrderBy(c => c.Car.Price);
			}
			else if (adViewModel.Sorting == SortingEnums.PriceDescending)
			{
				cars = cars.OrderByDescending(c => c.Car.Price);
			}
			else if (adViewModel.Sorting == SortingEnums.YearAscending)
			{
				cars = cars.OrderBy(c => c.Car.Year);
			}
			else if (adViewModel.Sorting == SortingEnums.YearDescending)
			{
				cars = cars.OrderByDescending(c => c.Car.Year);
			}


			if (adViewModel.Brand != BrandsEnum.Default && adViewModel.Brand.HasValue)
			{
				cars = cars.Where(c => c.Car.Brand == adViewModel.Brand);
			}

			if (!string.IsNullOrWhiteSpace(adViewModel.Model))
			{
				cars = cars.Where(c => c.Car.Model.ToLower().Contains(adViewModel.Model.ToLower()));
			}


			if (adViewModel.MinMileage.HasValue && adViewModel.MaxMileage.HasValue)
			{
				cars = cars.Where(c => c.Car.Mileage >= adViewModel.MinMileage && c.Car.Mileage <= adViewModel.MaxMileage);
			}

			if (adViewModel.MinPrice.HasValue && adViewModel.MaxPrice.HasValue)
			{
				cars = cars.Where(c => c.Car.Price >= adViewModel.MinPrice && c.Car.Price <= adViewModel.MaxPrice);
			}

			if (adViewModel.MinHorsePower.HasValue && adViewModel.MaxHorsePower.HasValue)
			{
				cars = cars.Where(c => c.Car.Engine.Horsepower >= adViewModel.MinHorsePower && c.Car.Engine.Horsepower <= adViewModel.MaxHorsePower);
			}

			if (adViewModel.StartYear != 0 && adViewModel.EndYear != 0)
			{
				cars = cars.Where(c => c.Car.Year >= adViewModel.StartYear && c.Car.Year <= adViewModel.EndYear);
			}

			if (adViewModel.EuroStandard != EuroStandardEnum.Default && adViewModel.EuroStandard.HasValue)
			{
				cars = cars.Where(c => c.Car.EuroStandard == adViewModel.EuroStandard);
			}

			if (adViewModel.Transmission != TransmissionEnum.Default && adViewModel.Transmission.HasValue)
			{
				cars = cars.Where(c => c.Car.Transmission == adViewModel.Transmission);
			}

			if (adViewModel.Colour != ColourEnum.Default && adViewModel.Colour.HasValue)
			{
				cars = cars.Where(c => c.Car.Colour == adViewModel.Colour);
			}

			if (adViewModel.FuelType != FuelTypeEnum.Default && adViewModel.FuelType.HasValue)
			{
				cars = cars.Where(c => c.Car.Engine.FuelType == adViewModel.FuelType);
			}

			if (adViewModel.Condition != ConditionEnum.Default && adViewModel.Condition.HasValue)
			{
				cars = cars.Where(c => c.Car.Condition == adViewModel.Condition);
			}

			if (adViewModel.BodyType != BodyTypeEnum.Default && adViewModel.BodyType.HasValue)
			{
				cars = cars.Where(c => c.Car.BodyType == adViewModel.BodyType);
			}

			if (adViewModel.DriveTrain != DriveTrainEnum.Default && adViewModel.DriveTrain.HasValue)
			{
				cars = cars.Where(c => c.Car.DriveTrain == adViewModel.DriveTrain);
			}

			if (!string.IsNullOrWhiteSpace(adViewModel.Manufacturer))
			{
				cars = cars.Where(c => c.Car.Manufacturer.Name.ToLower().Contains(adViewModel.Manufacturer.ToLower()));
			}

			return cars;
		}
	}
}
