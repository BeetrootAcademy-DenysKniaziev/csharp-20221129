
namespace Lesson36.Dal.Repositories
{
    public class OrdersRepositories:IOrdersRepository
    {
        private ApplicationDbContext _context;
        public OrdersRepositories(ApplicationDbContext context)
        {
            _context = context;
        }

        public async void Add(Order order)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
        }

        public async void Delete(Order order)
        {
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Order>> Get()
        {
            return await _context.Orders.ToListAsync();
        }

        public async Task<Order> GetById(int id)
        {
            return await _context.Orders.SingleOrDefaultAsync(p => p.Id == id);
        }

        public async void Update(Order order)
        {
            _context.Orders.Update(order);
            await _context.SaveChangesAsync();
        }
    }
}
