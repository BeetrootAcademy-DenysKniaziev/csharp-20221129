using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeepLearn.Contracts.LessonsStructs;
using DeepLearn.DAL.Data;
using DeepLearn.DAL.Interfaces.LessonsStructs;
using Microsoft.EntityFrameworkCore;

namespace DeepLearn.DAL.Repositories.LessonsStructs
{
    public class LessonRepository : ILessonRepository
    {
        private AppDbContext _context { get; }

        public LessonRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Lesson>> GetAll()
        {
            return await _context.Lessons.ToListAsync();
        }

        public async Task<Lesson> GetById(int id)
        {
            return await _context.Lessons.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<int> Add(Lesson lesson)
        {
            var result = await _context.Lessons.AddAsync(lesson);
            await _context.SaveChangesAsync();
            return result.Entity.Id;
        }

        public async Task Update(Lesson lesson)
        {
            _context.Update(lesson);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Lesson lesson)
        {
            _context.Remove(lesson);
            await _context.SaveChangesAsync();
        }
    }
}
