using DNATestingSystem.Repository.TienDM.Models;
using DNATestingSystem.Repository.TienDM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNATestingSystem.Services.TienDM
{
    public class SystemUserAccountService : ISystemUserAccountService
    {
        private readonly IUnitOfWork _unitOfWork;
        public SystemUserAccountService(IUnitOfWork unitOfWork)
            => _unitOfWork = unitOfWork;


        public Task<SystemUserAccount?> GetUserAccount(string userName, string password)
        {
            return _unitOfWork.UserAccountRepository.GetUserAccount(userName, password);
        }


        public Task<SystemUserAccount?> GetUserAccountById(int userId)
        {
            return _unitOfWork.UserAccountRepository.GetUserAccountById(userId);
        }


        public async Task<List<SystemUserAccount>> GetAllAsync()
        {
            return await _unitOfWork.UserAccountRepository.GetAllAsync();
        }


        public async Task<int> CreateAsync(SystemUserAccount userAccount)
        {
            return await _unitOfWork.UserAccountRepository.CreateAsync(userAccount);
        }


        public async Task<int> UpdateAsync(SystemUserAccount userAccount)
        {
            return await _unitOfWork.UserAccountRepository.UpdateAsync(userAccount);
        }


        public async Task<bool> DeleteAsync(int id)
        {
            return await _unitOfWork.UserAccountRepository.DeleteAsync(id);
        }
    }
}
