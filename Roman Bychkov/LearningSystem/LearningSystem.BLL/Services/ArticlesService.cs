
namespace LearningSystem.BLL.Services
{
    public class ArticlesService : IArticlesService
    {
        private IArticlesRepository _context;
        private ICoursesRepository _coursesRepository;
        public ArticlesService(IArticlesRepository context, ICoursesRepository coursesRepository)
        {
            _context = context;
            _coursesRepository = coursesRepository;
        }
        public async Task AddAsync(Article item)
        {
            if (item is null)
                throw new ArgumentNullException("item");
            if (string.IsNullOrWhiteSpace(item.ArticleName) || item.ArticleName.Length > 50 || item.ArticleName.Length < 3)
                throw new ArgumentException("Invalid Name Article");
            if (string.IsNullOrWhiteSpace(item.Content) || item.Content.Length > 10000)
                throw new ArgumentException("Invalid Content");
            if(await _coursesRepository.GetByIdAsync(item.CourseId) is null)
                throw new ArgumentNullException(nameof(item.CourseId));

            var articles = (await _context.GetAllAsync()).Where(a => a.CourseId == item?.CourseId);
            var number = articles.MaxBy(a => a.Number) == null ? 1 : articles.MaxBy(a => a.Number)?.Number + 1;

            item.Number = (byte)number;

            await _context.AddAsync(item);
        }

        public async Task DeleteAsync(Article item)
        {
            if (item is null)
                throw new ArgumentNullException("item");
            await _context.DeleteAsync(item);
            var articles = (await _context.GetByCourseId(item.CourseId));
            foreach (var article in articles?.Where(a => a.Number > item.Number).OrderBy(a=>a.Number))
            {
                article.Number -= 1;
                await UpdateAsync(article);
            }
        }
        public async Task<IEnumerable<Article>> GetAsync()
        {
            return await _context.GetAllAsync();
        }

        public async Task<Article> GetByIdAsync(int id)
        {
            return await _context.GetByIdAsync(id);
        }

        public async Task<Article> GetByNumberAsync(int number, int courseId)
        {
            return await _context.GetByNumberAsync(number, courseId);
        }

        public async Task UpdateAsync(Article item)
        {
            if (item is null)
                throw new ArgumentNullException("item");
            if (string.IsNullOrWhiteSpace(item.ArticleName) || item.ArticleName.Length > 50 || item.ArticleName.Length < 3)
                throw new ArgumentException("Invalid Name Article");
            if (string.IsNullOrWhiteSpace(item.Content) || item.Content.Length > 10000)
                throw new ArgumentException("Invalid Content");
            if (await _coursesRepository.GetByIdAsync(item.CourseId) is null)
                throw new ArgumentNullException(nameof(item.CourseId));
            await _context.UpdateAsync(item);
        }
    }
}
