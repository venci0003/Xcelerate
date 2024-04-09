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

			//This split is used because I didn't want to use separate text areas, and I wanted the title and content to be in one text area.

			generatedNewsView.Title = title;
			generatedNewsView.Content = content;

			await _adminNewsService.ApproveNewsAsync(generatedNewsView);

			return RedirectToAction("Index", "Home", new { Area = "Admin" });
		}
	}
}