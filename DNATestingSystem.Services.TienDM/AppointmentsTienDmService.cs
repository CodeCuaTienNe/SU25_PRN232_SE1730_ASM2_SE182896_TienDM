using DNATestingSystem.Repository.TienDM;
using DNATestingSystem.Repository.TienDM.Models;
using DNATestingSystem.Repository.TienDM.ModelExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNATestingSystem.Services.TienDM
{
    public class AppointmentsTienDmService : IAppointmentsTienDmService
    {
        private readonly IUnitOfWork _unitOfWork;
        public AppointmentsTienDmService(IUnitOfWork unitOfWork)
            => _unitOfWork = unitOfWork;

        public async Task<int> CreateAsync(AppointmentsTienDm appointmentsTien)
        {
            return await _unitOfWork.AppointmentsTienDmRepository.CreateAsync(appointmentsTien);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _unitOfWork.AppointmentsTienDmRepository.DeleteAsync(id);
        }
        public async Task<List<AppointmentsTienDm>> GetAllAsync()
        {
            return await _unitOfWork.AppointmentsTienDmRepository.GetAllAsync();
        }
        public async Task<PaginationResult<List<AppointmentsTienDm>>> GetAllPaginatedAsync(int page, int pageSize)
        {
            return await _unitOfWork.AppointmentsTienDmRepository.GetAllPaginatedAsync(page, pageSize) ?? new PaginationResult<List<AppointmentsTienDm>>();
        }

        public async Task<AppointmentsTienDm> GetByIdAsync(int id)
        {
            return await _unitOfWork.AppointmentsTienDmRepository.GetByIdAsync(id);
        }
        public async Task<PaginationResult<List<AppointmentsTienDm>>> SearchAsync(int id, string contactPhone, decimal totalAmount, int page, int pageSize)
        {
            var paginationResult = await _unitOfWork.AppointmentsTienDmRepository.SearchAsync(id, contactPhone, totalAmount, page, pageSize);
            return paginationResult ?? new PaginationResult<List<AppointmentsTienDm>>();
        }

        public async Task<PaginationResult<List<AppointmentsTienDm>>> SearchAsync(SearchAppointmentsTienDm searchRequest)
        {
            var paginationResult = await _unitOfWork.AppointmentsTienDmRepository.SearchAsync(searchRequest);
            return paginationResult ?? new PaginationResult<List<AppointmentsTienDm>>();
        }

        public async Task<int> UpdateAsync(AppointmentsTienDm appointmentsTien)
        {
            return await _unitOfWork.AppointmentsTienDmRepository.UpdateAsync(appointmentsTien);
        }
    }
}
