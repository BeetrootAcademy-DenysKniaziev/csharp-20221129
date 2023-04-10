namespace LearningSystem.DAL.Repositories
{
    public class CommentsRepository:AbstractRepository<Comment>,ICommentsRepository
    {
        public CommentsRepository(ApplicationDbContext context) : base(context)
        { }
    }
}
