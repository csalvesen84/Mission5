using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission4.Models
{
    public class MovieContext : DbContext
    {
        //Constructor
        public MovieContext(DbContextOptions<MovieContext> options) : base (options)
        {
            //Leave blank for now
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            //Seeding categories for a dropdown using Joel's list. Added Western cause its unique to all the other genres
            mb.Entity<Category>().HasData(
                new Category
                {
                    CategoryID = 1,
                    CategoryName = "Action/Adventure"
                },
                new Category
                {
                    CategoryID = 2,
                    CategoryName = "Comedy"
                },
                new Category
                {
                    CategoryID = 3,
                    CategoryName = "Drama"
                },
                new Category
                {
                    CategoryID = 4,
                    CategoryName = "Family"
                },
                new Category
                {
                    CategoryID = 5,
                    CategoryName = "Horror/Suspense"
                },
                new Category
                {
                    CategoryID = 6,
                    CategoryName = "Miscellaneous"
                },
                new Category
                {
                    CategoryID = 7,
                    CategoryName = "Television"
                },
                new Category
                {
                    CategoryID = 8,
                    CategoryName = "VHS"
                },
                new Category
                {
                    CategoryID = 9,
                    CategoryName = "Western"
                }
            );


            //Seeding the database with some movies when first created
            mb.Entity<Movie>().HasData(
                new Movie
                {
                    MovieId = 1,
                    CategoryID = 1,
                    Title = "Star Wars Episode III: Revenge of the Sith",
                    Year = 2005,
                    Director = "George Lucas",
                    Rating = "PG-13",
                    Edited = false,
                    LentTo = null,
                    Notes = null
                },
                new Movie
                {
                    MovieId = 2,
                    CategoryID = 2,
                    Title = "Napoleon Dynamite",
                    Year = 2004,
                    Director = "Jared Hess",
                    Rating = "PG",
                    Edited = false,
                    LentTo = null,
                    Notes = null
                },
                new Movie
                {
                    MovieId = 3,
                    CategoryID = 9,
                    Title = "Django Unchained",
                    Year = 2012,
                    Director = "Quentin Tarantino",
                    Rating = "R",
                    Edited = true,
                    LentTo = null,
                    Notes = null
                },
                new Movie
                {
                    MovieId = 4,
                    CategoryID = 2,
                    Title = "Kingsman: The Secret Service",
                    Year = 2014,
                    Director = "Matthew Vaughn",
                    Rating = "R",
                    Edited = true,
                    LentTo = null,
                    Notes = null
                }
            );
        }
    }
}
