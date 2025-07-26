using KlinikH.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace KlinikH.Infrastructure.Repositories
{
    public class ApplicationDBContext : IdentityDbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }
        public DbSet<AdminAppUser> AdminAppUser { get; set; }
        public DbSet<AppUser> AppUser { get; set; }
    }
}
