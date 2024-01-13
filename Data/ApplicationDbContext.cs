using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Home_Library.Models;

namespace Home_Library.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Home_Library.Models.Game> Game { get; set; } = default!;
        public DbSet<Home_Library.Models.Library> Library { get; set; } = default!;
    }
}
