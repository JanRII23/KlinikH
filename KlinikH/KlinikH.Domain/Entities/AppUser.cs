
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace KlinikH.Domain.Entities
{
    /// <summary>
    /// DB Entity representation of a standard Application User (NOT ADMIN)
    /// </summary>
    public class AppUser : IdentityUser
    {
        public AppUser()
        {
            CreatedOn = DateTime.Now;
        }

        public string Firstname { get; set; } = string.Empty;
        public string Lastname { get; set; } = string.Empty;
        public DateTime LastLogin { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool IsLockedOut { get; set; }

        //TODO: note once pivoting to admin workflows need to setup an ENUM type for regular user, admin user
        //TODO: or I think this is already mapped to the userRoles table somehow?
    }
}
