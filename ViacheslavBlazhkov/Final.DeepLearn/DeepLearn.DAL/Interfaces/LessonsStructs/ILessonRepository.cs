using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeepLearn.Contracts.LessonsStructs;

namespace DeepLearn.DAL.Interfaces.LessonsStructs
{
    public interface ILessonRepository
    {
        Task<IEnumerable<Lesson>> GetAll();
        Task<Lesson> GetById(int id);
        Task<int> Add(Lesson lesson);
        Task Update(Lesson lesson);
        Task Delete(Lesson lesson);
    }
}
