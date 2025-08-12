using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace KlinikH.Domain.Entities
{
    /// <summary>
    /// DB Entity representation of a Admin Application User (NOT Standard User)
    /// </summary>
    public class AdminAppUser : IdentityUser
    {
        //public int adminId {  get; set; }
        //public string username { get; set; } = string.Empty;
        public string password { get; set; } = string.Empty;
        public string firstname { get; set; } = string.Empty;
        public string lastname { get; set; } = string.Empty;
        //public string email { get; set; } = string.Empty;
        public DateTime lastLogin { get; set; }
        public DateTime createdOn { get; set; } = DateTime.Now;
        public bool isLockedOut { get; set; }
    }
}
