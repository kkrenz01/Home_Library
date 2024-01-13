using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Home_Library.Models
{
    public class Library
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        public string? UserId { get; set; }

        //Navigation Properties
        [Required]
        public virtual ICollection<Game>? Games { get; set; } = new HashSet<Game>();
        [Required]
        public ApplicationUser? User { get; set; }

    }
}
