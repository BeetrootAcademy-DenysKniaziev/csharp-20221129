namespace LearningSystem.BL.Services
{
    public class CommentsService:ICommentsService
    {
        private ICommentsRepository _context;
        public CommentsService(ICommentsRepository context)
        {
            _context = context;
        }
        public async Task AddAsync(Comment item)
        {
            await _context.AddAsync(item);
        }

        public async Task DeleteAsync(Comment item)
        {
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
            await _context.UpdateAsync(item);
        }
    }
}
