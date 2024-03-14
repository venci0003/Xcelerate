using Xcelerate.Core.Models.Ad;

namespace Xcelerate.Core.Contracts
{
	public interface IAccessoriesService
	{
		Task<AdCreateViewModel> GetAccessories();

		Task<List<AccessoryViewModel>> GetCarAccessoriesForSaleAsync(int adId);

		Task<List<AccessoryViewModel>> GetCarAccessoriesForOwnedCarsAsync(int carId);

	}
}
