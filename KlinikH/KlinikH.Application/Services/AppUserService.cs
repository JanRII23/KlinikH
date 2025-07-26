using KlinikH.Application.Services.Interfaces;
using KlinikH.Domain.Entities;
using KlinikH.Domain.Helpers;
using KlinikH.Infrastructure.Repositories.Interfaces;

namespace KlinikH.Application.Services
{
    public class AppUserService : AppUserServiceInterface
    {
        private UnitOfWorkInterface _unitOfWork;

        public AppUserService(UnitOfWorkInterface unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public PagedResult<AppUserViewModel> GetAll(int pageNumber, int pageSize)
        {
            var vm = new AppUserViewModel();
            int totalCount;
            List<AppUserViewModel> vmList = new List<AppUserViewModel>();
            try
            {
                int excludeRecords = (pageSize * pageNumber) - pageSize;

                var modelList = _unitOfWork.GenericRepository<AppUser>().GetAll()
                    .Skip(excludeRecords).Take(pageSize).ToList();

                totalCount = _unitOfWork.GenericRepository<AppUser>().GetAll().ToList().Count;

                vmList = ConvertModelToViewModelList(modelList);
            }
            catch (Exception)
            {
                throw;
            }
            var result = new PagedResult<AppUserViewModel>
            {
                Data = vmList,
                TotalItems = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
            return result;
        }

        private List<AppUserViewModel> ConvertModelToViewModelList(List<AppUser> modelList)
        {
            return modelList.Select(x => new AppUserViewModel(x)).ToList();
        }
    }
}
