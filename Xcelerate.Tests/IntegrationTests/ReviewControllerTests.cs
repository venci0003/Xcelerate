using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Moq;
using System.Security.Claims;
using Xcelerate.Controllers;
using Xcelerate.Core.Contracts;
using Xcelerate.Core.Models.Review;

namespace Xcelerate.Tests.IntegrationTests
{
	[TestFixture]
	public class ReviewControllerTests
	{
		private ReviewController _controller;
		private Mock<IReviewService> _reviewServiceMock;
		private Mock<IMemoryCache> _memoryCacheMock;

		[SetUp]
		public void Setup()
		{
			_reviewServiceMock = new Mock<IReviewService>();
			_memoryCacheMock = new Mock<IMemoryCache>();
			_controller = new ReviewController(_reviewServiceMock.Object, _memoryCacheMock.Object);
		}

		[Test]
		public async Task Edit_WithNullReviewId_ReturnsNotFound()
		{
			int? reviewId = null;

			var result = await _controller.Edit(reviewId);

			Assert.IsInstanceOf<NotFoundResult>(result);
		}

		[Test]
		public async Task Edit_WithValidReviewId_ReturnsViewResult()
		{
			int reviewId = 1;
			var editReviewViewModel = new EditReviewViewModel();

			_reviewServiceMock.Setup(service => service.GetEditInformationAsync(reviewId))
							  .ReturnsAsync(editReviewViewModel);

			var result = await _controller.Edit(reviewId);

			Assert.IsInstanceOf<ViewResult>(result);
		}
		[Test]
		public async Task Add_ReturnsRedirectToActionResult()
		{
			var reviewViewModel = new ReviewViewModel();
			var adId = 1;

			var claims = new Claim[] { new Claim(ClaimTypes.NameIdentifier, "047FA4E6-7CEF-47F2-87AC-B91E546F7B72") };
			var identity = new ClaimsIdentity(claims);
			var claimsPrincipal = new ClaimsPrincipal(identity);
			_controller.ControllerContext = new ControllerContext { HttpContext = new DefaultHttpContext { User = claimsPrincipal } };

			var result = await _controller.Add(reviewViewModel, adId);

			Assert.IsInstanceOf<RedirectToActionResult>(result);
		}


		[Test]
		public async Task Edit_RedirectsToAdInformation()
		{
			int adId = 1;
			var reviewViewModel = new EditReviewViewModel();

			var result = await _controller.Edit(reviewViewModel, adId);

			Assert.IsNotNull(result);
			Assert.IsInstanceOf<RedirectToActionResult>(result);

			var redirectResult = (RedirectToActionResult)result;
			Assert.AreEqual("Information", redirectResult.ActionName);
			Assert.AreEqual("Ad", redirectResult.ControllerName); 
			Assert.AreEqual(adId, redirectResult.RouteValues["adId"]);
		}





		[Test]
		public async Task Edit_WithValidReviewIdAndNullViewModel_ReturnsViewResult()
		{
			int reviewId = 1;
			EditReviewViewModel viewModel = null;

			_reviewServiceMock.Setup(service => service.GetEditInformationAsync(reviewId))
							  .ReturnsAsync(viewModel);

			var result = await _controller.Edit(reviewId);

			Assert.IsInstanceOf<ViewResult>(result);
		}

		[Test]
		public async Task Edit_WithInvalidReviewId_ReturnsViewResult()
		{
			int? reviewId = 0;

			var result = await _controller.Edit(reviewId);

			Assert.IsInstanceOf<ViewResult>(result);
		}
	}
}
