using Hospital.Models;
using Hospital.Repositories.Interfaces;
using Hospital.Utilities;
using Hospital.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Services
{
    public class DoctorService : IDoctorService
    {
        private IUnitOfWork _unitOfWork;

        public DoctorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddTiming(TimingViewModel timing)
        {
            var model = new TimingViewModel().ConvertViewModel(timing);
            _unitOfWork.GenericRepository<Timing>().Add(model);
            _unitOfWork.Save();
        }

        public void DeleteTiming(int TimingId)
        {
            var model = _unitOfWork.GenericRepository<Timing>().GetById(TimingId);
            _unitOfWork.GenericRepository<Timing>().Delete(model);
            _unitOfWork.Save();
        }

        public PagedResult<TimingViewModel> GetAll(int pageNumber, int pageSize)
        {
            var vm = new TimingViewModel();
            int totalCount;
            List<TimingViewModel> vmList = new List<TimingViewModel>();
            try
            {
                int excludeRecords = (pageSize * pageNumber) - pageSize;

                var modelList = _unitOfWork.GenericRepository<Timing>().GetAll()
                    .Skip(excludeRecords).Take(pageSize).ToList();

                totalCount = _unitOfWork.GenericRepository<Timing>().GetAll().ToList().Count;

                vmList = ConvertModelToViewModelList(modelList);
            } 
            catch (Exception)
            {
                throw;
            }
            var result = new PagedResult<TimingViewModel>
            {
                Data = vmList,
                TotalItems = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
            return result;
        }

        private List<TimingViewModel> ConvertModelToViewModelList(List<Timing> modelList)
        {
            return modelList.Select(x => new TimingViewModel(x)).ToList();
        }

        public IEnumerable<TimingViewModel> GetAll()
        {
            var TimingList = _unitOfWork.GenericRepository<Timing>().GetAll().ToList();
            var vmList = ConvertModelToViewModelList(TimingList);
            return vmList;
        }

        public TimingViewModel GetTimingById(int TimingId)
        {
            var model = _unitOfWork.GenericRepository<Timing>().GetById(TimingId);
            var vm = new TimingViewModel(model);
            return vm;
        }

        public void UpdateTiming(TimingViewModel timing)
        {
            var model = new TimingViewModel().ConvertViewModel(timing);
            var modelById = _unitOfWork.GenericRepository<Timing>().GetById(model.Id);
            modelById.Id = timing.Id;
            modelById.DoctorId = timing.DoctorId;
            modelById.Status = timing.Status;
            modelById.Duration = timing.Duration;
            modelById.MorningShiftStartTime = timing.MorningShiftStartTime;
            modelById.MorningShiftEndTime = timing.MorningShiftEndTime;
            modelById.AfternoonShiftStartTime = timing.AfternoonShiftStartTime;
            modelById.AfternoonShiftEndTime = timing.AfternoonShiftEndTime;

            _unitOfWork.GenericRepository<Timing>().Update(modelById);
            _unitOfWork.Save();
        }
    }
}
