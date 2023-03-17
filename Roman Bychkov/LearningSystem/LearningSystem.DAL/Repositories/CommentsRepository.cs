namespace LearningSystem.DAL.Repositories
{
    public class CommentsRepository:AbstractRepository<Comment>
    {
        public CommentsRepository(ApplicationDbContext context) : base(context)
        { }
    }
}
