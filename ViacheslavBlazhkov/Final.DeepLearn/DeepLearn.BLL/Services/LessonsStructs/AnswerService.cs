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
    public class AnswerService : IAnswerService
    {
        private readonly IAnswerRepository _answerRepository;

        public AnswerService(IAnswerRepository answerRepository)
        {
            _answerRepository = answerRepository;
        }

        public async Task<IEnumerable<Answer>> GetAll() => await _answerRepository.GetAll();

        public async Task<Answer> GetById(int id) => await _answerRepository.GetById(id);

        public async Task<int> Add(Answer answer) => await _answerRepository.Add(answer);

        public async Task Update(Answer answer) => await _answerRepository.Update(answer);

        public async Task Delete(Answer answer) => await _answerRepository.Delete(answer);
    }
}
