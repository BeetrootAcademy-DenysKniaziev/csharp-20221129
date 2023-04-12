using DeepLearn.Contracts.LessonsStructs;
using DeepLearn.DAL.Data;
using DeepLearn.DAL.Interfaces.LessonsStructs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DeepLearn.DAL.Repositories.LessonsStructs
{
    public class TestBlockRepository : ITestBlockRepository
    {
        private AppDbContext _context { get; }

        public TestBlockRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TestBlock>> GetAll()
        {
            return await _context.TestBlocks.ToListAsync();
        }

        public async Task<TestBlock> GetById(int id)
        {
            return await _context.TestBlocks.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<int> Add(TestBlock testBlock)
        {
            var result = await _context.TestBlocks.AddAsync(testBlock);
            await _context.SaveChangesAsync();
            return result.Entity.Id;
        }

        public async Task Update(TestBlock testBlock)
        {
            _context.Update(testBlock);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(TestBlock testBlock)
        {
            _context.Remove(testBlock);
            await _context.SaveChangesAsync();
        }
    }
}
