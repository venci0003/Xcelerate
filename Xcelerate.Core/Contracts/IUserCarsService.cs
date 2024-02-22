using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xcelerate.Core.Models.Ad;
using Xcelerate.Core.Models.UserCars;

namespace Xcelerate.Core.Contracts
{
	public interface IUserCarsService
	{
		public Task<IEnumerable<UserCarsPreviewViewModel>> GetUserCarsPreviewAsync();
	}
}
