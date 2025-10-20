using Microsoft.EntityFrameworkCore;
using RejoiceNewBackend.Model;
using System;

namespace RejoiceNewBackend.Data
{
    public class TestDBContext: DbContext
    {
        public TestDBContext(DbContextOptions<TestDBContext> options) : base(options) { }

        public DbSet<Person> Persons => Set<Person>();
    }
}
