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
    public class CourseRepository : ICourseRepository
    {
        private AppDbContext _context { get; }

        public CourseRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Course>> GetAll()
        {
            return await _context.Courses.ToListAsync();
        }

        public async Task<Course> GetById(int id)
        {
            return await _context.Courses.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<int> Add(Course course)
        {
            var result = await _context.Courses.AddAsync(course);
            await _context.SaveChangesAsync();
            return result.Entity.Id;
        }

        public async Task Update(Course course)
        {
            _context.Update(course);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Course course)
        {
            _context.Remove(course);
            await _context.SaveChangesAsync();
        }
    }
}
