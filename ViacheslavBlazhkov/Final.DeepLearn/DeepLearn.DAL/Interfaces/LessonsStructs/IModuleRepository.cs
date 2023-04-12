using DeepLearn.Contracts.LessonsStructs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeepLearn.DAL.Interfaces.LessonsStructs
{
    public interface IModuleRepository
    {
        Task<IEnumerable<Module>> GetAll();
        Task<Module> GetById(int id);
        Task<int> Add(Module module);
        Task Update(Module module);
        Task Delete(Module module);
    }
}
