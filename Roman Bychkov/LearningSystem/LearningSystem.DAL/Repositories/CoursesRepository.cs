using Microsoft.EntityFrameworkCore;

namespace LearningSystem.DAL.Repositories
{
    public class CoursesRepository : AbstractRepository<Course>, ICoursesRepository
    {

        public CoursesRepository(ApplicationDbContext context) : base(context)
        { }
        public override async Task<Course> GetByIdAsync(int id)
        {
            return await _context.Courses
         .Include(c => c.Articles)
             .ThenInclude(a => a.Likes)
         .Include(c => c.Articles)
             .ThenInclude(a => a.Comments)
         .SingleOrDefaultAsync(c => c.Id == id);
        }

        public override async Task<IEnumerable<Course>> GetAsync()
        {
            return await _context.Courses.Include(c => c.Articles).ToListAsync();
        }
    }
}
