namespace AutoXen.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using AutoXen.Common;
    using AutoXen.Data.Common.Repositories;
    using AutoXen.Data.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;

    internal class AdminSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            await SeedAdminAsync(roleManager, "admin@admin.admin");
            await SeedAdminAsync(roleManager, "admin2@admin.admin");
        }

        private static async Task SeedAdminAsync(UserManager<ApplicationUser> userManager, string username)
        {
            var user = await userManager.FindByNameAsync(username);

            if (user == null)
            {
                var newUser = new ApplicationUser()
                {
                    UserName = username,
                    Email = username,
                    Address = "unknown",
                    FirstName = "Admin",
                    MiddleName = string.Empty,
                    SurName = string.Empty,
                    CreatedOn = DateTime.UtcNow,
                };

                var result = await userManager.CreateAsync(newUser);

                await userManager.AddPasswordAsync(newUser, username);
                await userManager.AddToRoleAsync(newUser, GlobalConstants.AdministratorRoleName);

                if (!result.Succeeded)
                {
                    throw new Exception(string.Join(Environment.NewLine, result.Errors.Select(e => e.Description)));
                }
            }
        }
    }
}
