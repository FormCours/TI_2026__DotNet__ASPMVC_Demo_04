using DemoCinema.DAL.Entities;
using DemoCinema.DAL.Interfaces;

namespace DemoCinema.DAL.Repositories
{
    public class MovieStaticRepository : IMovieRepository
    {
        private readonly DataStaticContext context;
        public MovieStaticRepository(DataStaticContext context)
        {
            this.context = context;
        }

        public IEnumerable<MovieEntity> GetAll()
        {
            return context.Movies.AsReadOnly();
        }

        public MovieEntity? GetById(int id)
        {
            return context.Movies.SingleOrDefault(m => m.Id == id);
        }

        public int Insert(MovieEntity data)
        {
            MovieEntity movieToAdd = new MovieEntity
            {
                Id = context.NextMovieId,
                Title = data.Title,
                Desc = data.Desc.IsWhiteSpace() ? null : data.Desc,
                Director = data.Director,
                Genres = data.Genres,
                Rating = data.Rating,
                ReleaseDate = data.ReleaseDate
            };
            context.NextMovieId++;

            context.Movies.Add(movieToAdd);

            return movieToAdd.Id;
        }
    }
}
