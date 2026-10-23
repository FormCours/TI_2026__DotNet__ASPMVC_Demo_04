namespace DemoCinema.BLL.Models
{
    public class ScreeningModel
    {
        public int Id { get; set; }
        public DateTime Schedule { get; set; }
        public int Duration { get; set; }
        public int MovieId { get; set; }
        public MovieModel? Movie { get; set; }
        public bool IsCancel { get; set; }
    }
}
