
using Microsoft.AspNetCore.Http;

namespace LearningSystem.BLL.Interfaces
{
    public interface ICoursesService
    {
        public  Task AddAsync(Course item, IFormFile file);
        public  Task DeleteAsync(Course item);
        public  Task<IEnumerable<Course>> GetAsync();
        public  Task<Course> GetByIdAsync(int id);
        public  Task UpdateAsync(Course item);
        public Task<string> AddImage(int id, IFormFile file);
        public Task<bool> VerifiyUserCourse(int userId, int courseId);
    }
}
//< input type = "file" id = "profile-photo-input" name = "file" style = "display: none;" accept = "image/*"
