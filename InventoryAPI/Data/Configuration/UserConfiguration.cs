using InventoryAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventoryAPI.Data.Configuration
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            var hasher = new PasswordHasher<User>();

            builder.HasData(
                new User
                {
                    Id = "a8113fe9-7cee-432c-bc30-fc91cbf56ff6",
                    Email = "admin@localhost.com",
                    NormalizedEmail = "ADMIN@LOCALHOST.COM",
                    UserName = "Admin",
                    NormalizedUserName = "ADMIN",
                    FirstName = "Administrator",
                    LastName = "Admin",
                    PasswordHash = hasher.HashPassword(null, "Password1"),
                    EmailConfirmed = true
                },
                new User
                {
                    Id = "a001f060-5fe2-488b-a199-60cf373f761a",
                    Email = "user@localhost.com",
                    NormalizedEmail = "USER@LOCALHOST.COM",
                    UserName = "user",
                    NormalizedUserName = "USER",
                    FirstName = "Obiora",
                    LastName = "Nwude",
                    PasswordHash = hasher.HashPassword(null, "Password1"),
                    EmailConfirmed = true
                }
            ); 
        }
    }
}

