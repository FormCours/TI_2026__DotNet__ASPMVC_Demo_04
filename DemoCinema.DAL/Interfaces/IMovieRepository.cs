using DemoCinema.DAL.Entities;

namespace DemoCinema.DAL.Interfaces
{
    public interface IMovieRepository
    {
        int Insert(MovieEntity data);

        MovieEntity? GetById(int id);
        IEnumerable<MovieEntity> GetAll();
    }
}
