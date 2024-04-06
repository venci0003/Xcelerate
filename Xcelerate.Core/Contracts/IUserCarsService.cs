using Xcelerate.Core.Models.Ad;
using Xcelerate.Core.Models.UserCars;
using Xcelerate.Infrastructure.Data.Models;

namespace Xcelerate.Core.Contracts
{
	public interface IUserCarsService : IBaseService
	{
		public Task<IEnumerable<AdPreviewViewModel>> GetUserCarsPreviewAsync(Guid userId, AdInformationViewModel adInformation);

		public Task<AdInformationViewModel> GetCarsInformationAsync(int? carId);

		public Task<UserCarsSellViewModel> GetSellInformationForCarAsync(int? carId);

		public Task<bool> SellCarAsync(UserCarsSellViewModel adViewModel, string userId);

		public Task<bool> CancelSellAdAsync(Car car, int adId);

		public Task<bool> DeleteCarAdAsync(int? carId);

		public Task<int> GetUserCarsCountAsync(AdInformationViewModel adPreview, string userId);
	}
}