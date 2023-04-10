using Microsoft.EntityFrameworkCore;

namespace LearningSystem.DAL.Repositories
{
    public class CoursesRepository : AbstractRepository<Course>, ICoursesRepository
    {

        public CoursesRepository(ApplicationDbContext context) : base(context)
        { }
        public override async Task<Course> GetByIdAsync(int id)
        {
            return await _context.Courses.SingleOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Course>> GetAllAsync(List<string> includeNodes)
        {
            var context = _context.Courses.Include(includeNodes[0]);
            for (int i = 1; i < includeNodes.Count; i++)
            {
                context = context.Include(includeNodes[i]);
            }
            return await context.ToListAsync();
        }
        public async Task<Course> GetByIdAsync(int id, List<string> includeNodes) 
        {
            var context = _context.Courses.Include(includeNodes[0]);
            for (int i = 1; i < includeNodes.Count; i++)
            {
                context = context.Include(includeNodes[i]);
            }
            return await context.SingleOrDefaultAsync(c => c.Id == id);
        }

      
    }
}
