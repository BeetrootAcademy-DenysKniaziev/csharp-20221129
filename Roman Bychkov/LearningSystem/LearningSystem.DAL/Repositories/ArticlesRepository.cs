
namespace LearningSystem.DAL.Repositories
{
    public class ArticlesRepository:AbstractRepository<Article>,IArticlesRepository
    {
        public ArticlesRepository(ApplicationDbContext context) : base(context)
        { }
    }
}
