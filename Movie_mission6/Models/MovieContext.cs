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

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<MovieResponse>().HasData(
                    /*Seeding my database*/
                    new MovieResponse
                    {
                        MovieID = 1,
                        Category = "Action/Adventure",
                        Title = "Indiana Jones",
                        Director = "George Lucas",
                        Year = 1998,
                        Rating = "PG-13",
                        Notes = "This is awesome"
                    },
                    new MovieResponse
                    {
                        MovieID = 2,
                        Category = "Sci-Fi",
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
                        Category = "Sci-Fi",
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
