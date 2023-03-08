namespace Lesson36.BL.Services
{
    public interface IOrdersServices
    {
        public void Add(Order order);
        public void Update(Order order);
        public void Delete(Order order);
        public Task<IEnumerable<Order>> Get();
        public Task<Order> GetById(int id);
    }
}
