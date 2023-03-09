

using Lesson36.Dal.Repositories;

namespace Lesson36.BL.Services
{
    public class OrdersServices : IOrdersServices
    {
        private IOrdersRepository _ordersRepository;
        private IPersonsRepository _personsRepository;
        private IProductsRepository _productsRepository;
        public OrdersServices(IOrdersRepository rep, IProductsRepository productsRep, IPersonsRepository personsRep)
        {
            _personsRepository = personsRep;
            _productsRepository = productsRep;
            _ordersRepository = rep;
        }
        public async Task Add(Order order)
        {
            if (await _productsRepository.GetById(order.ProductId) is null)
                throw new ArgumentNullException("Required product identifier does not exist");
            if (await _personsRepository.GetById(order.PersonId) is null)
                throw new ArgumentNullException("Required person identifier does not exist");
            await _ordersRepository.Add(order);
        }

        public async Task Delete(Order order)
        {
            if (order is null)
                throw new ArgumentNullException("Order does not exist");
            await _ordersRepository.Delete(order);
        }

        public async Task<IEnumerable<Order>> Get()
        {
            return await _ordersRepository.Get();
        }

        public async Task<Order> GetById(int id)
        {
            return await _ordersRepository.GetById(id);
        }

        public async Task Update(Order order, int id)
        {
            var updateOrder = await _ordersRepository.GetById(id);
            if (updateOrder is null)
                throw new ArgumentNullException("Order does not exist");

            updateOrder.ProductId = order.ProductId <= 0 ? updateOrder.ProductId : order.ProductId;
            updateOrder.PersonId = order.PersonId <= 0 ? updateOrder.PersonId : order.PersonId;
            updateOrder.OrderTime = order.OrderTime == DateTime.MinValue ? updateOrder.OrderTime : order.OrderTime;

            if (await _productsRepository.GetById(order.ProductId) is null)
                throw new ArgumentNullException("Required product identifier does not exist");
            if (await _personsRepository.GetById(order.PersonId) is null)
                throw new ArgumentNullException("Required person identifier does not exist");

            await _ordersRepository.Update(updateOrder);
        }
    }
}
