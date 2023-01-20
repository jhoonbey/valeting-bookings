using DJValeting.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Linq;

namespace DJValeting.Data
{
    public class DbContextSeedData
    {
        private ApplicationDbContext _context;

        public DbContextSeedData(ApplicationDbContext context)
        {
            _context = context;
        }

        public async void SeedAdminUser()
        {
            var user = new UserEntity
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "Admin@demo.com",
                NormalizedUserName = "Admin@demo.com",
                Email = "Admin@demo.com",
                NormalizedEmail = "Admin@demo.com",
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            var roleStore = new RoleStore<IdentityRole>(_context);

            if (!_context.Roles.Any(r => r.Name == "admin"))
            {
                await roleStore.CreateAsync(new IdentityRole { Id = Guid.NewGuid().ToString(), Name = "admin", NormalizedName = "admin" });
            }

            if (!_context.Users.Any(u => u.UserName == user.UserName))
            {
                var password = new PasswordHasher<UserEntity>();
                var hashed = password.HashPassword(user, "Admin@444");
                user.PasswordHash = hashed;
                var userStore = new UserStore<UserEntity>(_context);
                await userStore.CreateAsync(user);
                await userStore.AddToRoleAsync(user, "admin");
            }

            await _context.SaveChangesAsync();
        }
    }
}
