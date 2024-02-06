using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VendingMachine.Models;

namespace VendingMachine.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            SeedRoles(builder);
        }
        private static void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData
                (
                    new IdentityRole() { Name = "Seller", ConcurrencyStamp = "1", NormalizedName = "Seller" },
                    new IdentityRole() { Name = "Buyer", ConcurrencyStamp = "1", NormalizedName = "Buyer" }
                );
        }
        public DbSet<Product> products { get; set; }
    }
}
