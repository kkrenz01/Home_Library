namespace Home_Library.Models
{
    public class LibraryViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public List<Game>? Games { get; set; }
        public string? Style {  get; set; }
    }
}
