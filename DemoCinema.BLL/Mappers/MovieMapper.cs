using DemoCinema.BLL.Models;
using DemoCinema.DAL.Entities;

namespace DemoCinema.BLL.Mappers
{
    internal static class MovieMapper
    {
        // Méthode d'extension
        // → Doit être dans une classe statique
        // → Le premiere parametre doit être précédé de "this"

        public static MovieModel ToModel(this MovieEntity data)
        {
            string[] director = data.Director.Split("|");

            return new MovieModel()
            {
                Id = data.Id,
                Title = data.Title,
                Desc = data.Desc,
                Director = new DirectorModel() { 
                    FirstName = director[0],
                    LastName = director[1]
                },
                Genres = data.Genres,
                ReleaseDate = data.ReleaseDate,
                Rating = (int)Math.Round(data.Rating * 2)
            };
        }

        public static MovieEntity ToEntity(this MovieModel data)
        {
            return new MovieEntity()
            {
                Id = data.Id,
                Title = data.Title,
                Desc = data.Desc,
                Director = data.Director.FirstName + "|" + data.Director.LastName,
                Genres = data.Genres,
                ReleaseDate = data.ReleaseDate,
                Rating = (double)data.Rating / 2
            };
        }
    }
}
