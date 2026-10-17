using Microsoft.EntityFrameworkCore;
using Anita_Gabriel_Lab2.Models;

namespace Anita_Gabriel_Lab2.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = new Anita_Gabriel_Lab2Context(
                serviceProvider.GetRequiredService<DbContextOptions<Anita_Gabriel_Lab2Context>>());

            if (!context.Publisher.Any())
            {
                context.Publisher.AddRange(
                    new Publisher { PublisherName = "Humanitas" },
                    new Publisher { PublisherName = "Nemira" },
                    new Publisher { PublisherName = "Arthur" });
                context.SaveChanges();
            }

            if (!context.Author.Any())
            {
                context.Author.AddRange(
                    new Author { FirstName = "Mircea", LastName = "Eliade" },
                    new Author { FirstName = "Liviu", LastName = "Rebreanu" },
                    new Author { FirstName = "Mihail", LastName = "Sadoveanu" });
                context.SaveChanges();
            }

            if (!context.Book.Any())
            {
                var humanitas = context.Publisher.First(p => p.PublisherName == "Humanitas");
                var nemira = context.Publisher.First(p => p.PublisherName == "Nemira");
                var eliade = context.Author.First(a => a.LastName == "Eliade");
                var rebreanu = context.Author.First(a => a.LastName == "Rebreanu");

                context.Book.AddRange(
                    new Book
                    {
                        Title = "Maitreyi",
                        AuthorID = eliade.ID,
                        Price = 39.90M,
                        PublishingDate = new DateTime(2007, 3, 15),
                        PublisherID = humanitas.ID
                    },
                    new Book
                    {
                        Title = "Ion",
                        AuthorID = rebreanu.ID,
                        Price = 45.50M,
                        PublishingDate = new DateTime(2012, 9, 1),
                        PublisherID = nemira.ID
                    });
                context.SaveChanges();
            }
        }
    }
}
