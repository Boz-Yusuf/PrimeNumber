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

            // Rollerin var olup olmadığını kontrol et
            if (!await roleManager.RoleExistsAsync("admin"))
            {
                // "admin" rolünü oluştur
                await roleManager.CreateAsync(new IdentityRole("admin"));
            }

            // Admin kullanıcısını var olup olmadığını kontrol et
            if (await userManager.FindByEmailAsync("admin@example.com") == null)
            {
                // Admin kullanıcısını oluştur
                var adminUser = new IdentityUser
                {
                    UserName = "admin@example.com",
                    Email = "admin@example.com"
                };
                await userManager.CreateAsync(adminUser, "Admin.35");
                //var result = await _userManager.CreateAsync(user, password);

                // Admin kullanıcısına "admin" rolünü ata
                await userManager.AddToRoleAsync(adminUser, "admin");
            }
        }
    }
}
