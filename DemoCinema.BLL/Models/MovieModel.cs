namespace DemoCinema.BLL.Models
{
    public class MovieModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DirectorModel Director { get; set; }
        public List<string> Genres { get; set; }
        public string? Desc { get; set; }
        public int Rating { get; set; } /* 0 - 10 */
    }
}
