
namespace LearningSystem.BLL.Services
{
    public class ArticlesService : IArcticlesService
    {
        private IArticlesRepository _context;
        public ArticlesService(IArticlesRepository context)
        {
            _context = context;
        }
        public async Task AddAsync(Article item)
        {
            if (item is null)
                throw new ArgumentNullException("item");
            if (string.IsNullOrWhiteSpace(item.ArcticleName) || item.ArcticleName.Length > 50 || item.ArcticleName.Length < 3)
                throw new ArgumentException("Invalid Name Article");
            if (string.IsNullOrWhiteSpace(item.Content) || item.Content.Length > 10000)
                throw new ArgumentException("Invalid Content");
            await _context.AddAsync(item);
        }

        public async Task DeleteAsync(Article item)
        {
            if(item is null)
                throw new ArgumentNullException("item");
            await _context.DeleteAsync(item);
        }

        public async Task<IEnumerable<Article>> GetAsync()
        {
            return await _context.GetAsync();
        }

        public async Task<Article> GetByIdAsync(int id)
        {
            return await _context.GetByIdAsync(id);
        }

        public async Task<Article> GetByNumber(int number, int courseId)
        {
            return await _context.GetByNumber(number, courseId);
        }

        public async Task UpdateAsync(Article item)
        {
            if (item is null)
                throw new ArgumentNullException("item");
            if (string.IsNullOrWhiteSpace(item.ArcticleName) || item.ArcticleName.Length > 50 || item.ArcticleName.Length < 3)
                throw new ArgumentException("Invalid Name Article");
            if (string.IsNullOrWhiteSpace(item.Content) || item.Content.Length > 10000)
                throw new ArgumentException("Invalid Content");
            await _context.UpdateAsync(item);
        }
    }
}
