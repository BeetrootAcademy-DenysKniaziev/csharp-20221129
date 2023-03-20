﻿
using Microsoft.EntityFrameworkCore;

namespace LearningSystem.DAL.Repositories
{
    public class ArticlesRepository : AbstractRepository<Article>, IArticlesRepository
    {
        private ApplicationDbContext _context;
        public ArticlesRepository(ApplicationDbContext context) : base(context)
        { 
            _context = context;
        }

        public async Task<Article> GetByNumber(int number, int courseId)
        {
            return await _context?.Articles.SingleOrDefaultAsync(a => a.Number == number && a.CourseId == courseId);
        }
    }
}
