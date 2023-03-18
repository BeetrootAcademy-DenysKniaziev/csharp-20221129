namespace LearningSystem.BLL.Services
{
    public class CoursesService:ICoursesService
    {
        private ICoursesRepository _context;
        public CoursesService(ICoursesRepository context)
        {
            _context = context;
        }
        public async Task AddAsync(Course item)
        {
            await _context.AddAsync(item);
        }

        public async Task DeleteAsync(Course item)
        {
            await _context.DeleteAsync(item);
        }

        public async Task<IEnumerable<Course>> GetAsync()
        {
            return await _context.GetAsync();
        }

        public async Task<Course> GetByIdAsync(int id)
        {
            return await _context.GetByIdAsync(id);
        }

        public async Task UpdateAsync(Course item)
        {
            await _context.UpdateAsync(item);
        }
    }
}
