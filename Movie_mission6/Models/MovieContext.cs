using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie_mission6.Models
{
    public class MovieContext : DbContext
    {
        // Constructor
        public MovieContext(DbContextOptions<MovieContext> options) : base (options)
        {
            //leave blank for now
        }

        public DbSet<MovieResponse> Responses { get; set; }
        public DbSet<MovieCategory> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<MovieCategory>().HasData(
                    new MovieCategory { CategoryID=1, Category="Sci-Fi"},
                    new MovieCategory { CategoryID=2, Category="Action/Adventure"},
                    new MovieCategory { CategoryID=3, Category="Romance"},
                    new MovieCategory { CategoryID=4, Category="Comedy"}
                );
            mb.Entity<MovieResponse>().HasData(
                    /*Seeding my database*/
                    new MovieResponse
                    {
                        MovieID = 1,
                        CategoryID = 2,
                        Title = "Indiana Jones",
                        Director = "George Lucas",
                        Year = 1998,
                        Rating = "PG-13",
                        Notes = "This is awesome"
                    },
                    new MovieResponse
                    {
                        MovieID = 2,
                        CategoryID = 1,
                        Title = "Star Wars: A New Hope",
                        Director = "George Lucas",
                        Year = 1977,
                        Rating = "PG",
                        Edited = true,
                        Notes = "Amazing film"
                    },
                    new MovieResponse
                    {
                        MovieID = 3,
                        CategoryID = 1,
                        Title = "Star Wars: The Phantom Menace",
                        Director = "George Lucas",
                        Year = 1999,
                        Rating = "PG",
                        Edited = false,
                        Notes = "Why Jar Jar"
                    }
                );
        }
    }
}
