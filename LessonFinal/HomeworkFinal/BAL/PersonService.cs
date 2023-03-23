using BAL.Interfaces;
using Contracts;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BAL.Services
{
    public class PersonService : IPersonService
    {
        private readonly IRepository<Person> _personRepository;

        public PersonService(IRepository<Person> personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task AddPersonAsync(Person person)
        {
            await _personRepository.AddAsync(person);
        }

        public async Task<Person> GetPersonByEmailAsync(string email)
        {
            return await _personRepository.SingleOrDefaultAsync(p => p.Email == email);
        }

        public async Task<IEnumerable<Person>> GetAllPeopleAsync()
        {
            return await _personRepository.GetAllAsync();
        }

        public async Task UpdatePersonAsync(Person person)
        {
            await _personRepository.UpdateAsync(person);
        }

        public async Task DeletePersonAsync(Person person)
        {
            _personRepository.Remove(person);
        }

        public async Task<Person> GetPersonByIdAsync(int id)
        {
            return await _personRepository.GetByIdAsync(id);
        }
    }
}
