using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Webbtc.Data;
using System;
using System.Linq;

namespace Class.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new WebbtcContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<WebbtcContext>>()))
            {
                // Look for any movies.
                if (context.coin.Any())
                {
                    return;   // DB has been seeded
                }

                context.coin.AddRange(
                    new coin
                    {
                        Title = "jasmy",
                        ReleaseDate = DateTime.Parse("2022-3-14"),
                        Genre = "gamecoin",
                        Price = 5.0M
                    },

                    new coin
                    {
                        Title = "pi ",
                        ReleaseDate = DateTime.Parse("2021-9-23"),
                        Genre = "defi",
                        Price = 8.00M
                    },

                    new coin
                    {
                        Title = "osmy",
                        ReleaseDate = DateTime.Parse("2021-4-14"),
                        Genre = "utility",
                        Price = 0.39M
                    },

                    new coin
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
