using Microsoft.AspNetCore.Mvc;

namespace Xcelerate.Areas.Admin.Controllers
{
    public class AdminNewsController : BaseAdminController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
