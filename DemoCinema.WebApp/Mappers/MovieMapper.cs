using DemoCinema.BLL.Models;
using DemoCinema.WebApp.Models;

namespace DemoCinema.WebApp.Mappers
{
    internal static class MovieMapper
    {
        public static MovieModel ToModel(this MovieForm data)
        {
            return new MovieModel()
            {
                Title = data.Title,
                Desc = data.Desc,
                Director = new DirectorModel()
                {
                    FirstName = data.DirectorFirstName,
                    LastName = data.DirectorLastName
                },
                ReleaseDate = data.ReleaseDate.ToDateTime(TimeOnly.MinValue),
                Rating = data.Rating,
                Genres = data.Genres.Where(g => g is not null).ToList(),
            };
        }

        public static MovieViewModel ToVM(this MovieModel data)
        {
            return new MovieViewModel()
            {
                Id = data.Id,
                Title = data.Title,
                Desc = data.Desc ?? "N/A",
                Genres = data.Genres,
                Rating = data.Rating,
                Director = $"{data.Director.FirstName} {data.Director.LastName.ToUpper()}",
                ReleaseDate = DateOnly.FromDateTime(data.ReleaseDate),
            };
        }
    }
}
