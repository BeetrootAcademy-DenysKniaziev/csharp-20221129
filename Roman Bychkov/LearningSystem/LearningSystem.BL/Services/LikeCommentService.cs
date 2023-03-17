
namespace LearningSystem.BL.Services
{
    public class LikeCommentService : ILikeCommentService
    {
        private ILikeCommentService _context;
        public LikeCommentService(ILikeCommentService context)
        {
            _context = context;
        }
        public async Task AddAsync(LikeComment item)
        {
            await _context.AddAsync(item);
        }

        public async Task DeleteAsync(LikeComment item)
        {
            await _context.DeleteAsync(item);
        }

        public async Task<IEnumerable<LikeComment>> GetAsync()
        {
            return await _context.GetAsync();
        }

        public async Task<LikeComment> GetByIdAsync(int id)
        {
            return await _context.GetByIdAsync(id);
        }
    }
}
