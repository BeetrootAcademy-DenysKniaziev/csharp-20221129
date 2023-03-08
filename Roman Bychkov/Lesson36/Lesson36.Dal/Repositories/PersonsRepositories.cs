
namespace Lesson36.Dal.Repositories
{
    public class PersonsRepositories : IPersonsRepository
    {
        private ApplicationDbContext _context;
        public PersonsRepositories(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Add(Person person)
        {
           await _context.Persons.AddAsync(person);
           await _context.SaveChangesAsync();
        }

        public async Task Delete(Person person)
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

        public async Task Update(Person person)
        {
            _context.Persons.Update(person);
            await _context.SaveChangesAsync();
        }
    }
}
