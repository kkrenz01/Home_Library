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
                        ReleaseDate = DateTime.Parse("2022-08-06"),
                        CoverPath = "/Images/covers/games/Sonic_Frontiers_PS4_2D_Packshot_EN_PEGI.png"
                    },
                    new Game
                    {
                        Title = "The World Ends with You",
                        Developer = "Jupiter",
                        Publisher = "Square Enix",
                        Platform = "NDS",
                        ReleaseDate = DateTime.Parse("2008-04-18"),
                        CoverPath = "/Images/covers/games/TheWorldEndsWithYou_NDS_PAL.jpg"
                    },
                    new Game
                    {
                        Title = "Neon White",
                        Developer = "Angel Matrix",
                        Publisher = "Annapurna Interactive",
                        Platform = "PC",
                        ReleaseDate = DateTime.Parse("2022-06-16"),
                        CoverPath = "/Images/covers/games/NeonWhite_PC_Portrait.jpg"
                    },
                    new Game
                    {
                        Title = "dot Hack//Outbreak",
                        Developer = "CyberConnect2",
                        Publisher = "Bandai",
                        Platform = "PS2",
                        ReleaseDate = DateTime.Parse("2003-09-09"),
                        CoverPath = "/Images/covers/games/dotHack_Outbreak_PS2_NTSC.jpg"
                    },
                    new Game
                    {
                        Title = "Gravity Rush Remastered",
                        Developer = "Japan Studio",
                        Publisher = "Sony Computer Entertainment",
                        Platform = "PS4",
                        ReleaseDate = DateTime.Parse("2016-02-15"),
                        CoverPath = "/Images/covers/games/GravityRushRemastered_PS4_PL.jpg"
                    },
                    new Game
                    {
                        Title = "13 Sentinels: Aegis Rim",
                        Developer = "Vanillaware",
                        Publisher = "SEGA",
                        Platform = "PS4",
                        ReleaseDate = DateTime.Parse("2019-11-28"),
                        CoverPath = "/Images/covers/games/13Sentinels_AegisRim_PS4_PAL.jpg"
                    },
                    new Game
                    {
                        Title = "Sonic Adventure 2",
                        Developer = "Sonic Team",
                        Publisher = "SEGA",
                        Platform = "DC",
                        ReleaseDate = DateTime.Parse("2001-06-18"),
                        CoverPath = "/Images/covers/games/SonicAdventure2_DC_NTSC.jpg"
                    },
                    new Game
                    {
                        Title = "Kid Icarus: Uprising",
                        Developer = "Sora LTD.",
                        Publisher = "Nintendo",
                        Platform = "3DS",
                        ReleaseDate = DateTime.Parse("2012-03-23"),
                        CoverPath = "/Images/covers/games/KidIcarusUprising_3DS_NTSC.jpg"
                    },
                    new Game
                    {
                        Title = "Hotel Dusk: Room 215",
                        Developer = "Cing",
                        Publisher = "Nintendo",
                        Platform = "NDS",
                        ReleaseDate = DateTime.Parse("2007-01-22"),
                        CoverPath = "/Images/covers/games/HotelDusk_Room215_NDS_USA.jpg"
                    },
                    new Game
                    {
                        Title = "Mega Man Legacy Collection",
                        Developer = "Capcom",
                        Publisher = "Capcom",
                        Platform = "PS4",
                        ReleaseDate = DateTime.Parse(""),
                        CoverPath = "/Images/covers/games/MegaMan_LegacyCollection_PS4_NTSC.jpg"
                    },
                    new Game
                    {
                        Title = "Mega Man X Collection",
                        Developer = "Capcom",
                        Publisher = "Capcom",
                        Platform = "GCN",
                        ReleaseDate = DateTime.Parse(""),
                        CoverPath = "/Images/covers/games/MegaManX_Collection_NGC_NTSC.jpg"
                    },
                    new Game
                    {
                        Title = "Ace Attorney: Trails and Tribulations",
                        Developer = "Capcom",
                        Publisher = "Capcom",
                        Platform = "NDS",
                        ReleaseDate = DateTime.Parse("2004-01-23"),
                        CoverPath = "/Images/covers/games/AceAttorney_JusticeForAll_NDS_NTSC.jpg"
                    }

                );
                context.SaveChanges();
            }
        }
    }
}

