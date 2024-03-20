using Microsoft.AspNetCore.Identity;
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
	public class UserEntityConfiguration : IEntityTypeConfiguration<User>
	{
		public void Configure(EntityTypeBuilder<User> builder)
		{
			// Table name
			builder.ToTable("Users");

			// Relationships
			builder.HasMany(u => u.Ads)
				.WithOne(ad => ad.User)
				.OnDelete(DeleteBehavior.NoAction);

			builder.HasMany(u => u.Reviews)
				.WithOne(r => r.User)
				.OnDelete(DeleteBehavior.NoAction);

			builder.HasMany(u => u.Cars)
				.WithOne(c => c.User)
				.OnDelete(DeleteBehavior.NoAction);

			ICollection<User> usersCollection = CreateUsers();
			builder.HasData(CreateUsers());
		}

		private ICollection<User> CreateUsers()
		{
			List<User> users = new List<User>();
			PasswordHasher<User> passwordHasher = new PasswordHasher<User>();

			User firstUser = new User()
			{
				Id = Guid.Parse("9ABB04A0-36A0-4A35-8C1A-34D324AA169E"),
				FirstName = "Alice",
				LastName = "Smith",
				Email = "alice.smith@example.com"
			};
			firstUser.PasswordHash = passwordHasher.HashPassword(firstUser, "9vX&3gZ!7qR");
			users.Add(firstUser);

			User secondUser = new User()
			{
				Id = Guid.Parse("2CC5DA14-F51C-4B51-96B3-0C296C2EE8DC"),
				FirstName = "Bob",
				LastName = "Johnson",
				Email = "bob.johnson@example.com"
			};
			secondUser.PasswordHash = passwordHasher.HashPassword(secondUser, "L@8z6#Vc0&Y");
			users.Add(secondUser);

			User thirdUser = new User()
			{
				Id = Guid.Parse("6A31BB92-7EC2-45E3-81A8-912542B314C6"),
				FirstName = "Charlie",
				LastName = "Williams",
				Email = "charlie.williams@example.com"
			};
			thirdUser.PasswordHash = passwordHasher.HashPassword(thirdUser, "T5!u8$Xp6^Z");
			users.Add(thirdUser);

			User fourthUser = new User()
			{
				Id = Guid.Parse("495CC255-9E57-40E1-A4DE-B1ADBFDBC0FC"),
				FirstName = "David",
				LastName = "Brown",
				Email = "david.brown@example.com"
			};
			fourthUser.PasswordHash = passwordHasher.HashPassword(fourthUser, "M3^y7#Bn9*V");
			users.Add(fourthUser);

			User fifthUser = new User()
			{
				Id = Guid.Parse("B0B378DD-78AA-4884-AFA7-7EC6626C9CDF"),
				FirstName = "Eva",
				LastName = "Miller",
				Email = "eva.miller@example.com"
			};
			fifthUser.PasswordHash = passwordHasher.HashPassword(fifthUser, "H6*xC9@F2&L");
			users.Add(fifthUser);

			User sixthUser = new User()
			{
				Id = Guid.Parse("9173EFB3-6DC6-4C27-8D1A-555107353AEA"),
				FirstName = "Frank",
				LastName = "Davis",
				Email = "frank.davis@example.com"
			};
			sixthUser.PasswordHash = passwordHasher.HashPassword(sixthUser, "K8$y4#Bn1^T");
			users.Add(sixthUser);

			User seventhUser = new User()
			{
				Id = Guid.Parse("0C106D5A-7440-44DD-B8D3-3C1B7ACA8020"),
				FirstName = "Grace",
				LastName = "Taylor",
				Email = "grace.taylor@example.com"
			};
			seventhUser.PasswordHash = passwordHasher.HashPassword(seventhUser, "N4!u7$Mj3&Z");
			users.Add(seventhUser);

			User eighthUser = new User()
			{
				Id = Guid.Parse("B4D7DDAD-411E-4FE8-A7D9-C2638F376F1C"),
				FirstName = "Henry",
				LastName = "Clark",
				Email = "henry.clark@example.com"
			};
			eighthUser.PasswordHash = passwordHasher.HashPassword(eighthUser, "P2^y6#Un0*X");
			users.Add(eighthUser);

			User ninthUser = new User()
			{
				Id = Guid.Parse("B13EDF51-1FF3-46D7-BF4C-C55CAAC1A7C0"),
				FirstName = "Ivy",
				LastName = "Walker",
				Email = "ivy.walker@example.com"
			};
			ninthUser.PasswordHash = passwordHasher.HashPassword(ninthUser, "Q1!v5$Rp9&Y");
			users.Add(ninthUser);

			User tenthUser = new User()
			{
				Id = Guid.Parse("1B6F6E67-5ADF-4F78-A74E-27B02430C709"),
				FirstName = "Jack",
				LastName = "Anderson",
				Email = "jack.anderson@example.com"
			};
			tenthUser.PasswordHash = passwordHasher.HashPassword(tenthUser, "S7*xC6@G3&K");
			users.Add(tenthUser);

			return users;
		}

	}
}
