using DemoCinema.WebApp.Models;
using DemoCinema.WebApp.Tools;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DemoCinema.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly DemoSingletonTool _singletonTool1;
        private readonly DemoSingletonTool _singletonTool2;
        private readonly DemoScopedTool _scopedTool1;
        private readonly DemoScopedTool _scopedTool2;
        private readonly DemoTransientTool _transientTool1;
        private readonly DemoTransientTool _transientTool2;

        public HomeController(DemoSingletonTool singletonTool1, DemoSingletonTool singletonTool2, DemoScopedTool scopedTool1, DemoScopedTool scopedTool2, DemoTransientTool transientTool1, DemoTransientTool transientTool2)
        {
            this._singletonTool1 = singletonTool1;
            this._singletonTool2 = singletonTool2;
            this._scopedTool1 = scopedTool1;
            this._scopedTool2 = scopedTool2;
            this._transientTool1 = transientTool1;
            this._transientTool2 = transientTool2;
        }

        public IActionResult Index()
        {
            ViewData["DemoIOC"] = new List<string>()
            {
                $"Singleton 1 : {_singletonTool1.InstanceId}",
                $"Singleton 2 : {_singletonTool2.InstanceId}",
                $"Scoped 1 : {_scopedTool1.InstanceId}",
                $"Scoped 2 : {_scopedTool2.InstanceId}",
                $"Transient 1 : {_transientTool1.InstanceId}",
                $"Transient 2 : {_transientTool2.InstanceId}"
            };

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
