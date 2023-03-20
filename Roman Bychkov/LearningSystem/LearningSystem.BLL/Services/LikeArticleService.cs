namespace LearningSystem.BLL.Services
{
    public class LikeArticleService : ILikeArticleService
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

        public async Task<LikeArticle> LikeExistInArticle(Article article, User user)
        {
            return await _context.LikeExistInArticle(article, user);
        }
    }
}
