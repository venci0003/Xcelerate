using Xcelerate.Core.Models.Ad;
using Xcelerate.Infrastructure.Data.Models;

namespace Xcelerate.Core.Contracts
{
	public interface IAdService
	{
		public Task<IEnumerable<AdPreviewViewModel>> GetCarsPreviewAsync(AdInformationViewModel adViewModel);
		public Task<AdInformationViewModel> GetCarsInformationAsync(int? adId);
		public Task CreateAdAsync(AdCreateViewModel adViewModel, string userId);
		public Task<IEnumerable<AdPreviewViewModel>> GetUserAdsAsync(Guid userId, AdInformationViewModel adViewModel);
		public Task<AdEditViewModel> GetEditInformationAsync(int? carId);
		public Task<bool> EditCarAdAsync(AdEditViewModel adViewModel);
		public Task<bool> DeleteCarAdAsync(int? carId);
		public Task<bool> BuyCarAsync(Car car);
		public Task<Car> GetCarByIdAsync(int carId);
		public Task<bool> IdExists<TEntity>(int id) where TEntity : class;
		public Task<int> GetCarAdsCountAsync(AdInformationViewModel adPreview);
		public Task<int> GetUserAdsCountAsync(AdInformationViewModel adPreview, string userId);
		public Task<(AdInformationViewModel firstCar, AdInformationViewModel secondCar)> GetTwoCarsByIdAsync(int firstCarId, int secondCarId);


	}
}
