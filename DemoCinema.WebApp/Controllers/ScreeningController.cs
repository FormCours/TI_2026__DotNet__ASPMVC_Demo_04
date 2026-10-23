using DemoCinema.BLL.BusinessExceptions;
using DemoCinema.BLL.Interfaces;
using DemoCinema.WebApp.Mappers;
using DemoCinema.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoCinema.WebApp.Controllers
{
    public class ScreeningController : Controller
    {
        private readonly IScreeningService _screeningService;
        private readonly IMovieService _movieService;
        public ScreeningController(IScreeningService screeningService, IMovieService movieService)
        {
            _screeningService = screeningService;
            _movieService = movieService;
        }

        public IActionResult Index()
        {
            IEnumerable<MovieViewModel> movies = _movieService.GetMany(0, 1_000)
                                                              .Select(MovieMapper.ToVM);

            return View(movies);
        }

        public IActionResult ByDate(DateTime date)
        {
            IEnumerable<ScreeningViewModel> results = _screeningService.GetByDate(date)
                                                                       .Select(ScreeningMapper.ToVM);

            return View(results);
        }

        public IActionResult ByMovie(int movieId)
        {
            IEnumerable<ScreeningViewModel> results = _screeningService.GetByMovie(movieId)
                                                                       .Select(ScreeningMapper.ToVM);

            return View(results);
        }

        public IActionResult Create()
        {
            ViewData["Movies"] = _movieService.GetMany(0, 1_000).Select(MovieMapper.ToVM);
            return View();
        }
        [HttpPost]
        public IActionResult Create(ScreeningForm data)
        {
            if(!ModelState.IsValid)
            {
                ViewData["Movies"] = _movieService.GetMany(0, 1_000).Select(MovieMapper.ToVM);
                return View(data);
            }

            try
            {
                _screeningService.Add(data.ToModel());
                return RedirectToAction(nameof(Index));
            }
            catch (ScreeningException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);

                ViewData["Movies"] = _movieService.GetMany(0, 1_000).Select(MovieMapper.ToVM);
                return View();
            }
        }

        public IActionResult Cancel(int id)
        {
            _screeningService.Cancel(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            _screeningService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
