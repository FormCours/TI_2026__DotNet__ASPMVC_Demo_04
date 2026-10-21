namespace DemoCinema.DAL.Entities
{
    public class MovieEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Director { get; set; }
        public List<string> Genres { get; set; }
        public string? Desc { get; set; }
        public double Rating { get; set; }
    }
}
