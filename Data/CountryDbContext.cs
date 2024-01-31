using CountryDropDownAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CountryDropDownAPI.Data
{
    public class CountryDbContext : DbContext
    {
        public CountryDbContext(DbContextOptions<CountryDbContext>options) : base(options)
        {
                        
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-PT6BUQC\SQLEXPRESS;Database=CountryDropDown; User Id=naresh; Password=naresh12; Trusted_Connection=True; MultipleActiveResultSets=true;TrustServerCertificate=true");
        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Person> Persons { get; set; }

    }
}
