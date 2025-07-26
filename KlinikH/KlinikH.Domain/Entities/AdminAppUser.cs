using Microsoft.AspNetCore.Identity;

namespace KlinikH.Domain.Entities
{
    /// <summary>
    /// DB Entity representation of a Admin Application User (NOT Standard User)
    /// </summary>
    public class AdminAppUser : IdentityUser
    {
        public string username { get; set; } = string.Empty;
        public string password { get; set; } = string.Empty;
        public string firstname { get; set; } = string.Empty;
        public string lastname { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        public DateTime lastLogin { get; set; }
        public DateTime createdOn { get; set; }
        public bool isLockedOut { get; set; }
    }
}
