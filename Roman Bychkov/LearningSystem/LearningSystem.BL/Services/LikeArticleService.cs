namespace LearningSystem.BL.Services
{
    public class LikeArticleService
    {
        private ILikeArticleRepository _context;
        public LikeArticleService(ILikeArticleRepository context)
        {
            _context = context;
        }
        public async Task AddAsync(LikeArticle item)
        {
            await _context.AddAsync(item);
        }

        public async Task DeleteAsync(LikeArticle item)
        {
            await _context.DeleteAsync(item);
        }

        public async Task<IEnumerable<LikeArticle>> GetAsync()
        {
            return await _context.GetAsync();
        }

        public async Task<LikeArticle> GetByIdAsync(int id)
        {
            return await _context.GetByIdAsync(id);
        }
    }
}
