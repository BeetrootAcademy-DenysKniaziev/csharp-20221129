
using Microsoft.EntityFrameworkCore;

namespace LearningSystem.DAL.Repositories
{
    public class ArticlesRepository : AbstractRepository<Article>, IArticlesRepository
    {
        private ApplicationDbContext _context;
        public ArticlesRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Article>> GetByCourseId(int courseId)
        {
            var result = _context?.Articles?.Where(a => a.CourseId == courseId);
            return await result?.ToListAsync();
        }

        public async Task<Article> GetByNumberAsync(int number, int courseId)
        {
            return await _context?.Articles.SingleOrDefaultAsync(a => a.Number == number && a.CourseId == courseId);
        }
    }
}
