using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xcelerate.Core.Contracts;
using Xcelerate.Core.Models.Ad;
using Xcelerate.Core.Models.UserCars;
using Xcelerate.Infrastructure.Data;

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

		public async Task<IEnumerable<UserCarsPreviewViewModel>> GetUserCarsPreviewAsync()
		{
			IEnumerable<UserCarsPreviewViewModel> cars = await _dbContext.Cars.Where(c => c.IsForSale == false).Select(car => new UserCarsPreviewViewModel
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
	}
}
