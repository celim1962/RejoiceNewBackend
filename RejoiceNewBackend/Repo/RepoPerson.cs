using Microsoft.EntityFrameworkCore;
using RejoiceNewBackend.Data;
using RejoiceNewBackend.Model;
using System;

namespace RejoiceNewBackend.Repo
{
    public class RepoPerson
    {
        private readonly TestDBContext _context;
        public RepoPerson(TestDBContext context)
        {
            _context = context;
        }

        public async Task<List<Person>> GetAllAsync() =>
           await _context.Persons.AsNoTracking().ToListAsync();

        public async Task<Person?> GetByIdAsync(int id) =>
            await _context.Persons.FindAsync(id);

        public async Task<Person> AddAsync(Person person)
        {
            _context.Persons.Add(person);
            await _context.SaveChangesAsync();
            return person;
        }

        public async Task<bool> UpdateAsync(Person person)
        {
            _context.Persons.Update(person);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var p = await _context.Persons.FindAsync(id);
            if (p == null) return false;
            _context.Persons.Remove(p);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
