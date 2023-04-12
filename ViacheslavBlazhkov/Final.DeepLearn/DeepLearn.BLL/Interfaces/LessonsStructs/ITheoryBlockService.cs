using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeepLearn.Contracts.LessonsStructs;

namespace DeepLearn.BLL.Interfaces.LessonsStructs
{
    public interface ITheoryBlockService
    {
        Task<IEnumerable<TheoryBlock>> GetAll();
        Task<TheoryBlock> GetById(int id);
        Task<int> Add(TheoryBlock theoryBlock);
        Task Update(TheoryBlock theoryBlock);
        Task Delete(TheoryBlock theoryBlock);
    }
}
