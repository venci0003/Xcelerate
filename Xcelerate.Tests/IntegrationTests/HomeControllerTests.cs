using Microsoft.AspNetCore.Mvc;
using Moq;
using Xcelerate.Controllers;
using Xcelerate.Core.Contracts;
using Xcelerate.Core.Models.Home;
using Xcelerate.Core.Models.Pager;

namespace Xcelerate.Tests.IntegrationTests
{
	[TestFixture]
	public class HomeControllerTests
	{
		//[Test]
		//public async Task HomePage_WithCurrentPageLessThanOne_SetsCurrentPageToOne()
		//{
		//	var mockHomeService = new Mock<IHomeService>();
		//	var mockMessageService = new Mock<IMessageService>();
		//	var controller = new HomeController(mockHomeService.Object, mockMessageService.Object);
		//	var mockPager = new Pager(10, 1, 10);
		//	var mockDataStatistics = new DataStatisticsViewModel();
		//	var mockNewsPreview = new List<NewsPreviewViewModel>();

		//	var homePageView = new HomePageViewModel { CurrentPage = 0 }; // Adjusted

		//	mockHomeService.Setup(repo => repo.GetNewsCountAsync())
		//				   .ReturnsAsync(10);
		//	mockHomeService.Setup(repo => repo.GetHomePageDataAsync(It.IsAny<HomePageViewModel>())) // Adjusted
		//				   .ReturnsAsync(new HomePageViewModel
		//				   {
		//					   DataStatistics = mockDataStatistics,
		//					   NewsPreview = mockNewsPreview,
		//					   Pager = mockPager
		//				   });

		//	var result = await controller.HomePage(homePageView);

		//	Assert.IsInstanceOf<ViewResult>(result);
		//	var viewResult = (ViewResult)result;
		//	var model = (HomePageViewModel)viewResult.ViewData.Model;
		//	Assert.AreEqual(1, model.CurrentPage);
		//}



		[Test]
		public void About_ReturnsViewResult()
		{
			var mockHomeService = new Mock<IHomeService>();
			var mockMessageService = new Mock<IMessageService>();
			var controller = new HomeController(mockHomeService.Object, mockMessageService.Object);

			var result = controller.About();

			Assert.IsInstanceOf<ViewResult>(result);
		}

		[Test]
		public void Unauthorized_ReturnsViewResult()
		{
			var mockHomeService = new Mock<IHomeService>();
			var mockMessageService = new Mock<IMessageService>();
			var controller = new HomeController(mockHomeService.Object, mockMessageService.Object);

			var result = controller.Unauthorized();

			Assert.IsInstanceOf<ViewResult>(result);
		}


		[TestCase(404)]
		[TestCase(400)]
		public void Error_With404Or400StatusCode_ReturnsCorrectView(int statusCode)
		{
			var mockHomeService = new Mock<IHomeService>();
			var mockMessageService = new Mock<IMessageService>();
			var controller = new HomeController(mockHomeService.Object, mockMessageService.Object);

			var result = controller.Error(statusCode);

			Assert.IsInstanceOf<ViewResult>(result);
			var viewResult = (ViewResult)result;
			Assert.AreEqual(statusCode == 404 ? "Error404" : "Error404", viewResult.ViewName);
		}

		[Test]
		public void Error_WithNon404Or400StatusCode_ReturnsErrorView()
		{
			var mockHomeService = new Mock<IHomeService>();
			var mockMessageService = new Mock<IMessageService>();
			var controller = new HomeController(mockHomeService.Object, mockMessageService.Object);
			var statusCode = 500;

			var result = controller.Error(statusCode);

			Assert.IsInstanceOf<ViewResult>(result);
			var viewResult = (ViewResult)result;
			Assert.AreEqual("Error", viewResult.ViewName);
		}

	}
}
