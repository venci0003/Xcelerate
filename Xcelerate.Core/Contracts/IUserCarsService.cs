using Xcelerate.Core.Models.UserCars;

namespace Xcelerate.Core.Contracts
{
	public interface IUserCarsService
	{
		public Task<IEnumerable<UserCarsPreviewViewModel>> GetUserCarsPreviewAsync(Guid userId);

		public Task<UserCarsInformationViewModel> GetCarsInformationAsync(int? carId);

		public Task<UserCarsSellViewModel> GetSellInformationForCarAsync(int? carId);

		public Task<bool> SellCarAsync(UserCarsSellViewModel adViewModel);

		public Task<bool> CancelSellAdAsync(int? carId);

		//public Task<Car> GetCarByIdAsync(int carId);
	}
}
