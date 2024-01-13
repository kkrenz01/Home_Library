using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Home_Library.Models
{
    public class Game
    {
        public int Id { get; set; }

        [Required]
        public string? Title { get; set; }

        [Required]
        public string? Developer { get; set; }

        [Required]
        public string? Publisher { get; set; }

        [Required]
        public string? Platform { get; set; }

        [Required, Display(Name = "Release Date"), DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        public string? CoverPath { get; set; }
        [NotMapped]
        public IFormFile? Cover { get; set; }

        //Navigation Properties
        public virtual ICollection<Library>? Libraries { get; set; } = new HashSet<Library>();

    }
}
