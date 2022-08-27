using System;
using InventoryAPI.Data.Configuration;
using InventoryAPI.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace InventoryAPI.Data
{
	public class InventoryDbContext : IdentityDbContext
	{
		public InventoryDbContext(DbContextOptions<InventoryDbContext> options) : base(options)
		{
		}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new EventConfiguration());
            builder.ApplyConfiguration(new UserRoleConfiguration());
        }

        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
    }
}

