
namespace LearningSystem.DAL.Interfaces
{
    public interface ICoursesRepository : IRepository<Course>
    {
        public Task<Course> GetByIdAsync(int id, List<string> includeNodes);
        public Task<IEnumerable<Course>> GetAllAsync(List<string> includeNodes);
    }
}
