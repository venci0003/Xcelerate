using Xcelerate.Core.Models.Ad;

namespace Xcelerate.Core.Contracts
{
	public interface IAccessoriesService
	{
		Task<AdCreateViewModel> GetAccessories();

		Task<List<AccessoryViewModel>> GetCarAccessoriesAsync(int carId);

	}
}
