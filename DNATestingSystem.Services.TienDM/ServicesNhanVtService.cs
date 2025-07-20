using DNATestingSystem.Repository.TienDM;
using DNATestingSystem.Repository.TienDM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNATestingSystem.Services.TienDM
{
    public class ServicesNhanVtService : IServicesNhanVtService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ServicesNhanVtService(IUnitOfWork unitOfWork)
            => _unitOfWork = unitOfWork;

        public async Task<List<ServicesNhanVt>> GetAllAsync()
        {
            return await _unitOfWork.ServicesNhanVtRepository.GetAllAsync();
        }

        public async Task<ServicesNhanVt> GetByIdAsync(int id)
        {
            return await _unitOfWork.ServicesNhanVtRepository.GetByIdAsync(id);
        }

        public async Task<List<ServicesNhanVt>> GetActiveServicesAsync()
        {
            return await _unitOfWork.ServicesNhanVtRepository.GetActiveServicesAsync();
        }

        public async Task<List<ServicesNhanVt>> SearchAsync(int id, string serviceName)
        {
            return await _unitOfWork.ServicesNhanVtRepository.SearchAsync(id, serviceName ?? "");
        }

        public async Task<int> CreateAsync(ServicesNhanVt entity)
        {
            return await _unitOfWork.ServicesNhanVtRepository.CreateAsync(entity);
        }

        public async Task<int> UpdateAsync(ServicesNhanVt entity)
        {
            return await _unitOfWork.ServicesNhanVtRepository.UpdateAsync(entity);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _unitOfWork.ServicesNhanVtRepository.DeleteAsync(id);
        }
    }
}
