using KlinikH.Domain.Entities;

namespace KlinikH.Application
{
    public class AppUserViewModel
    {
        public string firstname { get; set; } = string.Empty;
        public string lastname { get; set; } = string.Empty;
        //public string email { get; set; } = string.Empty;

        public AppUserViewModel() { }

        public AppUserViewModel(AppUser user)
        {
            firstname = user.Firstname;
            lastname = user.Lastname;
            //email = user.email;
        }

        public AppUser ConvertViewModelToModel(AppUser user)
        {
            return new AppUser
            {
                Firstname = user.Firstname,
                Lastname = user.Lastname,
                //email = email,
            };
        }
    }
}
