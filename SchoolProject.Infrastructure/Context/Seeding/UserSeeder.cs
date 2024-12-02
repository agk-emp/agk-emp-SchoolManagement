using Microsoft.AspNetCore.Identity;
using SchoolProject.Data.Entities.Identity;

namespace SchoolProject.Infrastructure.Context.Seeding
{
    public static class UserSeeder
    {
        public static async Task Seed(UserManager<User> userManager)
        {
            if (!userManager.Users.Any())
            {
                var defaultuser = new User()
                {
                    UserName = "malik",
                    Email = "malik@gmail.com",
                    FullName = "schoolProject",
                    Country = "Egypt",
                    PhoneNumber = "123456",
                    Address = "Egypt",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true
                };
                await userManager.CreateAsync(defaultuser, "Malik_1234567");
                await userManager.AddToRoleAsync(defaultuser, "admin");
            }
        }
    }
}
