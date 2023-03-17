
namespace LearningSystem.DAL.Repositories
{
    public class ArticlesRepository:AbstractRepository<Article>
    {
        public ArticlesRepository(ApplicationDbContext context) : base(context)
        { }
    }
}
