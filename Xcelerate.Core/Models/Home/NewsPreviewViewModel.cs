using System.ComponentModel.DataAnnotations;
using static Xcelerate.Common.EntityValidation.NewsEntity;


namespace Xcelerate.Core.Models.Home
{
	public class NewsPreviewViewModel
	{
		public int NewsId { get; set; }

		[Required(ErrorMessage = "Title is required.")]
		[StringLength(TitleMaxLength, ErrorMessage = "Title must be between {2} and {1} characters.", MinimumLength = TitleMinLength)]
		public string Title { get; set; }

		[Required(ErrorMessage = "Content is required.")]
		[StringLength(ContentMaxLength, ErrorMessage = "Title must be between {2} and {1} characters.", MinimumLength = ContentMinLength)]
		public string Content { get; set; }
	}
}
