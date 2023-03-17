namespace LearningSystem.BL.Services
{
    public class ArticlesUser : IArticlesService
    {
        private IArticlesRepository _context;
        public ArticlesUser(IArticlesRepository context)
        {
            _context = context;
        }
        public async Task AddAsync(Article item)
        {
            await _context.AddAsync(item);
        }

        public async Task DeleteAsync(Article item)
        {
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

        public async Task UpdateAsync(Article item)
        {
            await _context.UpdateAsync(item);
        }
    }
}
