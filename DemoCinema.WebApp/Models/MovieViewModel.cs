namespace DemoCinema.WebApp.Models
{
    public class MovieViewModel
    {
        public required int Id { get; set; }
        public required string Title { get; set; }
        public required DateOnly ReleaseDate { get; set; }
        public required string Director { get; set; }
        public required List<string> Genres { get; set; }
        public required string Desc { get; set; }
        public required int Rating { get; set; } /* 0 - 10 */
    }
}
