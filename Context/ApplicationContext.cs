using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using url_shortener.Models;

namespace url_shortener.Context
{
    public class ApplicationContext : IdentityDbContext
    {
        public DbSet<Url> Urls { get; set; }
        public DbSet<About> Description { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = "dec2a85e-3612-4b81-b3fe-310dc4e2ecf8", Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole { Id = "567622b0-bba7-4734-9648-6a47e133a48c", Name = "User", NormalizedName = "USER" }
            );

            var adminUser = new IdentityUser
            {
                Id = "ccd1772b-7962-4803-a18a-2526dc41430d",
                NormalizedUserName = "ADMIN",
                UserName = "admin"
            };

            var regularUser = new IdentityUser
            {
                Id = "a9a95ad9-4487-455a-8c3c-77836f06c110",
                NormalizedUserName = "USER",
                UserName = "user"                
            };

            var passwordHasher = new PasswordHasher<IdentityUser>();
            adminUser.PasswordHash = passwordHasher.HashPassword(adminUser, "Admin@123");
            regularUser.PasswordHash = passwordHasher.HashPassword(regularUser, "User@123");

            modelBuilder.Entity<IdentityUser>().HasData(adminUser, regularUser);

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "dec2a85e-3612-4b81-b3fe-310dc4e2ecf8",
                UserId = "ccd1772b-7962-4803-a18a-2526dc41430d"
            },
            new IdentityUserRole<string>
            {
                RoleId = "567622b0-bba7-4734-9648-6a47e133a48c",
                UserId = "ccd1772b-7962-4803-a18a-2526dc41430d"
            },
            new IdentityUserRole<string>
            {
                RoleId = "567622b0-bba7-4734-9648-6a47e133a48c",
                UserId = "a9a95ad9-4487-455a-8c3c-77836f06c110"
            });

            modelBuilder.Entity<Url>().HasData(
                new Url { Id = 1, TargetUrl = "https://google.com", ShortUrl = "1", UserName = adminUser.UserName },
                new Url { Id = 2, TargetUrl = "https://inforce.digital/", ShortUrl = "2", UserName = regularUser.UserName },
                new Url { Id = 3, TargetUrl = "https://stackoverflow.com", ShortUrl = "3", UserName = regularUser.UserName }
            );

            modelBuilder.Entity<About>().HasData(
                new About { Id = 1, Description = "This is the default description" }
            ); 
        }
    }
}
