
using Microsoft.AspNetCore.Http;

namespace LearningSystem.BLL.Interfaces
{
    public interface ICoursesService
    {
        public  Task AddAsync(Course item, IFormFile file);
        public  Task DeleteAsync(Course item);
        public  Task UpdateAsync(Course item);
        public Task<string> AddImage(int id, IFormFile file);


        public Task<Course> GetByIdAsync(int id);
        public Task<Course> GetByIdUserIncludesAsync(int id);
        public Task<Course> GetByIdUserArticleIncludesAsync(int id);
        public Task<Course> GetByIdAllIncludesAsync(int id);
      
        

        public Task<IEnumerable<Course>> GetAllWithUserAsync();
        public Task<IEnumerable<Course>> GetAllAsync();

    }
}

