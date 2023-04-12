using DeepLearn.Contracts.LessonsStructs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeepLearn.BLL.Interfaces.LessonsStructs
{
    public interface IAnswerService
    {
        Task<IEnumerable<Answer>> GetAll();
        Task<Answer> GetById(int id);
        Task<int> Add(Answer answer);
        Task Update(Answer answer);
        Task Delete(Answer answer);
    }
}
