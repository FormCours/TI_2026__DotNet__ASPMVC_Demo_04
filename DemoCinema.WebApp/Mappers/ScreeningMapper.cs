using DemoCinema.BLL.Models;
using DemoCinema.WebApp.Models;

namespace DemoCinema.WebApp.Mappers
{
    internal static class ScreeningMapper
    {
        public static ScreeningModel ToModel(this ScreeningForm data)
        {
            return new ScreeningModel()
            {
                Schedule = data.ScheduleDate.ToDateTime(data.ShowTime),
                Duration = data.Duration,
                MovieId = data.MovieId,
                IsCancel = false
            };
        }

        public static ScreeningViewModel ToVM(this ScreeningModel data)
        {
            return new ScreeningViewModel()
            {
                Id = data.Id,
                ScheduleDate = DateOnly.FromDateTime(data.Schedule),
                ShowTime = TimeOnly.FromDateTime(data.Schedule),
                Duration = data.Duration,
                IsCancel = data.IsCancel,
                MovieId = data.MovieId,
                MovieTitle = data.Movie?.Title ?? "N/A"
            };
        }
    }
}
