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
    public class TheoryBlockRepository : ITheoryBlockRepository
    {
        private AppDbContext _context { get; }

        public TheoryBlockRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TheoryBlock>> GetAll()
        {
            return await _context.TheoryBlocks.ToListAsync();
        }

        public async Task<TheoryBlock> GetById(int id)
        {
            return await _context.TheoryBlocks.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<int> Add(TheoryBlock theoryBlock)
        {
            var result = await _context.TheoryBlocks.AddAsync(theoryBlock);
            await _context.SaveChangesAsync();
            return result.Entity.Id;
        }

        public async Task Update(TheoryBlock theoryBlock)
        {
            _context.Update(theoryBlock);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(TheoryBlock theoryBlock)
        {
            _context.Remove(theoryBlock);
            await _context.SaveChangesAsync();
        }
    }
}
