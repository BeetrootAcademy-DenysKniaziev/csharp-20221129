using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeepLearn.BLL.Interfaces.LessonsStructs;
using DeepLearn.Contracts.LessonsStructs;
using DeepLearn.DAL.Interfaces.LessonsStructs;

namespace DeepLearn.BLL.Services.LessonsStructs
{
    public class CourseService : ICourseService
    {
        private ICourseRepository _courseRepository { get; }

        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<IEnumerable<Course>> GetAll() => await _courseRepository.GetAll();

        public async Task<Course> GetById(int id) => await _courseRepository.GetById(id);

        public async Task<int> Add(Course course) => await _courseRepository.Add(course);

        public async Task Update(Course course) => await _courseRepository.Update(course);

        public async Task Delete(Course course) => await _courseRepository.Delete(course);
    }
}
