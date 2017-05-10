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
                        Rating = "A",
                        Description = "The random escapades of Stan Smith, a conservative CIA agent dealing with family life and keeping America safe, all in the most absurd way possible."
                    },
                    new Show
                    {
                        Title = "South Park",
                        Genre = "Comedy",
                        Rating = "A-",
                        Description = "Follows the misadventures of four irreverent grade-schoolers in the quiet, dysfunctional town of South Park, Colorado."
                    },
                    new Show
                    {
                        Title = "Shameless",
                        Genre = "Drama",
                        Rating = "B",
                        Description = "An alcoholic man lives in a perpetual stupor while his six children with whom he lives cope as best they can."
                    },
                    new Show
                    {
                        Title = "Family Guy",
                        Genre = "Comedy",
                        Rating = "A-",
                        Description = "In a wacky Rhode Island town, a dysfunctional family strive to cope with everyday life as they are thrown from one crazy scenario to another."
                    },
                    new Show
                    {
                        Title = "American Horror Story",
                        Genre = "Horror",
                        Rating = "B-",
                        Description = "An anthology series that centers on different characters and locations, including a house with a murderous past, an insane asylum, a witch coven, a freak show, a hotel and a sinister farmhouse."
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
