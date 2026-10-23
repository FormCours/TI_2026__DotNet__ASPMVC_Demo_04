namespace DemoCinema.DAL.Entities
{
    public class ScreeningEntity
    {
        public int Id { get; set; }
        public DateTime Schedule { get; set; }
        public int Duration { get; set; }
        public int MovieId { get; set; }
        public bool IsCancel { get; set; }
    }
}
