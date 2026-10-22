using DemoCinema.BLL.Interfaces;
using DemoCinema.BLL.Services;
using DemoCinema.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoCinema.WebApp.Controllers
{
    public class MovieController : Controller
    {
        // Config des services utilisé dans le controller
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        // Définition des routes du controller
        public IActionResult Index()
        {
            var data = _movieService.GetMany(1, 100)
                                    .Select(m => new MovieViewModel
                                    {
                                        Id = m.Id,
                                        Title = m.Title,
                                        Desc = m.Desc ?? "N/A",
                                        Genres = m.Genres,
                                        Rating = m.Rating,
                                        Director = $"{m.Director.FirstName} {m.Director.LastName.ToUpper()}",
                                        ReleaseDate = DateOnly.FromDateTime(m.ReleaseDate),
                                    });

            return View(data);
        }

        public IActionResult Details([FromRoute] int id)
        {
            BLL.Models.MovieModel data = _movieService.GetById(id);

            // TODO Refactoring → Mapper 😱
            MovieViewModel movie = new MovieViewModel
            {
                Id = data.Id,
                Title = data.Title,
                Desc = data.Desc ?? "N/A",
                Genres = data.Genres,
                Rating = data.Rating,
                Director = $"{data.Director.FirstName} {data.Director.LastName.ToUpper()}",
                ReleaseDate = DateOnly.FromDateTime(data.ReleaseDate),
            };

            return View(movie);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Create([FromForm] MovieForm data)
        {
            if(!ModelState.IsValid)
            {//
                return View(data);
            }

            _movieService.Add(new BLL.Models.MovieModel
            {
                Title = data.Title,
                Desc = data.Desc,
                Director = new BLL.Models.DirectorModel()
                {
                    FirstName = data.DirectorFirstName,
                    LastName = data.DirectorLastName
                },
                ReleaseDate = data.ReleaseDate.ToDateTime(TimeOnly.MinValue),
                Rating = data.Rating,
                Genres = data.Genres.Where(g => g is not null).ToList(),
            });

            return RedirectToAction(nameof(Index));
        }
    }
}
