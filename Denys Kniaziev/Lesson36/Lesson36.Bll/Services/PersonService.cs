using FluentValidation;
using Lesson36.Bll.Utils;
using Lesson36.Contracts;
using Lesson36.Dal.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lesson36.Bll.Services
{
    public class PersonService : IPersonService
    {
        private IPersonRepository Repository { get; }
        public IDateTimeProvider DateTimeProvider { get; }
        public IValidator<Person> Validator { get; }


        public PersonService(IPersonRepository repository, IDateTimeProvider dateTimeProvider, IValidator<Person> validator)
        {
            Repository = repository;
            DateTimeProvider = dateTimeProvider;
            Validator = validator;
        }

        public async Task<IEnumerable<Person>> GetAll() => await Repository.GetAll();            

        public async Task<Person> GetById(int id) => await Repository.GetById(id);

        public async Task<OperationResult<int>> Add(Person person)
        {
            var validationResult = await Validator.ValidateAsync(person);
            if (!validationResult.IsValid)
                return new OperationResult<int>(false, 0, validationResult.ToDictionary());

            person.CreatedAt = DateTimeProvider.UtcNow;
            var id = await Repository.Add(person);
            return new OperationResult<int>(true, id);
        }

        public async Task Update(Person person) => await Repository.Update(person);

        public async Task Delete(Person person) => await Repository.Delete(person);

        // To detect redundant calls
        private bool _disposedValue;

        protected virtual void DisposeInternal(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                    Repository.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                _disposedValue = true;
            }
        }

        ~PersonService()
        {
            DisposeInternal(false);
            
        }

        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose()
        {
            DisposeInternal(true);
            GC.SuppressFinalize(this);

        }
    }
}
