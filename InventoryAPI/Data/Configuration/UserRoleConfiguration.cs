using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventoryAPI.Data.Configuration
{
    internal class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "5e1bfb55-3421-474d-b06c-f5137f4e7072",
                    UserId = "a8113fe9-7cee-432c-bc30-fc91cbf56ff6"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "b8efb1bf-d355-4058-9d5e-3073b4a0b1f3",
                    UserId = "a001f060-5fe2-488b-a199-60cf373f761a"
                }
            );
        }
    }
}

