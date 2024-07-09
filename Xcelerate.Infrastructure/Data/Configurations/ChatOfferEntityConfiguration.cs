using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Xcelerate.Infrastructure.Data.Models;

namespace Xcelerate.Infrastructure.Data.Configurations
{
	public class ChatOfferEntityConfiguration : IEntityTypeConfiguration<ChatOffer>
	{
		public void Configure(EntityTypeBuilder<ChatOffer> builder)
		{
			builder.HasOne(co => co.Session)
				.WithMany(cs => cs.ChatOffers)
				.HasForeignKey(co => co.SessionId)
				.OnDelete(DeleteBehavior.Cascade);
		}
	}
}
