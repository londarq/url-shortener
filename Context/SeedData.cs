//using Microsoft.AspNetCore.Identity;
//using url_shortener.Models;

//namespace url_shortener.Context
//{
//    public class SeedData : IHostedService
//    {
//        private readonly RoleManager<IdentityRole> _roleManager;
//        private readonly UserManager<User> _userManager;
//        private readonly ApplicationContext _context;

//        public SeedData(RoleManager<IdentityRole> roleManager, UserManager<User> userManager, ApplicationContext context)
//        {
//            _roleManager = roleManager;
//            _userManager = userManager;
//            _context = context;
//        }

//        public async Task SeedAsync()
//        {
//            _context.Database.EnsureCreated();

//            var roles = new List<IdentityRole>
//            {
//                new IdentityRole { Name = "Admin" },
//                new IdentityRole { Name = "User" }
//            };

//            foreach (var role in roles)
//            {
//                if (!await _roleManager.RoleExistsAsync(role.Name))
//                {
//                    await _roleManager.CreateAsync(role);
//                }
//            }

//            // Create admin user
//            var adminUser = new User
//            {
//                Login = "Admin"
//            };

//            var adminPassword = "Password123!";

//            if (await _userManager.FindByEmailAsync(adminUser.Email) == null)
//            {
//                var result = await _userManager.CreateAsync(adminUser, adminPassword);

//                if (result.Succeeded)
//                {
//                    await _userManager.AddToRoleAsync(adminUser, "Admin");
//                    await _userManager.AddToRoleAsync(adminUser, "User");
//                }
//            }

//            // Create regular user
//            var regularUser = new User
//            {
//                Login = "User"
//            };

//            var regularPassword = "Password123!";

//            if (await _userManager.FindByEmailAsync(regularUser.Email) == null)
//            {
//                var result = await _userManager.CreateAsync(regularUser, regularPassword);

//                if (result.Succeeded)
//                {
//                    await _userManager.AddToRoleAsync(regularUser, "User");
//                }
//            }

//            // Create URLs
//            var urls = new List<Url>
//            {
//                //new Url { TargetUrl = "https://google.com", ShortUrl = "1", User = adminUser },
//                //new Url { TargetUrl = "https://inforce.digital/", ShortUrl = "2", User = regularUser },
//                //new Url { TargetUrl = "https://stackoverflow.com", ShortUrl = "3", User = regularUser }
//            };

//            await _context.Urls.AddRangeAsync(urls);
//            await _context.SaveChangesAsync();
//        }

//        public async Task StartAsync(CancellationToken cancellationToken)
//        {
//            await SeedAsync();
//        }

//        public Task StopAsync(CancellationToken cancellationToken)
//        {
//            return Task.CompletedTask;
//        }
//    }
//}
