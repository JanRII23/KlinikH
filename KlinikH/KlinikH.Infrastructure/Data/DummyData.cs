using KlinikH.Domain.Entities;
using KlinikH.Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

namespace KlinikH.Infrastructure.Data
{
    //TODO: this is seeding the DB with users but remove before merging
    public class DummyData
    {
        public static async Task Initialize(ApplicationDBContext context, UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            //TODO: update this dummyData 
            context.Database.EnsureCreated();

            string adminId1 = "";
            string adminId2 = "";

            string role1 = "Admin";
            string desc1 = "This is the administrator role";

            string role2 = "Member";
            string desc2 = "This is the member role";

            string password = "P@$$w0rd";

            if (await roleManager.FindByNameAsync(role1) == null)
            {
                await roleManager.CreateAsync(new AppRole(role1, desc1, DateTime.Now));
            }

            if (await roleManager.FindByNameAsync(role2) == null)
            {
                await roleManager.CreateAsync(new AppRole(role2, desc2, DateTime.Now));
            }

            if (await userManager.FindByNameAsync("testuser.aa") == null)
            {
                var user = new AppUser
                {
                    UserName = "testuser.aa",
                    Email = "testuseraa@gmail.com"
                };

                var result = await userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    await userManager.AddPasswordAsync(user, password);
                    await userManager.AddToRoleAsync(user, role1);
                }
                adminId1 = user.Id;
            }

            if (await userManager.FindByNameAsync("testuser.bb") == null)
            {
                var user = new AppUser
                {
                    UserName = "testuser.bb",
                    Email = "testuserbb@gmail.com"
                };

                var result = await userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    await userManager.AddPasswordAsync(user, password);
                    await userManager.AddToRoleAsync(user, role2);
                }
                adminId2 = user.Id;
            }
        }
    }
}
