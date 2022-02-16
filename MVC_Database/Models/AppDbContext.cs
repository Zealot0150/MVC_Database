namespace MVC_Database.Models
{

    using Microsoft.EntityFrameworkCore;
    using MVC_Database.Models;

    public class AppDbContext : DbContext
    {

        // Kom ihåg! obs!, EF power tools ger möjlighet till att se hur entity byggt upp db, finns som nuget.

        // Bara för mitt dåliga minne
        //    get-help Add-Migration
        //and

        //get-help Update-Database


            public DbSet<Person> People { get; set; }
            public DbSet<City> City { get; set; }
            public DbSet<Country> Country { get; set; }


            public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
            {
            }

            //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            //{
            //    // körs vid start behövs när man inte har startup config
            //    // denna är olika för varje lev så vid nuget pack mysql=> UseMySql
            //    optionsBuilder.UseSqlServer(Configurationsstring);
            //    base.OnConfiguring(optionsBuilder);
            //}


            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);

            Country country1 = new() {  Name = "Sweden" };
            Country country2 = new() {  Name = "Germany" };
            City city1 = new() { CityId = "Fröölunda", CountryId = "Sweden"};
            City city2 = new() { CityId = "Berlin", CountryId = "Germany" };
            Person people1 = new() { Id = 1, Name = "Piff", Tele = "1234567890", CityId = "Fröölunda" };
            Person people2 = new() { Id = 2, Name = "puff", Tele = "1234567890", CityId = "Berlin" };
            Person people3 = new() { Id = 3, Name = "Soet gullan", Tele = "12345678190", CityId="Berlin"};

            modelBuilder.Entity<Country>().HasData(country1);
            modelBuilder.Entity<Country>().HasData(country2);
            modelBuilder.Entity<City>().HasData(city1);
            modelBuilder.Entity<City>().HasData(city2);

            //seed categories
                modelBuilder.Entity<Person>().HasData(people1);
                modelBuilder.Entity<Person>().HasData(people2);
                modelBuilder.Entity<Person>().HasData(people3);
                
        }
    }
}
