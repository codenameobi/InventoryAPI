using System;
using InventoryAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventoryAPI.Data.Configuration
{
    internal class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.HasData(
                new Event
                {
                    Id = 1,
                    Title = "Main Event",
                    Description = " "
                },
                new Event
                {
                    Id = 2,
                    Title = "Ladies Nite",
                    Description = " "
                }
            );
        }
    }
}

