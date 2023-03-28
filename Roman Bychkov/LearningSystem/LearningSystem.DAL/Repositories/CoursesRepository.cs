using Microsoft.EntityFrameworkCore;

namespace LearningSystem.DAL.Repositories
{
    public class CoursesRepository : AbstractRepository<Course>, ICoursesRepository
    {

        public CoursesRepository(ApplicationDbContext context) : base(context)
        { }
        public override async Task<Course> GetByIdAsync(int id) //Func<ISet<Course>, Course> del
        {
            return await _context.Courses
                 .Include(c => c.Articles)
                     .ThenInclude(a => a.Likes)
                 .Include(c => c.Articles)
                     .ThenInclude(a => a.Comments)
                     .ThenInclude(a => a.User)
                  .Include(c=>c.User)
                 .SingleOrDefaultAsync(c => c.Id == id);
        }
        public async Task<Course> GetByIdAsync(int id, List<string> includeNodes) //Func<ISet<Course>, Course> del
        {
            var context = _context.Courses;
            foreach (var includeNode in includeNodes)
            {
                context.Include(includeNode);
            }
            return await _context.Courses.SingleOrDefaultAsync(c => c.Id == id);
        }

        public override async Task<IEnumerable<Course>> GetAsync()
        {
            return await _context.Courses.Include(c => c.Articles).Include(c=>c.User).ToListAsync();
        }
    }
}
