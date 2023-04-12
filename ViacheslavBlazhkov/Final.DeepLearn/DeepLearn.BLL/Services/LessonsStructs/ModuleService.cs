using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeepLearn.BLL.Interfaces.LessonsStructs;
using DeepLearn.Contracts.LessonsStructs;
using DeepLearn.DAL.Interfaces.LessonsStructs;

namespace DeepLearn.BLL.Services.LessonsStructs
{
    public class ModuleService : IModuleService
    {
        private IModuleRepository _moduleRepository { get; }

        public ModuleService(IModuleRepository moduleRepository)
        {
            _moduleRepository = moduleRepository;
        }

        public async Task<IEnumerable<Module>> GetAll() => await _moduleRepository.GetAll();

        public async Task<Module> GetById(int id) => await _moduleRepository.GetById(id);

        public async Task<int> Add(Module module) => await _moduleRepository.Add(module);

        public async Task Update(Module module) => await _moduleRepository.Update(module);

        public async Task Delete(Module module) => await _moduleRepository.Delete(module);
    }
}
