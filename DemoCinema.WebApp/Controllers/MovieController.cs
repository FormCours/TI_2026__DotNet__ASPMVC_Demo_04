using DemoCinema.BLL.Interfaces;
using DemoCinema.WebApp.Mappers;
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
                                    .Select(MovieMapper.ToVM);

            return View(data);
        }

        public IActionResult Details([FromRoute] int id)
        {
            MovieViewModel movie = _movieService.GetById(id).ToVM();
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
            {
                return View(data);
            }

            _movieService.Add(data.ToModel());

            return RedirectToAction(nameof(Index));
        }
    }
}
