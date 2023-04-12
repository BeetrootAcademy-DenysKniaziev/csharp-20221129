using DeepLearn.BLL.Interfaces.LessonsStructs;
using DeepLearn.Contracts.LessonsStructs;
using DeepLearn.DAL.Interfaces.LessonsStructs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeepLearn.BLL.Services.LessonsStructs
{
    public class TestBlockService : ITestBlockService
    {
        private ITestBlockRepository _testBlockRepository { get; }

        public TestBlockService(ITestBlockRepository testBlockRepository)
        {
            _testBlockRepository = testBlockRepository;
        }

        public async Task<IEnumerable<TestBlock>> GetAll() => await _testBlockRepository.GetAll();

        public async Task<TestBlock> GetById(int id) => await _testBlockRepository.GetById(id);

        public async Task<int> Add(TestBlock testBlock) => await _testBlockRepository.Add(testBlock);

        public async Task Update(TestBlock testBlock) => await _testBlockRepository.Update(testBlock);

        public async Task Delete(TestBlock testBlock) => await _testBlockRepository.Delete(testBlock);
    }
}
