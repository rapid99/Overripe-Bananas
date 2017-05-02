using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace OverripeBananas.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new OverripeBananasContext(
                serviceProvider.GetRequiredService<DbContextOptions<OverripeBananasContext>>()))
            {
                if (context.Show.Any())
                {
                    return; // DB has been seeded!
                }

                context.Show.AddRange(
                    new Show
                    {
                        Title = "American Dad",
                        Genre = "Comedy",
                        Rating = "A"
                    },
                    new Show
                    {
                        Title = "South Park",
                        Genre = "Comedy",
                        Rating = "A-"
                    },
                    new Show
                    {
                        Title = "Shameless",
                        Genre = "Drama",
                        Rating = "B"
                    },
                    new Show
                    {
                        Title = "Family Guy",
                        Genre = "Comedy",
                        Rating = "A-"
                    },
                    new Show
                    {
                        Title = "American Horror Story",
                        Genre = "Horror",
                        Rating = "B-"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
