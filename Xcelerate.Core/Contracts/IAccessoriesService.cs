namespace Xcelerate.Core.Contracts
{
	using Models.Ad;
	public interface IAccessoriesService
	{
		Task<AdCreateViewModel> GetAccessories();

		Task<List<AccessoryViewModel>> GetCarAccessoriesForSaleAsync(int adId);

		Task<List<AccessoryViewModel>> GetCarAccessoriesForOwnedCarsAsync(int carId);

	}
}
