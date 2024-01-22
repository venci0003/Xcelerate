using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xcelerate.Infrastructure.Data.Models;

namespace Xcelerate.Infrastructure.Data.Configurations
{
    public class ReviewEntityConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.HasOne(r => r.User)
                .WithMany(u => u.Reviews)
                .OnDelete(DeleteBehavior.NoAction);

            ICollection<Review> reviewsCollection = CreateReviews();
            builder.HasData(CreateReviews());
        }

        private ICollection<Review> CreateReviews()
        {
            List<Review> reviews = new List<Review>();

            Review reviewOne = new Review()
            {
                ReviewId = 1,
                ReviewsCount = 5,
                Comment = "Good product",
                StarsCount = 4,
                UserId = Guid.Parse("9ABB04A0-36A0-4A35-8C1A-34D324AA169E"), // Assuming you have a user with Id 1
                AdId = 1   // Assuming you have an ad with Id 1
            };

            Review reviewTwo = new Review()
            {
                ReviewId = 2,
                ReviewsCount = 4,
                Comment = "Could be better",
                StarsCount = 3,
                UserId = Guid.Parse("2CC5DA14-F51C-4B51-96B3-0C296C2EE8DC"), // Assuming you have a user with Id 2
                AdId = 2   // Assuming you have an ad with Id 2
            };

            Review reviewThree = new Review()
            {
                ReviewId = 3,
                ReviewsCount = 3,
                Comment = "Not satisfied",
                StarsCount = 2,
                UserId = Guid.Parse("6A31BB92-7EC2-45E3-81A8-912542B314C6"), // Assuming you have a user with Id 3
                AdId = 3   // Assuming you have an ad with Id 3
            };

            Review reviewFour = new Review()
            {
                ReviewId = 4,
                ReviewsCount = 5,
                Comment = "Excellent service",
                StarsCount = 5,
                UserId = Guid.Parse("495CC255-9E57-40E1-A4DE-B1ADBFDBC0FC"), // Assuming you have a user with Id 4
                AdId = 4   // Assuming you have an ad with Id 4
            };

            Review reviewFive = new Review()
            {
                ReviewId = 5,
                ReviewsCount = 4,
                Comment = "Average experience",
                StarsCount = 3,
                UserId = Guid.Parse("B0B378DD-78AA-4884-AFA7-7EC6626C9CDF"), // Assuming you have a user with Id 5
                AdId = 5   // Assuming you have an ad with Id 5
            };

            Review reviewSix = new Review()
            {
                ReviewId = 6,
                ReviewsCount = 5,
                Comment = "Great value for money",
                StarsCount = 4,
                UserId = Guid.Parse("9173EFB3-6DC6-4C27-8D1A-555107353AEA"), // Assuming you have a user with Id 6
                AdId = 6   // Assuming you have an ad with Id 6
            };

            Review reviewSeven = new Review()
            {
                ReviewId = 7,
                ReviewsCount = 3,
                Comment = "Poor quality",
                StarsCount = 2,
                UserId = Guid.Parse("0C106D5A-7440-44DD-B8D3-3C1B7ACA8020"), // Assuming you have a user with Id 7
                AdId = 7   // Assuming you have an ad with Id 7
            };

            Review reviewEight = new Review()
            {
                ReviewId = 8,
                ReviewsCount = 4,
                Comment = "Satisfied overall",
                StarsCount = 4,
                UserId = Guid.Parse("B4D7DDAD-411E-4FE8-A7D9-C2638F376F1C"), // Assuming you have a user with Id 8
                AdId = 8   // Assuming you have an ad with Id 8
            };

            Review reviewNine = new Review()
            {
                ReviewId = 9,
                ReviewsCount = 2,
                Comment = "Disappointing",
                StarsCount = 1,
                UserId = Guid.Parse("B13EDF51-1FF3-46D7-BF4C-C55CAAC1A7C0"), // Assuming you have a user with Id 9
                AdId = 9   // Assuming you have an ad with Id 9
            };

            Review reviewTen = new Review()
            {
                ReviewId = 10,
                ReviewsCount = 5,
                Comment = "Outstanding performance",
                StarsCount = 5,
                UserId = Guid.Parse("1B6F6E67-5ADF-4F78-A74E-27B02430C709"), // Assuming you have a user with Id 10
                AdId = 10    // Assuming you have an ad with Id 10
            };

            reviews.Add(reviewOne);
            reviews.Add(reviewTwo);
            reviews.Add(reviewThree);
            reviews.Add(reviewFour);
            reviews.Add(reviewFive);
            reviews.Add(reviewSix);
            reviews.Add(reviewSeven);
            reviews.Add(reviewEight);
            reviews.Add(reviewNine);
            reviews.Add(reviewTen);

            return reviews;
        }
    }
}
