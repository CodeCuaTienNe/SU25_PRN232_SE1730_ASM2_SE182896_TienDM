using DNATestingSystem.Repository.TienDM;
using DNATestingSystem.Repository.TienDM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNATestingSystem.Services.TienDM
{
    public class AppointmentStatusesTienDmService : IAppointmentStatusesTienDmService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AppointmentStatusesTienDmService(IUnitOfWork unitOfWork)
            => _unitOfWork = unitOfWork;

        public async Task<List<AppointmentStatusesTienDm>> GetAllAsync()
        {
            return await _unitOfWork.AppointmentStatusesTienDmRepository.GetAllAsync();
        }

        public async Task<AppointmentStatusesTienDm> GetByIdAsync(int id)
        {
            return await _unitOfWork.AppointmentStatusesTienDmRepository.GetByIdAsync(id);
        }

        public async Task<List<AppointmentStatusesTienDm>> GetActiveStatusesAsync()
        {
            return await _unitOfWork.AppointmentStatusesTienDmRepository.GetActiveStatusesAsync();
        }

        public async Task<List<AppointmentStatusesTienDm>> SearchAsync(int id, string statusName)
        {
            return await _unitOfWork.AppointmentStatusesTienDmRepository.SearchAsync(id, statusName ?? "");
        }

        public async Task<int> CreateAsync(AppointmentStatusesTienDm entity)
        {
            return await _unitOfWork.AppointmentStatusesTienDmRepository.CreateAsync(entity);
        }

        public async Task<int> UpdateAsync(AppointmentStatusesTienDm entity)
        {
            return await _unitOfWork.AppointmentStatusesTienDmRepository.UpdateAsync(entity);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _unitOfWork.AppointmentStatusesTienDmRepository.DeleteAsync(id);
        }
    }
}
