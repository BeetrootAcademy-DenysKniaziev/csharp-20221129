using Contracts;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Interfaces
{
    public interface IPersonService
    {
        Task AddPersonAsync(Person person);
        Task<Person> GetPersonByIdAsync(int id);
        Task<IEnumerable<Person>> GetAllPeopleAsync();
        Task UpdatePersonAsync(Person person);
        Task DeletePersonAsync(Person person);
        Task<Person> GetPersonByEmailAsync(string email);

        //Task AddPersonAsync(IRepository<Person> person);
        //Task<IRepository<Person>> GetPersonByIdAsync(int id);
        //Task<IEnumerable<IRepository<Person>>> GetAllPeopleAsync();
        //Task UpdatePersonAsync(IRepository<Person> person);
        //Task DeletePersonAsync(IRepository<Person> person);
        //bool PersonExists(int id);
    }
}
