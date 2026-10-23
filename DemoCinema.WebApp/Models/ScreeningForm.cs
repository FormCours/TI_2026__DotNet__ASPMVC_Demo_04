using DemoCinema.BLL.Models;
using System.ComponentModel.DataAnnotations;

namespace DemoCinema.WebApp.Models
{
    public class ScreeningForm
    {
        public int Id { get; set; }

        [DataType(DataType.Date)]
        public DateOnly ScheduleDate { get; set; }

        [DataType(DataType.Time)]
        public TimeOnly ShowTime { get; set; }

        public int Duration { get; set; }

        public int MovieId { get; set; }
    }
}
