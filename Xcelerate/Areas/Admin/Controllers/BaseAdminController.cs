namespace Xcelerate.Areas.Admin.Controllers
{
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;
	using static Common.ApplicationConstants;

	[Area(AdminAreaName)]
	[Authorize(Roles = AdminRoleName)]

	public class BaseAdminController : Controller
	{

	}
}
