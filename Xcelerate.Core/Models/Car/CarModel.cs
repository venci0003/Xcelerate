using Xcelerate.Core.Models.Ad;

namespace Xcelerate.Core.Models.Car
{
	using Xcelerate.Core.Models.Pager;
	public class CarModel
	{
		public List<AdPreviewViewModel> Cars { get; set;} = new List<AdPreviewViewModel>();

		public Pager Pager { get; set; }
	}
}
