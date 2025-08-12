
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace KlinikH.Domain.Entities
{
    /// <summary>
    /// DB Entity representation of a standard Application User (NOT ADMIN)
    /// </summary>
    public class AppUser : IdentityUser
    {
        //public int userId { get; set; }
        //public string username { get; set; } = string.Empty;
        public string password { get; set; } = string.Empty;
        public string firstname { get; set; } = string.Empty;
        public string lastname { get; set; } = string.Empty;
        //public string email { get; set; } = string.Empty;
        public DateTime lastLogin { get; set; }
        public DateTime createdOn { get; set; }
        public bool isLockedOut { get; set; }
    }
}
