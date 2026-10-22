using DemoCinema.BLL.Interfaces;
using DemoCinema.BLL.Mappers;
using DemoCinema.BLL.Models;
using DemoCinema.DAL.Interfaces;
using DemoCinema.DAL.Repositories;
using System.Linq.Expressions;

namespace DemoCinema.BLL.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public MovieModel Add(MovieModel data)
        {
            // Utilisation du mapping de « MovieModel » vers « MovieEntity »
            // int id = _movieRepository.Insert(MovieMapper.ToEntity(data));
            int id = _movieRepository.Insert(data.ToEntity());

            data.Id = id;
            return data;
        }

        public MovieModel GetById(int id)
        {
            MovieModel? result = _movieRepository.GetById(id)?.ToModel();
            if (result is null)
            {
                throw new Exception();
            }
            return result;
        }

        public IEnumerable<MovieModel> GetMany(int offset, int limit)
        {
            // TODO Gérer l'offset et la limit plus tard

            // return _movieRepository.GetAll().Select(MovieMapper.ToModel);
            return _movieRepository.GetAll().Select(m => m.ToModel());
        }
    }
}
