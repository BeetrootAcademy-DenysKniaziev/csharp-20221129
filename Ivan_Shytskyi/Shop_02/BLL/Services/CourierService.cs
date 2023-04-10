using BLL.Services.Interfaces;
using Contracts.Models;
using DAL.Repository.Interface;
using System.Linq.Expressions;

namespace BLL.Services
{
    public class CourierService : ICourierService
    {
        private readonly ICourierRepository _courierRepository;

        public CourierService(ICourierRepository courierRepository)
        {
            _courierRepository = courierRepository;
        }

        public async Task<Courier> GetByUserNameAsync(string userName)
        {
            return await _courierRepository.GetByUserNameAsync(userName);
        }

        public async Task<IEnumerable<Courier>> Find(Expression<Func<Courier, bool>> predicate)
        {
            return await _courierRepository.Find(predicate);
        }

        public async Task<IEnumerable<Courier>> GetAll()
        {
            return await _courierRepository.GetAll();
        }

        public async Task<Courier> GetById(int id)
        {
            return await _courierRepository.GetById(id);
        }

        public async Task Add(Courier courier)
        {
            await _courierRepository.Add(courier);
        }

        public async Task Update(Courier courier)
        {
            await _courierRepository.Update(courier);
        }

        public async Task Delete(int id)
        {
            var entity = _courierRepository.GetById(id);
            if (entity == null)
            {
                throw new ArgumentException("Entity with specified ID not found.");
            }
            await _courierRepository.Delete(await entity);
        }

        public async Task ConfirmOrderDelivered(int orderId)
        {
            // код для підтвердження отримання посилки
            await _courierRepository.ConfirmOrderDelivered(orderId);
            Console.WriteLine("Посилку з номером відстеження {0} отримано", orderId);
        }

        public async Task ConfirmOrderReceived(int orderId)
        {
            // код для підтвердження передачі посилки
            await _courierRepository.ConfirmOrderReceived(orderId);
            Console.WriteLine("Посилку з номером відстеження {0} передано курєру", orderId);
        }
    }
}
