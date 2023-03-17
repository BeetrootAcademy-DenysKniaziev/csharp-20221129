
namespace LearningSystem.DAL.Interfaces
{
    public interface ILikeCommentRepository
    {
        public Task AddAsync(LikeComment item);
        public Task DeleteAsync(LikeComment item);
        public Task<IEnumerable<LikeComment>> GetAsync();
        public Task<LikeComment> GetByIdAsync(int id);
    }
}
