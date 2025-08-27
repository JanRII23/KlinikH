
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
        private UserManager<AppUser> _userManager;
        private RoleManager<AppRole> _roleManager;
        private ApplicationDBContext _context;

        public DbInitializerService(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, ApplicationDBContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
        }

        public void Initialize()
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

            if (!_roleManager.RoleExistsAsync(AppUserRoleTypes.User).GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new AppRole(AppUserRoleTypes.User)).GetAwaiter().GetResult();

                _userManager.CreateAsync(new AppUser
                {
                    UserName = "Charizard",
                    Email = "Charizard@gmail.com"
                }, "P@$$w0rd").GetAwaiter().GetResult();

                var AppUser = _context.AppUser.FirstOrDefault(x => x.UserName == "Charizard");

                if (AppUser != null)
                {
                    _userManager.AddToRoleAsync(AppUser, AppUserRoleTypes.User).GetAwaiter().GetResult();
                }
            }
        }
    }
}
