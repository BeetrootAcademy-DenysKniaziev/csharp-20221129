using Lesson36.Dal.Repositories;

namespace Lesson36.BL.Services
{
    public class PersonsServices : IPersonsServices
    {
        private IPersonsRepository _personsRepository;
        public PersonsServices(IPersonsRepository rep)
        {
            _personsRepository = rep;
        }
        public void Add(Person person)
        {
            _personsRepository.Add(person);
        }

        public void Delete(Person person)
        {
             _personsRepository.Delete(person);
        }

        public async Task<IEnumerable<Person>> Get()
        {
            return await _personsRepository.Get();
        }

        public async Task<Person> GetById(int id)
        {
            return await _personsRepository.GetById(id);
        }

        public void Update(Person person)
        {
            _personsRepository.Update(person);
        }
    }
}
