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
    public class LessonService : ILessonService
    {
        private ILessonRepository _lessonRepository { get; }

        public LessonService(ILessonRepository lessonRepository)
        {
            _lessonRepository = lessonRepository;
        }

        public async Task<IEnumerable<Lesson>> GetAll() => await _lessonRepository.GetAll();

        public async Task<Lesson> GetById(int id) => await _lessonRepository.GetById(id);

        public async Task<int> Add(Lesson lesson) => await _lessonRepository.Add(lesson);

        public async Task Update(Lesson lesson) => await _lessonRepository.Update(lesson);

        public async Task Delete(Lesson lesson) => await _lessonRepository.Delete(lesson);
    }
}
