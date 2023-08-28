using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace PrimeNumber.Repository.Seeds
{
    public static class SeedData
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

 
            if (!await roleManager.RoleExistsAsync("admin"))
            {
             
                await roleManager.CreateAsync(new IdentityRole("admin"));
            }

         
            if (await userManager.FindByEmailAsync("admin@example.com") == null)
            {
             
                var adminUser = new IdentityUser
                {
                    UserName = "admin@example.com",
                    Email = "admin@example.com"
                };
                await userManager.CreateAsync(adminUser, "Admin.35");

                
                await userManager.AddToRoleAsync(adminUser, "admin");
            }
        }
    }
}
