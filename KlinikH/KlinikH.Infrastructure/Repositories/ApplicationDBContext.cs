using KlinikH.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace KlinikH.Infrastructure.Repositories
{
    public class ApplicationDBContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }
        public DbSet<AdminAppUser> AdminAppUser { get; set; }
        public DbSet<AppUser> AppUser { get; set; }

        /*protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            //TODO: refactor this more later one but yeah can customize this actually and define each table accordingly

            //NOTE: note auto-incrementing is already set on the identity user after being extended

            //builder.Entity<AdminAppUser>()
            //       .Property(aau => aau.adminId)
            //       .ValueGeneratedOnAdd();

            //builder.Entity<AppUser>()
            //       .Property(au => au.userId)
            //       .ValueGeneratedOnAdd();
        }*/
    }
}
