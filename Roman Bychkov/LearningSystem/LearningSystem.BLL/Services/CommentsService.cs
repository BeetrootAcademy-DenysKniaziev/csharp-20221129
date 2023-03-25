namespace LearningSystem.BLL.Services
{
    public class CommentsService : ICommentsService
    {
        private ICommentsRepository _context;
        public CommentsService(ICommentsRepository context)
        {
            _context = context;
        }
        public async Task AddAsync(Comment item)
        {
            if (item is null)
                throw new ArgumentNullException("comment");
            if (string.IsNullOrWhiteSpace(item.Content) || item.Content.Length > 250 || item.Content.Length == 0)
                throw new ArgumentException("Invalid length of comment");
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
            return await _context.GetAsync();
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
            await _context.UpdateAsync(item);
        }
    }
}
