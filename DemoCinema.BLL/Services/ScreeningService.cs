using DemoCinema.BLL.BusinessExceptions;
using DemoCinema.BLL.Interfaces;
using DemoCinema.BLL.Mappers;
using DemoCinema.BLL.Models;
using DemoCinema.DAL.Interfaces;

namespace DemoCinema.BLL.Services
{
    public class ScreeningService : IScreeningService
    {
        private readonly IScreeningRepository _screeningRepository;
        private readonly IMovieRepository _movieRepository;
        public ScreeningService(IScreeningRepository screeningRepository, IMovieRepository movieRepository)
        {
            _screeningRepository = screeningRepository;
            _movieRepository = movieRepository;
        }

        public ScreeningModel Add(ScreeningModel data)
        {
            MovieModel? movie = _movieRepository.GetById(data.MovieId)?.ToModel();
            if(movie is null) 
                throw new ScreeningMovieException();

            if (data.Schedule < movie.ReleaseDate.AddDays(-5))
                throw new ScreeningDateException();

            int id = _screeningRepository.Insert(data.ToEntity());

            data.Movie = movie;
            data.Id = id; 
            return data;
        }

        public bool Cancel(int id)
        {
            try
            {
            _screeningRepository.Cancel(id);
                return true;
            }
            catch { return false; }
        }

        public bool Delete(int id)
        {
            try
            {
                _screeningRepository.Delete(id);
                return true;
            }
            catch { return false; }
        }

        public IEnumerable<ScreeningModel> GetByDate(DateTime date)
        {
            return _screeningRepository.GetMany(s => s.Schedule == date)
                                       .Select(ScreeningMapper.ToModel);
        }

        public IEnumerable<ScreeningModel> GetByMovie(int movieId)
        {
            return _screeningRepository.GetMany(s => s.MovieId == movieId)
                                       .Select(ScreeningMapper.ToModel);
        }
    }
}
