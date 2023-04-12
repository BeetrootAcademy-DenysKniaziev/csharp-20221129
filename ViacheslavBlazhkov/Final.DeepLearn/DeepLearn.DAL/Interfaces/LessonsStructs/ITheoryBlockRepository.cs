using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeepLearn.Contracts.LessonsStructs;

namespace DeepLearn.DAL.Interfaces.LessonsStructs
{
    public interface ITheoryBlockRepository
    {
        Task<IEnumerable<TheoryBlock>> GetAll();
        Task<TheoryBlock> GetById(int id);
        Task<int> Add(TheoryBlock theoryBlock);
        Task Update(TheoryBlock theoryBlock);
        Task Delete(TheoryBlock theoryBlock);
    }
}
