
using KlinikH.Application.Services.Interfaces;
using KlinikH.Domain.Entities;
using KlinikH.Domain.Enums.AppUser;
using KlinikH.Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace KlinikH.Application.Services
{
    public class DbInitializerService : DbInitializerInterface
    {
        //TODO: need to write data seeding for admin type users too
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly ApplicationDBContext _context;

        public DbInitializerService(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, ApplicationDBContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
        }

        public async Task Initialize()
        {
            try
            {
                if (_context.Database.GetPendingMigrations().Count() > 0)
                {
                    _context.Database.Migrate();
                }
            }
            catch (Exception)
            {
                throw;
            }

            var userName = "Charizard";
            var email = "Charizard@gmail.com";
            var password = "itsP@$$w0rd123";

            if (!_roleManager.RoleExistsAsync(AppUserRoleTypes.User).GetAwaiter().GetResult())
            {
                var newUserRole = new AppRole(AppUserRoleTypes.User, "Standard User", DateTime.Now);

                var createdRole = await _roleManager.CreateAsync(newUserRole);

                if (createdRole.Errors.Any())
                {
                    foreach (var error in createdRole.Errors)
                    {
                        Console.WriteLine(error.Description);
                    }
                }
            }

            var AppUser = _context.AppUser.FirstOrDefault(x => x.UserName == "Charizard");

            if (AppUser == null)
            {
                var newUser = new AppUser
                {
                    UserName = userName,
                    Email = email,
                };

                var createdUser = await _userManager.CreateAsync(newUser, password);

                if (createdUser.Succeeded)
                {
                    await _userManager.AddToRoleAsync(newUser, AppUserRoleTypes.User);
                } else
                {
                    foreach (var error in createdUser.Errors)
                    {
                        Console.WriteLine(error.Description);
                    }
                }
            }
            else if (!(await _userManager.IsInRoleAsync(AppUser, AppUserRoleTypes.User)))
            {
                _userManager.AddToRoleAsync(AppUser, AppUserRoleTypes.User).GetAwaiter().GetResult();
            }
            
        }
    }
}
