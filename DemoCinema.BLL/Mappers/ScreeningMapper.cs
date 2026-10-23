using DemoCinema.BLL.Models;
using DemoCinema.DAL.Entities;

namespace DemoCinema.BLL.Mappers
{
    internal static class ScreeningMapper
    {
        public static ScreeningModel ToModel(this ScreeningEntity data)
        {
            return new ScreeningModel
            {
                Id = data.Id,
                Duration = data.Duration,
                Schedule = data.Schedule,
                IsCancel = data.IsCancel,
                MovieId = data.MovieId,
                Movie = null
            };
        }

        public static ScreeningEntity ToEntity(this ScreeningModel data)
        {

            return new ScreeningEntity
            {
                Id = data.Id,
                Duration = data.Duration,
                Schedule = data.Schedule,
                IsCancel = data.IsCancel,
                MovieId = data.MovieId
            };
        }
    }
}
