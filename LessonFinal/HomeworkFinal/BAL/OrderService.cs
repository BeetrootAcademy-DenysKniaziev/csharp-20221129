using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BAL.Interfaces;
using Contracts;
using DAL.Interfaces;

namespace BAL.Services
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<Order> _orderRepository;

        public OrderService(IRepository<Order> orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<IEnumerable<Order>> GetAllOrdersAsync()
        {
            return await _orderRepository.GetAllAsync();
        }

        public async Task<Order> GetOrderByIdAsync(int orderId)
        {
            return await _orderRepository.GetByIdAsync(orderId);
        }

        public async Task<int> CreateOrderAsync(Order order)
        {
            await _orderRepository.AddAsync(order);
            return await _orderRepository.SaveChangesAsync();
        }

        public async Task<int> UpdateOrderAsync(Order order)
        {
            await _orderRepository.UpdateAsync(order);
            return await _orderRepository.SaveChangesAsync();
        }

        public async Task DeleteOrderAsync(int orderId)
        {
            var order = await _orderRepository.GetByIdAsync(orderId);
            _orderRepository.Remove(order);
            //return await _orderRepository.SaveChangesAsync();
        }

        public async Task<bool> OrderExistsAsync(int orderId)
        {
            return await _orderRepository.GetByIdAsync(orderId) != null;
        }
    }
}
