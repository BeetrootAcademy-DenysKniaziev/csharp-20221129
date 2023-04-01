using LearningSystem.DAL.Repositories;

namespace LearningSystem.BLL.Services
{
    public class LikeArticleService : ILikeArticleService
    {
        private ILikeArticleRepository _context;
        private IUsersRepository _usersRepository;
        private IArticlesRepository _articlesService;
        public LikeArticleService(ILikeArticleRepository context, IArticlesRepository articlesRepository, IUsersRepository usersRepository)
        {
            _context = context;
            _usersRepository = usersRepository;
            _articlesService = articlesRepository;
        }
        public async Task AddAsync(LikeArticle item)
        {
            if(item is null)
                throw new ArgumentNullException("item");
            if (await _usersRepository.GetByIdAsync(item.UserId) is null)
                throw new ArgumentNullException(nameof(item.UserId));
            if (await _articlesService.GetByIdAsync(item.ArticleId) is null)
                throw new ArgumentNullException(nameof(item.ArticleId));

            await _context.AddAsync(item);
        }

        public async Task DeleteAsync(LikeArticle item)
        {
            if (item is null)
                throw new ArgumentNullException("item");

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
