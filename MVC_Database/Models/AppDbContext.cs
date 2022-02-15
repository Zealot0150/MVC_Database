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


            public DbSet<People> People { get; set; }


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

                //seed categories
                modelBuilder.Entity<People>().HasData(new People {  Id= 1, Name = "Piff", Tele = "1234567890", City="Göteborg" });
                modelBuilder.Entity<People>().HasData(new People { Id = 2, Name = "Puff", Tele = "1234565555", City = "Stockholme" });
                modelBuilder.Entity<People>().HasData(new People { Id = 3, Name = "Puffspappa", Tele = "123456558", City = "Stockö" });
                modelBuilder.Entity<People>().HasData(new People { Id = 4, Name = "Puffsmamma", Tele = "1234565559", City = "Stockvik" });

        }
    }
}
