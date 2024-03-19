using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Net;
using Xcelerate.Core.Contracts;
using Xcelerate.Core.Models.Ad;
using Xcelerate.Core.Models.Pager;
using Xcelerate.Infrastructure.Data;
using Xcelerate.Infrastructure.Data.Enums;
using Xcelerate.Infrastructure.Data.Models;
using static Xcelerate.Common.EntityValidation;

namespace Xcelerate.Core.Services
{
	public class АdService : IAdService
	{
		private readonly XcelerateContext _dbContext;
		private readonly IWebHostEnvironment _webHostEnvironment;

		public АdService(XcelerateContext context, IWebHostEnvironment webHostEnvironment)
		{
			_dbContext = context;
			_webHostEnvironment = webHostEnvironment;
		}
		public async Task<IEnumerable<AdPreviewViewModel>> GetCarsPreviewAsync(AdInformationViewModel adViewModel)
		{
			IQueryable<Ad> ads = _dbContext.Ads
				.Include(a => a.Car)
				.Include(a => a.User)
				.Where(a => a.Car.IsForSale)
				.AsQueryable();

			// Apply filtering based on adViewModel
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
					FuelType = ad.Car.FuelType,
					Price = ad.Car.Price,
					FirstName = ad.User.FirstName,
					LastName = ad.User.LastName,
					CreatedOn = DateTime.ParseExact(ad.CreatedOn, AdEntity.CreatedOnDateFormat, CultureInfo.InvariantCulture).ToString(AdEntity.CreatedOnDateFormat)
				})
				.ToListAsync();

			return carAds;
		}

		public Task<int> GetCountAsync(AdInformationViewModel adPreview)
		{
			IQueryable<Ad> ads = _dbContext.Ads.AsQueryable();

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
		FuelType = ad.Car.FuelType,
		Colour = ad.Car.Colour,
		Transmition = ad.Car.Transmition,
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
					Brand = WebUtility.HtmlEncode(adViewModel.Brand),
					Model = WebUtility.HtmlEncode(adViewModel.Model),
					Year = adViewModel.Year,
					IsForSale = adViewModel.IsForSale = true,
					Engine = new Engine
					{
						Model = WebUtility.HtmlEncode(adViewModel.Engine),
						Horsepower = adViewModel.HorsePower
					},
					Condition = adViewModel.Condition,
					EuroStandard = adViewModel.EuroStandard,
					FuelType = adViewModel.FuelType,
					Colour = adViewModel.Colour,
					Transmition = adViewModel.Transmition,
					DriveTrain = adViewModel.DriveTrain,
					Weight = adViewModel.Weight,
					Mileage = adViewModel.Mileage,
					Price = adViewModel.Price,
					BodyType = adViewModel.BodyType,
					Manufacturer = new Manufacturer { Name = adViewModel.Manufacturer },
					Ad = new Ad
					{
						UserId = Guid.Parse(userId),
						CarDescription = WebUtility.HtmlEncode(adViewModel.CarDescription),
						CreatedOn = adViewModel.CreatedOn.ToString(AdEntity.CreatedOnDateFormat)
					},
					Address = new Address
					{
						CountryName = WebUtility.HtmlEncode(adViewModel.Address.CountryName),
						TownName = WebUtility.HtmlEncode(adViewModel.Address.TownName),
						StreetName = WebUtility.HtmlEncode(adViewModel.Address.StreetName)
					}
				};

				await _dbContext.AddAsync(car);
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
						await image.CopyToAsync(new FileStream(filePath, FileMode.Create));

						Image imageToCreate = new Image()
						{
							CarId = car.CarId,
							ImageUrl = uniqueFileName
						};
						await _dbContext.AddAsync(imageToCreate);
					}
				}

				await _dbContext.SaveChangesAsync();
			}
			catch (Exception)
			{
				throw new ArgumentException("Failed to create ad!");
			}
		}

		public async Task<List<UserAdsViewModel>> GetUserAdsAsync(Guid userId)
		{

			List<UserAdsViewModel> userAds = await _dbContext.Ads
		.Where(ad => ad.UserId == userId && ad.Car.IsForSale == true)
		.AsNoTracking()
		.Select(car => new UserAdsViewModel
		{
			AdId = car.AdId,
			CarId = car.CarId,
			ImageUrls = car.Car.Images.Select(car => car.ImageUrl).ToList(),
			Brand = car.Car.Brand,
			Model = car.Car.Model,
			Year = car.Car.Year,
			Engine = car.Car.Engine.Model,
			Condition = car.Car.Condition,
			EuroStandard = car.Car.EuroStandard,
			FuelType = car.Car.FuelType,
			Price = car.Car.Price,
			FirstName = car.User.FirstName,
			LastName = car.User.LastName,
		})
		.ToListAsync();

			return userAds;
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
				FuelType = car.FuelType,
				Colour = car.Colour,
				Transmition = car.Transmition,
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

				// Update the properties of the existing car entity based on the ViewModel
				car.Brand = WebUtility.HtmlEncode(adViewModel.Brand);
				car.Model = WebUtility.HtmlEncode(adViewModel.Model);
				car.Year = adViewModel.Year;
				car.Engine.Model = WebUtility.HtmlEncode(adViewModel.Engine);
				car.Condition = adViewModel.Condition;
				car.EuroStandard = adViewModel.EuroStandard;
				car.FuelType = adViewModel.FuelType;
				car.Colour = adViewModel.Colour;
				car.Transmition = adViewModel.Transmition;
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

				// Update CarAccessories
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
					// User wants to keep existing images, do nothing
				}
				else
				{
					// User wants to upload new images, remove existing images and add new ones
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

				// Remove associated reviews
				if (car.Ad != null && car.Ad.Reviews != null)
				{
					_dbContext.Reviews.RemoveRange(car.Ad.Reviews);
				}

				// Remove associated ad
				if (car.Ad != null)
				{
					_dbContext.Ads.Remove(car.Ad);
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

		public async Task<bool> BuyCarAsync(Car car)
		{
			var adToRemove = await _dbContext.Ads.FirstOrDefaultAsync(a => a.AdId == car.AdId);

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
					FuelType = car.FuelType,
					Colour = car.Colour,
					Transmition = car.Transmition,
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
					FuelType = car.FuelType,
					Colour = car.Colour,
					Transmition = car.Transmition,
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

		public IQueryable<Ad> FilterCars(AdInformationViewModel adViewModel, IQueryable<Ad> cars)
		{
			if (adViewModel.Year != 0)
			{
				cars = cars.Where(c => c.Car.Year == adViewModel.Year);
			}

			if (adViewModel.EuroStandard != EuroStandardEnum.Default && adViewModel.EuroStandard.HasValue)
			{
				cars = cars.Where(c => c.Car.EuroStandard == adViewModel.EuroStandard);
			}

			if (adViewModel.Transmition != TransmissionEnum.Default && adViewModel.Transmition.HasValue)
			{
				cars = cars.Where(c => c.Car.Transmition == adViewModel.Transmition);
			}

			if (adViewModel.Colour != ColourEnum.Default && adViewModel.Colour.HasValue)
			{
				cars = cars.Where(c => c.Car.Colour == adViewModel.Colour);
			}

			if (adViewModel.FuelType != FuelTypeEnum.Default && adViewModel.FuelType.HasValue)
			{
				cars = cars.Where(c => c.Car.FuelType == adViewModel.FuelType);
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

			return cars;
		}
	}
}
