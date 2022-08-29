using System;
using InventoryAPI.Data.Configuration;
using InventoryAPI.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace InventoryAPI.Data
{
	public class InventoryDbContext : IdentityDbContext<User>
	{
		public InventoryDbContext(DbContextOptions<InventoryDbContext> options) : base(options)
		{
		}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new EventConfiguration());
            builder.ApplyConfiguration(new RoleConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new UserRoleConfiguration());
        }

        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
    }

    public class InventoryDbContextFactory : IDesignTimeDbContextFactory<InventoryDbContext>
    {
        public InventoryDbContext CreateDbContext(string[] args)
        {
            // Get environment
            //string environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            // Build config
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            // Get connection string
            var optionsBuilder = new DbContextOptionsBuilder<InventoryDbContext>();
            var connectionString = config.GetConnectionString("ManagementToolDbConnection");
            optionsBuilder.UseSqlServer(connectionString);
            return new InventoryDbContext(optionsBuilder.Options);
        }
    }
}

