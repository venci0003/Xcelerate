

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System.Globalization;
using Xcelerate.Core.Contracts;
using Xcelerate.Core.Models.Ad;
using Xcelerate.Infrastructure.Data;
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
		public async Task<IEnumerable<AdPreviewViewModel>> GetCarsPreviewAsync()
		{
			IEnumerable<AdPreviewViewModel> cars = await _dbContext.Cars.Select(car => new AdPreviewViewModel
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
				FuelType = car.FuelType,
				Price = car.Price,
				FirstName = car.User.FirstName,
				LastName = car.User.LastName,
				CreatedOn = car.Ad.CreatedOn,
			}).ToListAsync();

			return cars;
		}

		public async Task<AdInformationViewModel> GetCarsInformationAsync(int? carId)
		{
			AdInformationViewModel? car = await _dbContext.Cars.Where(c => c.CarId == carId).Select(car => new AdInformationViewModel
			{
				ImageUrls = car.Images.Select(image => image.ImageUrl).ToList(),
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
				CreatedOn = DateTime.ParseExact(car.Ad.CreatedOn, AdEntity.CreatedOnDateFormat, CultureInfo.InvariantCulture),
				FirstName = car.User.FirstName,
				LastName = car.User.LastName,
				Manufacturer = car.Manufacturer.Name,
				Address = new AddressViewModel
				{
					CountryName = car.Address.CountryName,
					TownName = car.Address.TownName,
					StreetName = car.Address.StreetName,
				},
				CarDescription = car.Ad.CarDescription
			}).FirstOrDefaultAsync();

			if (car == null)
			{
				return null;
			}

			return car;
		}
		public async Task CreateAdAsync(AdCreateViewModel adViewModel, string userId)
		{

			try
			{
				var car = new Car
				{
					UserId = Guid.Parse(userId),
					Brand = adViewModel.Brand,
					Model = adViewModel.Model,
					Year = adViewModel.Year,
					Engine = new Engine
					{
						Model = adViewModel.Engine,
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
						CarDescription = adViewModel.CarDescription,
						CreatedOn = adViewModel.CreatedOn.ToString(AdEntity.CreatedOnDateFormat)
					},
					Address = new Address
					{
						CountryName = adViewModel.Address.CountryName,
						TownName = adViewModel.Address.TownName,
						StreetName = adViewModel.Address.StreetName
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
		.Where(ad => ad.UserId == userId)
		.Select(car => new UserAdsViewModel
		{
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
				car.Brand = adViewModel.Brand;
				car.Model = adViewModel.Model;
				car.Year = adViewModel.Year;
				car.Engine.Model = adViewModel.Engine;
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
				car.Manufacturer.Name = adViewModel.Manufacturer;
				car.Ad.CarDescription = adViewModel.CarDescription;
				car.Address.CountryName = adViewModel.Address.CountryName;
				car.Address.TownName = adViewModel.Address.TownName;
				car.Address.StreetName = adViewModel.Address.StreetName;

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

				foreach (var oldImage in car.Images.ToList())
				{
					var oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, "Images", "Ad", oldImage.ImageUrl);

					if (System.IO.File.Exists(oldImagePath))
					{
						using (var stream = new FileStream(oldImagePath, FileMode.Open, FileAccess.ReadWrite))
						{
							// Close and dispose of the FileStream before deletion
							stream.Close();
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
							image.CopyTo(stream);
						}

						Image imageToCreate = new Image()
						{
							CarId = car.CarId,
							ImageUrl = uniqueFileName
						};
						_dbContext.Images.Add(imageToCreate);
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
	}
}
