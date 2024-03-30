using System.ComponentModel.DataAnnotations;

namespace Xcelerate.Infrastructure.Data.Models
{
	public class News
	{
		[Key]
		public int NewsId { get; set; }

		public string Title { get; set; }

		public string Content { get; set; }
	}
}
