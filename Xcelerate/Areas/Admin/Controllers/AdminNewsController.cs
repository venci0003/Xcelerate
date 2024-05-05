namespace Xcelerate.Areas.Admin.Controllers
{
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.Extensions.Caching.Memory;
	using Contracts;
	using Models;
	using static Common.ApplicationConstants;
	using Xcelerate.Core.Contracts;
	using Xcelerate.Extension;

	public class AdminNewsController : BaseAdminController
	{
		private readonly IAdminNewsService _adminNewsService;
		private readonly IMessageService _messageService;
		private readonly IMemoryCache _memoryCache;

		public AdminNewsController(
			IAdminNewsService _adminNewsServiceContext,
			IMemoryCache _memoryCacheContext,
			IMessageService _messageServiceContext)
		{
			_adminNewsService = _adminNewsServiceContext;
			_memoryCache = _memoryCacheContext;
			_messageService = _messageServiceContext;
		}
		public async Task<IActionResult> AddGeneratedNews()
		{
			ViewBag.UnreadMessageCount = await _messageService.GetUnreadMessageCountAsync(User.GetUserId().ToString());
			var result = _adminNewsService.GenerateNews();
			return View(result);
		}

		public async Task<IActionResult> ApproveNewsUpload(GeneratedNewsViewModel generatedNewsView, string TitleAndContent)
		{
			string delimiter = "\r\n\r\n";

			string[] parts = TitleAndContent.Split(new string[] { delimiter }, StringSplitOptions.None);

			if (parts.Length < 2)
			{
				TempData["ErrorMessage"] = "Title or content is missing.";
				return RedirectToAction("Index", "Home", new { Area = "Admin" });
			}

			string title = parts[0];
			string content = parts[1];

			//This split is used because I didn't want to use separate text areas, and I wanted the title and content to be in one text area.

			generatedNewsView.Title = title;
			generatedNewsView.Content = content;

			await _adminNewsService.ApproveNewsAsync(generatedNewsView);

			var newsCount = await _adminNewsService.GetNewsCountAsync();

			for (int i = 1; i <= newsCount; i++)
			{
				string cacheKey = $"{AdminNewsCacheKey}_{i}";
				_memoryCache.Remove(cacheKey);
			}

			return RedirectToAction("Index", "Home", new { Area = "Admin" });
		}
	}
}