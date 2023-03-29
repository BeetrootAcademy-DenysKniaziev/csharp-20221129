using BLL.Services.Interfaces;
using Contracts.Models;
using DAL.Repository.Interface;
using System.Linq.Expressions;

namespace BLL.Services
{
    public class OrderService : IOrderService<Order>
    {
        private readonly IOrderRepository<Order> _orderRepository;

        public OrderService(IOrderRepository<Order> orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<IEnumerable<Order>> Find(Expression<Func<Order, bool>> predicate)
        {
            return await _orderRepository.Find(predicate);
        }

        public async Task<IEnumerable<Order>> GetAll()
        {
            return await _orderRepository.GetAll();
        }

        public async Task<Order> GetById(int orderId)
        {
            return await _orderRepository.GetById(orderId);
        }

        public async Task Add(Order order)
        {
            await _orderRepository.Add(order);
        }

        public async Task Update(Order order)
        {
            await _orderRepository.Update(order);
        }

        public async Task Delete(int id)
        {
            var entity = _orderRepository.GetById(id);
            if (entity == null)
            {
                throw new ArgumentException("Entity with specified ID not found.");
            }
            await _orderRepository.Delete(await entity);
        }
    }
}
