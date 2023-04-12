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
    public class ModuleRepository : IModuleRepository
    {
        private AppDbContext _context { get; }

        public ModuleRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Module>> GetAll()
        {
            return await _context.Modules.ToListAsync();
        }

        public async Task<Module> GetById(int id)
        {
            return await _context.Modules.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<int> Add(Module module)
        {
            var result = await _context.Modules.AddAsync(module);
            await _context.SaveChangesAsync();
            return result.Entity.Id;
        }

        public async Task Update(Module module)
        {
            _context.Update(module);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Module module)
        {
            _context.Remove(module);
            await _context.SaveChangesAsync();
        }
    }
}
