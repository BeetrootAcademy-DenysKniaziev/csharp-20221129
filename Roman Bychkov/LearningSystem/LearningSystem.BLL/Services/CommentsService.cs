namespace LearningSystem.BLL.Services
{
    public class CommentsService : ICommentsService
    {
        private ICommentsRepository _context;
        private IUsersRepository _usersRepository;
        private IArticlesRepository _articlesService;
        public CommentsService(ICommentsRepository context, IArticlesRepository articlesRepository, IUsersRepository usersRepository)
        {
            _context = context;
            _usersRepository = usersRepository;
            _articlesService = articlesRepository;
        }
        public async Task AddAsync(Comment item)
        {
            if (item is null)
                throw new ArgumentNullException("comment");
            if (string.IsNullOrWhiteSpace(item.Content) || item.Content.Length > 250 || item.Content.Length == 0)
                throw new ArgumentException("Invalid length of comment");
            if (await _usersRepository.GetByIdAsync(item.UserId) is null)
                throw new ArgumentNullException(nameof(item.UserId));
            if (await _articlesService.GetByIdAsync(item.ArticleId) is null)
                throw new ArgumentNullException(nameof(item.ArticleId));
            await _context.AddAsync(item);
        }

        public async Task DeleteAsync(Comment item)
        {
            if (item is null)
                throw new ArgumentNullException("comment");
            await _context.DeleteAsync(item);
        }

        public async Task<IEnumerable<Comment>> GetAsync()
        {
            return await _context.GetAllAsync();
        }

        public async Task<Comment> GetByIdAsync(int id)
        {
            return await _context.GetByIdAsync(id);
        }

        public async Task UpdateAsync(Comment item)
        {
            if (item is null)
                throw new ArgumentNullException("comment");
            if (string.IsNullOrWhiteSpace(item.Content) || item.Content.Length > 250 || item.Content.Length == 0)
                throw new ArgumentException("Invalid length of comment");
            if (await _usersRepository.GetByIdAsync(item.UserId) is null)
                throw new ArgumentNullException(nameof(item.UserId));
            if (await _articlesService.GetByIdAsync(item.ArticleId) is null)
                throw new ArgumentNullException(nameof(item.ArticleId));
            await _context.UpdateAsync(item);
        }
    }
}
