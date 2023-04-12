﻿using DeepLearn.Contracts.LessonsStructs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeepLearn.BLL.Interfaces.LessonsStructs
{
    public interface ITestBlockService
    {
        Task<IEnumerable<TestBlock>> GetAll();
        Task<TestBlock> GetById(int id);
        Task<int> Add(TestBlock testBlock);
        Task Update(TestBlock testBlock);
        Task Delete(TestBlock testBlock);
    }
}