using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Home_Library.Models
{
    public class Library
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public string? Description { get; set; }
        [Required]
        public string? UserId { get; set; }

        //Navigation Properties
        public virtual ICollection<Game>? Games { get; set; } = new HashSet<Game>();
        public ApplicationUser? User { get; set; }

    }
}
