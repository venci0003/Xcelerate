using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Xcelerate.Core.Models.Ad;

namespace Xcelerate.Core.Contracts
{
	public interface IAdService
	{
		public Task<IEnumerable<AdPreviewViewModel>> GetCarsPreviewAsync();
		public Task<AdInformationViewModel> GetCarsInformationAsync(int? carId);
		public Task CreateAdAsync(AdCreateViewModel adViewModel, string userId);
		public Task<List<UserAdsViewModel>> GetUserAdsAsync(Guid userId);
		public Task<AdEditViewModel> GetEditInformationAsync(int? carId);
		public Task<IActionResult> Edit(AdEditViewModel adViewModel);
		public Task<bool> Delete(int? carId);
	}
}
