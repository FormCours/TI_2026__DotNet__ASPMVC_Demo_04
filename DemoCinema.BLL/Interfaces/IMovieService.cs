using DemoCinema.BLL.Models;

namespace DemoCinema.BLL.Interfaces
{
    public interface IMovieService
    {
        MovieModel Add(MovieModel data);

        MovieModel GetById(int id);
        IEnumerable<MovieModel> GetMany(int offset, int limit);
    }
}
