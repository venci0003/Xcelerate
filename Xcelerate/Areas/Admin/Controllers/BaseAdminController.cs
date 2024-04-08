using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Xcelerate.Common.ApplicationConstants;

namespace Xcelerate.Areas.Admin.Controllers
{
	[Area(AdminAreaName)]
	[Authorize(Roles = AdminRoleName)]
	public class BaseAdminController : Controller
	{

	}
}
