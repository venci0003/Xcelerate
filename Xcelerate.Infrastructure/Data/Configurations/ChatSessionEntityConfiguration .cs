using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Xcelerate.Infrastructure.Data.Models;

namespace Xcelerate.Infrastructure.Data.Configurations
{
	public class ChatSessionEntityConfiguration : IEntityTypeConfiguration<ChatSession>
	{
		public void Configure(EntityTypeBuilder<ChatSession> builder)
		{
			builder.HasOne(cs => cs.Buyer)
			  .WithMany()
			  .HasForeignKey(cs => cs.BuyerId)
			  .OnDelete(DeleteBehavior.NoAction);

			builder.HasOne(cs => cs.Seller)
				.WithMany()
				.HasForeignKey(cs => cs.SellerId)
				.OnDelete(DeleteBehavior.NoAction);

			builder.HasMany(cs => cs.ChatMessages)
				.WithOne(cm => cm.Session)
				.HasForeignKey(cm => cm.SessionId)
				.OnDelete(DeleteBehavior.NoAction);

			builder.HasMany(cs => cs.ChatOffers)
				.WithOne(co => co.Session)
				.HasForeignKey(co => co.SessionId)
				.OnDelete(DeleteBehavior.Cascade);

			builder.HasOne(cs => cs.Ad)
				   .WithMany(ad => ad.ChatSessions)
				   .HasForeignKey(cs => cs.AdId)
				   .OnDelete(DeleteBehavior.Cascade);
		}
	}
}
