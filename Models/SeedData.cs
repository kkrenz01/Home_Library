using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Home_Library.Data;
using System;
using System.Linq;

namespace Home_Library.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ApplicationDbContext>>()))
            {
                // Look for any movies.
                if (context.Game.Any())
                {
                    return;   // DB has been seeded
                }
                context.Game.AddRange(
                    new Game
                    {
                        Title = "Sonic Frontiers",
                        Developer = "Sonic Team",
                        Publisher = "SEGA",
                        Platform = "PS4",
                        ReleaseDate = DateTime.Parse("2022-08-06")
                    },
                    new Game
                    {
                        Title = "The World Ends with You",
                        Developer = "Jupiter",
                        Publisher = "Square Enix",
                        Platform = "NDS",
                        ReleaseDate = DateTime.Parse("2008-04-18")
                    },
                    new Game
                    {
                        Title = "Persona 4 Golden",
                        Developer = "ATLUS",
                        Publisher = "SEGA",
                        Platform = "PC",
                        ReleaseDate = DateTime.Parse("2020-06-14")
                    }
                );
                context.SaveChanges();
            }
        }
    }
}

