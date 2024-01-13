using Microsoft.AspNetCore.Identity;

namespace Home_Library.Models
{
    public class ApplicationUser: IdentityUser
    {
        public virtual ICollection<Library> Libraries { get; set; } = new HashSet<Library>();

    }
}
