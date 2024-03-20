using Xcelerate.Core.Models.UserCars;
using Xcelerate.Infrastructure.Data.Models;

namespace Xcelerate.Core.Contracts
{
	public interface IUserCarsService
	{
		public Task<IEnumerable<UserCarsPreviewViewModel>> GetUserCarsPreviewAsync(Guid userId);

		public Task<UserCarsInformationViewModel> GetCarsInformationAsync(int? carId);

		public Task<UserCarsSellViewModel> GetSellInformationForCarAsync(int? carId);

		public Task<bool> SellCarAsync(UserCarsSellViewModel adViewModel, string userId);

		public Task<bool> CancelSellAdAsync(Car car, int adId);

		public Task<bool> DeleteCarAdAsync(int? carId);

		//public Task<Car> GetCarByIdAsync(int carId);
	}
}