using BLL.Services.Interfaces;
using Contracts.Models;
using DAL.Repository;
using DAL.Repository.Interface;
using System.Linq.Expressions;

namespace BLL.Services
{
    public class CourierService : ICourierService<Сourier>
    {
        private readonly ICourierRepository<Сourier> _courierRepository;

        public CourierService(ICourierRepository<Сourier> courierRepository)
        {
            _courierRepository = courierRepository;
        }

        public async Task<Сourier> GetByUserNameAsync(string userName)
        {
            return await _courierRepository.GetByUserNameAsync(userName);
        }
        public async Task<int> RegisterAsync(Сourier user)
        {
            return await _courierRepository.RegisterAsync(user);
        }

        public async Task<IEnumerable<Сourier>> Find(Expression<Func<Сourier, bool>> predicate)
        {
            return await _courierRepository.Find(predicate);
        }

        public async Task<IEnumerable<Сourier>> GetAll()
        {
            return await _courierRepository.GetAll();
        }

        public async Task<Сourier> GetById(int id)
        {
            return await _courierRepository.GetById(id);
        }

        public async Task Add(Сourier courier)
        {
            await _courierRepository.Add(courier);
        }

        public async Task Update(Сourier courier)
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
