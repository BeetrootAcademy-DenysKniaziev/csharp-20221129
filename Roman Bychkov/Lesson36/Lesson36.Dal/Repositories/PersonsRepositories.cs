

namespace Lesson36.Dal.Repositories
{
    public class PersonRepositories : IPersonsRepository
    {
        private ApplicationDbContext _context;
        public PersonRepositories(ApplicationDbContext context)
        {
            _context = context;
        }

        public async void Add(Person person)
        {
           await _context.Persons.AddAsync(person);
           await _context.SaveChangesAsync();
        }

        public async void Delete(Person person)
        {
            _context.Persons.Remove(person);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Person>> Get()
        {
            return await _context.Persons.ToListAsync();
        }

        public async Task<Person> GetById(int id)
        {
            return await _context.Persons.SingleOrDefaultAsync(p => p.Id == id);
        }

        public async void Update(Person person)
        {
            _context.Persons.Update(person);
            await _context.SaveChangesAsync();
        }
    }
}
