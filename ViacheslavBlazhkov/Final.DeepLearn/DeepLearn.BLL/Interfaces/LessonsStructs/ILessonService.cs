using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeepLearn.Contracts.LessonsStructs;

namespace DeepLearn.BLL.Interfaces.LessonsStructs
{
    public interface ILessonService
    {
        Task<IEnumerable<Lesson>> GetAll();
        Task<Lesson> GetById(int id);
        Task<int> Add(Lesson lesson);
        Task Update(Lesson lesson);
        Task Delete(Lesson lesson);
    }
}
