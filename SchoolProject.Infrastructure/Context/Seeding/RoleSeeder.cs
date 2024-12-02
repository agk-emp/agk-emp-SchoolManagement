using Microsoft.AspNetCore.Identity;
using SchoolProject.Data.Entities.Identity;

namespace SchoolProject.Infrastructure.Context.Seeding
{
    public static class RoleSeeder
    {
        public static async Task Seed(RoleManager<Role> roleManager)
        {
            if (!roleManager.Roles.Any())
            {
                await roleManager.CreateAsync(new Role()
                {
                    Name = "admin",
                });
                await roleManager.CreateAsync(new Role()
                {
                    Name = "user",
                });
            }
        }
    }
}
