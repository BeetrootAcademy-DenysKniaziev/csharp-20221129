

using Microsoft.EntityFrameworkCore;

namespace LearningSystem.DAL.Repositories
{
    public class LikeArcticleRepository:ILikeArticleRepistory
    {
        private ApplicationDbContext _context;
        public LikeArcticleRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(LikeArticle item)
        {
            await _context.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(LikeArticle item)
        {
            _context.Remove(item);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<LikeArticle>> GetAsync()
        {
            return await _context.LikeArticles.ToListAsync();
        }

        public async Task<LikeArticle> GetByIdAsync(int id)
        {
            return await _context.LikeArticles.SingleOrDefaultAsync(a => a.Id == id);
        }
    }
}
