

namespace Lesson36.Dal.Repositories
{
    public interface IPersonsRepository
    {
        public void Add(Person person);
        public void Update(Person person);
        public void Delete(Person person);
        public Task<IEnumerable<Person>> Get();
        public Task<Person> GetById(int id);
    }
}
