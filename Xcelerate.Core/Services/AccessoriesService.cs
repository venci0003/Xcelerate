using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xcelerate.Core.Contracts;
using Xcelerate.Core.Models.Ad;
using Xcelerate.Infrastructure.Data;

namespace Xcelerate.Core.Services
{
	public class AccessoriesService : IAccessoriesService
	{
		private readonly XcelerateContext _dbContext;

		public AccessoriesService(XcelerateContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<AdCreateViewModel> GetAccessories()
		{
			AdCreateViewModel adViewModel = new AdCreateViewModel();

			List<AccessoryViewModel> accessories = await _dbContext.Accessories
				.Select(accessory => new AccessoryViewModel()
				{
					AccessoryId = accessory.AccessoryId,
					Name = accessory.Name
				}).ToListAsync();

			adViewModel.Accessories = accessories;

			return adViewModel;
		}

		public async Task<List<AccessoryViewModel>> GetCarAccessoriesForOwnedCarsAsync(int carId)
		{
			var car = await _dbContext.Cars
				.Include(c => c.CarAccessories)
					.ThenInclude(ca => ca.Accessory)
				.FirstOrDefaultAsync(c => c.CarId == carId);

			if (car != null)
			{
				var accessories = car.CarAccessories.Select(ca => new AccessoryViewModel
				{
					AccessoryId = ca.AccessoryId,
					Name = ca.Accessory.Name
				}).ToList();

				return accessories;
			}

			return null;
		}

		public async Task<List<AccessoryViewModel>> GetCarAccessoriesForSaleAsync(int adId)
		{
			var car = await _dbContext.Ads
					.Include(c => c.Car)
				.Include(c => c.Car.CarAccessories)
					.ThenInclude(ca => ca.Accessory)
				.FirstOrDefaultAsync(c => c.AdId == adId);

			if (car != null)
			{
				var accessories = car.Car.CarAccessories.Select(ca => new AccessoryViewModel
				{
					AccessoryId = ca.AccessoryId,
					Name = ca.Accessory.Name
				}).ToList();

				return accessories;
			}

			return null;
		}
	}
}
