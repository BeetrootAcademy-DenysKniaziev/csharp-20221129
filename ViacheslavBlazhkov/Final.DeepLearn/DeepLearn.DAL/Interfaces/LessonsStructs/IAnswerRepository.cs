using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeepLearn.Contracts.LessonsStructs;

namespace DeepLearn.DAL.Interfaces.LessonsStructs
{
    public interface IAnswerRepository
    {
        Task<IEnumerable<Answer>> GetAll();
        Task<Answer> GetById(int id);
        Task<int> Add(Answer answer);
        Task Update(Answer answer);
        Task Delete(Answer answer);
    }
}
