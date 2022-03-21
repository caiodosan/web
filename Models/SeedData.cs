using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using dashboard.Data;
using System;
using System.Linq;

namespace MvcMovie.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new dashboardContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<dashboardContext>>()))
            {
                // Look for any movies.
                if (context.Movie.Any())
                {
                    return;   // DB has been seeded
                }

                context.Movie.AddRange(
                    new dash
                    {
                        Title = "jasmy",
                        ReleaseDate = DateTime.Parse("2022-3-14"),
                        Genre = "gamecoin",
                        Price = 5.0M
                    },

                    new dash
                    {
                        Title = "pi ",
                        ReleaseDate = DateTime.Parse("2021-9-23"),
                        Genre = "defi",
                        Price = 8.00M
                    },

                    new dash
                    {
                        Title = "osmy",
                        ReleaseDate = DateTime.Parse("2021-4-14"),
                        Genre = "utility",
                        Price = 0.39M
                    },

                    new dash
                    {
                        Title = "Ape",
                        ReleaseDate = DateTime.Parse("2022-3-18"),
                        Genre = "nftcoin",
                        Price = 3.99M
                    }
                );
                context.SaveChanges();
            }
        }
    }
}