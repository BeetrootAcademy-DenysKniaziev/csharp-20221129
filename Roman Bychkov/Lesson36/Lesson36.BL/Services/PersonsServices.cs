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
        public async Task Add(Person person)
        {
            if (string.IsNullOrWhiteSpace(person.FirstName))
                throw new ArgumentException("Invalid person first name");
            if (string.IsNullOrWhiteSpace(person.LastName))
                throw new ArgumentException("Invalid person last name");
            if (person.Age <= 16)
                throw new ArgumentException("Invalid person age");
            if(string.IsNullOrWhiteSpace(person.Gender))
                throw new ArgumentException("Invalid person gender");
            if (string.IsNullOrWhiteSpace(person.Address))
                throw new ArgumentException("Invalid person adress");
            await _personsRepository.Add(person);
        }

        public async Task Delete(Person person)
        {
            if (person is null)
                throw new ArgumentNullException("Person does not exist");
            await _personsRepository.Delete(person);
        }

        public async Task<IEnumerable<Person>> Get()
        {
            return await _personsRepository.Get();
        }

        public async Task<Person> GetById(int id)
        {
            return await _personsRepository.GetById(id);
        }

        public async Task Update(Person person, int id)
        {
            var updatePerson = await GetById(id);
            if (updatePerson is null)
                throw new ArgumentNullException("Person does not exist");
            else
            {
                updatePerson.FirstName = person.FirstName ?? updatePerson.FirstName;
                updatePerson.LastName = person.LastName ?? updatePerson.LastName;
                updatePerson.Age = person.Age < 16 ? updatePerson.Age : person.Age;
                updatePerson.Gender = person.Gender ?? updatePerson.Gender;
                updatePerson.Address = person.Address ?? updatePerson.Address;
            }
            await _personsRepository.Update(updatePerson);
        }
    }
}
