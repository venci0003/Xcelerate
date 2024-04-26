using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Xcelerate.Infrastructure.Data.Models;

namespace Xcelerate.Infrastructure.Data.Configurations
{
	public class MessageEntityConfiguration : IEntityTypeConfiguration<Message>
	{
		public void Configure(EntityTypeBuilder<Message> builder)
		{
			builder
				.HasOne(c => c.User)
				.WithMany(c => c.Messages)
				.OnDelete(DeleteBehavior.NoAction);

		}
	}
}
