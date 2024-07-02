using Ispit.BooksAntunVajdic.Models.Dbo;
using Ispit.BooksAntunVajdic.Models.UserModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Ispit.BooksAntunVajdic.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole, string>
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Author>().HasData(
                new Author { Id = 1, FirstName = "Chinua", LastName = "Achebe" },
                new Author { Id = 2, FirstName = "Jane", LastName = "Austen" },
                new Author { Id = 3, FirstName = "Paul", LastName = "Celan" },
                new Author { Id = 4, FirstName = "Nikolaj", LastName = "Gogolj" },
                new Author { Id = 5, FirstName = "Henrik", LastName = "Ibsen" }

                );
            modelBuilder.Entity<Publisher>().HasData(
                new Publisher { Id = 1, NamePublisher = "Publisher1" },
                new Publisher { Id = 2, NamePublisher = "Publisher2" },
                new Publisher { Id = 3, NamePublisher = "Publisher3" }


                );

            base.OnModelCreating(modelBuilder);

        }




    }
}

