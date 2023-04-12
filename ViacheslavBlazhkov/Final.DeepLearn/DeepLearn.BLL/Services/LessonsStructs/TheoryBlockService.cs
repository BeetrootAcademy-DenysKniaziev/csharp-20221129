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
    public class TheoryBlockService : ITheoryBlockService
    {
        private ITheoryBlockRepository _theoryBlockRepository { get; }

        public TheoryBlockService(ITheoryBlockRepository theoryBlockRepository)
        {
            _theoryBlockRepository = theoryBlockRepository;
        }

        public async Task<IEnumerable<TheoryBlock>> GetAll() => await _theoryBlockRepository.GetAll();

        public async Task<TheoryBlock> GetById(int id) => await _theoryBlockRepository.GetById(id);

        public async Task<int> Add(TheoryBlock theoryBlock) => await _theoryBlockRepository.Add(theoryBlock);

        public async Task Update(TheoryBlock theoryBlock) => await _theoryBlockRepository.Update(theoryBlock);

        public async Task Delete(TheoryBlock theoryBlock) => await _theoryBlockRepository.Delete(theoryBlock);
    }
}
