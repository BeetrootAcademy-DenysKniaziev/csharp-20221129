using Lesson36.Bll.Utils;
using Lesson36.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lesson36.Bll.Services
{
    public interface IPersonService : IDisposable
    {
        Task<IEnumerable<Person>> GetAll();

        Task<Person> GetById(int id);

        Task<OperationResult<int>> Add(Person person);

        Task Update(Person person);

        Task Delete(Person person);
    }
}
