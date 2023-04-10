using BLL.Services.Interfaces;
using Contracts.Models;
using DAL.Repository.Interface;
using System.Linq.Expressions;

namespace BLL.Services
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _adminRepository;

        public AdminService(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        public async Task<Admin> GetByUserNameAsync(string userName)
        {
            return await _adminRepository.GetByUserNameAsync(userName);
        }

        public async Task<IEnumerable<Admin>> Find(Expression<Func<Admin, bool>> predicate)
        {
            return await _adminRepository.Find(predicate);
        }

        public async Task<IEnumerable<Admin>> GetAll()
        {
            return await _adminRepository.GetAll();
        }

        public async Task<Admin> GetById(int id)
        {
            return await _adminRepository.GetById(id);
        }

        public async Task Add(Admin entity)
        {
            await _adminRepository.Add(entity);
        }

        public async Task Delete(int id)
        {
            var entity = _adminRepository.GetById(id);
            if (entity == null)
            {
                throw new ArgumentException("Entity with specified ID not found.");
            }
            await _adminRepository.Delete(await entity);
        }

        public async Task Update(Admin entity)
        {
            await _adminRepository.Update(entity);
        }
    }
}
