

using Lesson36.Dal.Repositories;

namespace Lesson36.BL.Services
{
    public class OrdersServices : IOrdersServices
    {
        private IOrdersRepository _ordersRepository;
        public OrdersServices(IOrdersRepository rep)
        {
            _ordersRepository = rep;
        }
        public void Add(Order order)
        {
            _ordersRepository.Add(order);
        }

        public void Delete(Order order)
        {
            _ordersRepository.Delete(order);
        }

        public async Task<IEnumerable<Order>> Get()
        {
           return await _ordersRepository.Get();
        }

        public async Task<Order> GetById(int id)
        {
           return await _ordersRepository.GetById(id);
        }

        public void Update(Order order)
        {
            _ordersRepository.Update(order);
        }
    }
}
