
namespace LearningSystem.DAL.Interfaces
{
    public interface ICoursesRepository : IRepository<Course>
    {
        public Task<Course> GetByIdAsync(int id, List<string> includeNodes);
    }
}
