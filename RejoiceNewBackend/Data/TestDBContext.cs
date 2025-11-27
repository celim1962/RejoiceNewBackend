using Microsoft.EntityFrameworkCore;
using RejoiceNewBackend.Model;
using System;

namespace RejoiceNewBackend.Data
{
    public class TestDBContext: DbContext
    {
        public TestDBContext(DbContextOptions<TestDBContext> options) : base(options) { }

        public DbSet<Person> Persons => Set<Person>();
        public DbSet<TripCategory> TripCategories => Set<TripCategory>();
        public DbSet<TripDetail> TripDetails => Set<TripDetail>();
        public DbSet<TripDetailPrice> TripDetailPrice => Set<TripDetailPrice>();
        public DbSet<TripDetailSchedule> TripDetailSchedule => Set<TripDetailSchedule>();
    }
}
