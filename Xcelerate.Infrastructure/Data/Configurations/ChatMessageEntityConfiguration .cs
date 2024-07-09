using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Xcelerate.Infrastructure.Data.Models;

namespace Xcelerate.Infrastructure.Data.Configurations
{
	public class ChatMessageEntityConfiguration : IEntityTypeConfiguration<ChatMessage>
	{
		public void Configure(EntityTypeBuilder<ChatMessage> builder)
		{
			builder.HasOne(cm => cm.Session)
				.WithMany(cs => cs.ChatMessages)
				.HasForeignKey(cm => cm.SessionId)
				.OnDelete(DeleteBehavior.Cascade); 


		}
	}
}
