using DJValeting.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DJValeting.Data
{
    public class ApplicationDbContext : IdentityDbContext<UserEntity>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<BookingEntity> Bookings { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            SeedUsers(builder);
            SeedRoles(builder);
            SeedUserRoles(builder);
        }

        private void SeedUsers(ModelBuilder builder)
        {
            var hasher = new PasswordHasher<IdentityUser>();

            UserEntity user = new UserEntity()
            {
                Id = "4d0bbfd3-299f-461f-88e1-15106c318251",
                UserName = "admin@demo.com",
                Email = "admin@demo.com",
                EmailConfirmed = true,
                NormalizedEmail = "admin@demo.com",
                NormalizedUserName = "admin@demo.com",
                PasswordHash = hasher.HashPassword(null, "Admin@444")
            };

            builder.Entity<UserEntity>().HasData(user);
        }

        private void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole() { Id = "d15168d5-7f8e-440c-866a-efe2a3440329", Name = "Admin", ConcurrencyStamp = "1", NormalizedName = "Admin" }
                );
        }

        private void SeedUserRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>() { RoleId = "d15168d5-7f8e-440c-866a-efe2a3440329", UserId = "4d0bbfd3-299f-461f-88e1-15106c318251" }
                );
        }
    }
}
