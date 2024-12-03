using System.Reflection.Emit;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StockTalk.Entities.Models;

namespace StockTalk.Infrastructure.Data_Access
{
    public class ApplicationDBContext : IdentityDbContext<User>
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> dbContextOptions) : base(dbContextOptions)
        {
        }

        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Comment> Comments { get; set; }  // Corrected the typo here
        public DbSet<StockUser> StockUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Configure many-to-many relationship using StockUser
            builder.Entity<StockUser>()
                .HasOne(su => su.Stock)
                .WithMany(s => s.StockUsers)
                .HasForeignKey(su => su.StockId);

            builder.Entity<StockUser>()
                .HasOne(su => su.User)
                .WithMany(u => u.StockUsers)
                .HasForeignKey(su => su.UserId);

            // Configure the Identity schema as needed (optional)
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = "1", Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole { Id = "2", Name = "User", NormalizedName = "USER" }
            );
            builder.Entity<User>().ToTable("Users");
        }
    }
 }
