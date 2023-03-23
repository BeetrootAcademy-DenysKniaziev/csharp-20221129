using Lesson36.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lesson36.Dal.Repositories
{
    public interface IPersonRepository : IDisposable
    {
        Task<IEnumerable<Person>> GetAll();

        Task<Person> GetById(int id);

        Task<int> Add(Person person);

        Task Update(Person person);

        Task Delete(Person person);
    }
}
