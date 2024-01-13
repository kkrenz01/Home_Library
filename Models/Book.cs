using System.ComponentModel.DataAnnotations;

namespace Home_Library.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required, Display(Name = "Title")]
        public string? Title { get; set; }

        [Required, Display(Name = "Author")]
        public string? Author { get; set; }

        [Required, Display(Name = "Publisher")]
        public string? Publisher { get; set; }

        [Required, Display(Name = "Language")]
        public string? Language { get; set; }

        [Required, Display(Name = "Release Date"), DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        //public idk cover { get; set; }

        //Navigation Properties
        public virtual ICollection<Library>? Libraries { get; set; } = new HashSet<Library>();

    }
}
