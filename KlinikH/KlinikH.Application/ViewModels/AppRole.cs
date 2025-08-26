using Microsoft.AspNetCore.Identity;

namespace KlinikH.Application.ViewModels
{
    public class AppRole : IdentityRole
    {
        //TODO: does this need to be defined as an entity?
        public AppRole() : base() { }

        public AppRole(string roleName) : base(roleName) { }

        public AppRole(string roleName, string description, DateTime creationDate) : base (roleName)
        {
            this.Description = description;
            this.CreationDate = creationDate;
        }

        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
