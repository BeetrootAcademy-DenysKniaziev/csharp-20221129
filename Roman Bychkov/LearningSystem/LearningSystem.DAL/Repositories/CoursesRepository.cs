namespace LearningSystem.DAL.Repositories
{
    public class CoursesRepository:AbstractRepository<Course>
    {
        public CoursesRepository(ApplicationDbContext context) : base(context)
        { }
    }
}
