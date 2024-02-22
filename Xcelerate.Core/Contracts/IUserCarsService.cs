using Xcelerate.Core.Models.Ad;
using Xcelerate.Core.Models.UserCars;
using Xcelerate.Infrastructure.Data.Models;

namespace Xcelerate.Core.Contracts
{
	public interface IUserCarsService
	{
		public Task<IEnumerable<UserCarsPreviewViewModel>> GetUserCarsPreviewAsync();

		public Task<UserCarsInformationViewModel> GetCarsInformationAsync(int? carId);

		public Task<UserCarsSellViewModel> GetSellInformationForCarAsync(int? carId);

		public Task<bool> SellCarAsync(UserCarsSellViewModel adViewModel);

		//public Task<Car> GetCarByIdAsync(int carId);
	}
}
