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
    public class AnswerRepository : IAnswerRepository
    {
        private AppDbContext _context { get; }

        public AnswerRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Answer>> GetAll()
        {
            return await _context.Answers.ToListAsync();
        }

        public async Task<Answer> GetById(int id)
        {
            return await _context.Answers.FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<int> Add(Answer answer)
        {
            var result = await _context.Answers.AddAsync(answer);
            await _context.SaveChangesAsync();
            return result.Entity.Id;
        }

        public async Task Update(Answer answer)
        {
            _context.Update(answer);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Answer answer)
        {
            _context.Remove(answer);
            await _context.SaveChangesAsync();
        }
    }
}
