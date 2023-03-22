using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

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
                 .SingleOrDefaultAsync(c => c.Id == id);
        }

        public override async Task<IEnumerable<Course>> GetAsync()
        {
            return await _context.Courses.Include(c => c.Articles).ToListAsync();
        }
    }
}
