using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeepLearn.Contracts.LessonsStructs;

namespace DeepLearn.BLL.Interfaces.LessonsStructs
{
    public interface ICourseService
    {
        Task<IEnumerable<Course>> GetAll();
        Task<Course> GetById(int id);
        Task<int> Add(Course course);
        Task Update(Course course);
        Task Delete(Course course);
    }
}
