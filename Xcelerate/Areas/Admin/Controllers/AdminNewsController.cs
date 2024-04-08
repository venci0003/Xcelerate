using Microsoft.AspNetCore.Mvc;
using Xcelerate.Areas.Admin.Contracts;
using Xcelerate.Areas.Admin.Models;

namespace Xcelerate.Areas.Admin.Controllers
{
	public class AdminNewsController : BaseAdminController
	{
		private readonly IAdminNewsService _adminNewsService;

		public AdminNewsController(IAdminNewsService _adminNewsServiceContext)
		{
			_adminNewsService = _adminNewsServiceContext;
		}
		public async Task<IActionResult> AddGeneratedNews()
		{
			var result = await _adminNewsService.GenerateNewsAsync();
			return View(result);
		}

		public async Task<IActionResult> ApproveNewsUpload(GeneratedNewsViewModel generatedNewsView, string TitleAndContent)
		{
			string delimiter = "\r\n\r\n";

			string[] parts = TitleAndContent.Split(new string[] { delimiter }, StringSplitOptions.None);

			string title = parts[0];
			string content = parts[1];

			generatedNewsView.Title = title;
			generatedNewsView.Content = content;

			await _adminNewsService.ApproveNewsAsync(generatedNewsView);

			return RedirectToAction("Index", "Home", new { Area = "Admin" });
		}
	}
}