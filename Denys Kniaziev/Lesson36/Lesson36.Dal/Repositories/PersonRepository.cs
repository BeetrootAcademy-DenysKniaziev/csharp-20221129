using Lesson36.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;

namespace Lesson36.Dal.Repositories
{
    public class PersonRepository : IPersonRepository, IDisposable
    {
        private AppDbContext Context { get; }

        public PersonRepository(AppDbContext context)
        {
            Context = context;            
        }

        public async Task<IEnumerable<Person>> GetAll()
        {
            return await Context.Persons.ToListAsync();
        }

        public async Task<Person> GetById(int id)
        {
            return await Context.Persons.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<int> Add(Person person)
        {
            var result = await Context.AddAsync(person);
            await Context.SaveChangesAsync();
            return result.Entity.Id;
        }

        public async Task Update(Person person)
        {
            Context.Update(person);
            await Context.SaveChangesAsync();
        }

        public async Task Delete(Person person)
        {
            Context.Remove(person);
            await Context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Console.WriteLine("DISPOSED!");
            Context.Dispose();
        }
    }
}
