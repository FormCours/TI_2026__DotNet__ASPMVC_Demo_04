namespace DemoCinema.WebApp.Models
{
    public class ScreeningViewModel
    {
        public required int Id { get; set; }
        public required DateOnly ScheduleDate { get; set; }
        public required TimeOnly ShowTime { get; set; }
        public required int Duration { get; set; }
        public required int MovieId { get; set; }
        public required string MovieTitle { get; set; }
        public required bool IsCancel { get; set; }
    }
}
