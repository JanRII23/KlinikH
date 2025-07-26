using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital.Admin.AdminUserBundle.Models
{
    public class AdminUser : IdentityUser
    {
        public string username { get; set; }
        public string password { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string email { get; set; }
        public DateTime lastLogin { get; set; }
        public DateTime createdOn { get; set; }

        //TODO: think about other potential entities needed for the adminUser

        //TODO: also think about migrating aftewards on this once hooking it up + squash commits
    }
}
