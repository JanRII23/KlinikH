using KlinikH.Domain.Entities;

namespace KlinikH.Application
{
    public class AppUserViewModel
    {
        public string firstname { get; set; } = string.Empty;
        public string lastname { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;

        public AppUserViewModel() { }

        public AppUserViewModel(AppUser user)
        {
            firstname = user.firstname;
            lastname = user.lastname;
            email = user.email;
        }

        public AppUser ConvertViewModelToModel(AppUser user)
        {
            return new AppUser
            {
                firstname = firstname,
                lastname = lastname,
                email = email,
            };
        }
    }
}
