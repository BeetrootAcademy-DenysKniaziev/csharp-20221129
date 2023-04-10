using Microsoft.EntityFrameworkCore;

namespace LearningSystem.DAL.Repositories
{
    public class LikeCommentRepository : ILikeCommentRepository
    {
        private ApplicationDbContext _context;
        public LikeCommentRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(LikeComment item)
        {
            await _context.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(LikeComment item)
        {
            _context.Remove(item);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<LikeComment>> GetAsync()
        {
            return await _context.LikeComments.ToListAsync();
        }

        public async Task<LikeComment> GetByIdAsync(int id)
        {
            return await _context.LikeComments.SingleOrDefaultAsync(a => a.Id == id);
        }
    }
}
