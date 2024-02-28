﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xcelerate.Core.Contracts;
using Xcelerate.Core.Models.Ad;
using Xcelerate.Core.Models.UserCars;
using Xcelerate.Infrastructure.Data;
using Xcelerate.Infrastructure.Data.Models;
using static Xcelerate.Common.EntityValidation;

namespace Xcelerate.Core.Services
{
	public class UserCarsService : IUserCarsService
	{
		private readonly XcelerateContext _dbContext;
		private readonly IWebHostEnvironment _webHostEnvironment;


		public UserCarsService(XcelerateContext context, IWebHostEnvironment webHostEnvironment)
		{
			_dbContext = context;
			_webHostEnvironment = webHostEnvironment;
		}

		public async Task<UserCarsInformationViewModel> GetCarsInformationAsync(int? carId)
		{
			UserCarsInformationViewModel? car = await _dbContext.Cars
				.Where(c => c.CarId == carId && c.IsForSale == false)
				.Select(car => new UserCarsInformationViewModel
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

		public async Task<IEnumerable<UserCarsPreviewViewModel>> GetUserCarsPreviewAsync(Guid userId)
		{
			IEnumerable<UserCarsPreviewViewModel> cars = await _dbContext.Cars.Where(c => c.IsForSale == false && c.UserId == userId).Select(car => new UserCarsPreviewViewModel
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
				}
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

		public async Task<bool> SellCarAsync(UserCarsSellViewModel adViewModel)
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
				car.Ad.CreatedOn = DateTime.Now.ToString(AdEntity.CreatedOnDateFormat);
				car.IsForSale = true;

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

		public async Task<bool> CancelSellAdAsync(int? carId)
		{
			var carAdToRemove = await _dbContext.Cars.FirstOrDefaultAsync(c => c.CarId == carId);

			if (carAdToRemove == null)
			{
				throw new ArgumentException("An error occurred removing the ad.");
			}

			carAdToRemove.IsForSale = false;

			await _dbContext.SaveChangesAsync();

			return true;
		}
	}
}
