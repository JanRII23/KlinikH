using KlinikH.Domain.Helpers;

namespace KlinikH.Application.Services.Interfaces
{
    internal interface AppUserServiceInterface
    {
        PagedResult<AppUserViewModel> GetAll(int pageNumber, int pageSize);
    }
}
