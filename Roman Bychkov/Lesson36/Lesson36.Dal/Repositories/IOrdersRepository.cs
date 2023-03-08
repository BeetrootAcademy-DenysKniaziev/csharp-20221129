namespace Lesson36.Dal
{
    public interface IOrdersRepository
    {
        public void Add(Order person);
        public void Update(Order person);
        public void Delete(Order person);
        public IEnumerable<Order> Get();
        public Order GetById(int id);
    }
}
