using BLL.Services.Interfaces;
using Contracts.Models;
using DAL.Repository.Interface;
using System.Linq.Expressions;

namespace BLL.Services
{
    public class StoregeService : IStoregeService<Storege>
    {
        private readonly IAdminRepository<Storege> _storegeRepository;

        public StoregeService(IAdminRepository<Storege> storegeRepository)
        {
            _storegeRepository = storegeRepository;
        }

        public async Task<IEnumerable<Storege>> Find(Expression<Func<Storege, bool>> predicate)
        {
            return await _storegeRepository.Find(predicate);
        }

        public async Task<IEnumerable<Storege>> GetAll()
        {
            return await _storegeRepository.GetAll();
        }

        public async Task<Storege> GetById(int id)
        {
            return await _storegeRepository.GetById(id);
        }

        public async Task Add(Storege storege)
        {
            await _storegeRepository.Add(storege);
        }

        public async Task Update(Storege storege)
        {
            await _storegeRepository.Update(storege);
        }

        public async Task Delete(int id)
        {
            var entity = _storegeRepository.GetById(id);
            if (entity == null)
            {
                throw new ArgumentException("Entity with specified ID not found.");
            }
            await _storegeRepository.Delete(await entity);
        }
    }
}
