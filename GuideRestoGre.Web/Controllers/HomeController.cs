using GuideRestoGre.Services.ImportExportData;
using GuideRestoGre.Services.RestaurantService;
using GuideRestoGre.Web.Models;
using GuideRestoGre.Web.ViewsModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;

namespace GuideRestoGre.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IRestaurantService _restaurantService;

        public HomeController(ILogger<HomeController> logger, IRestaurantService restaurantService )
        {
            _logger = logger;
            _restaurantService = restaurantService;
        }

        public IActionResult Index()
        {
            ViewData["ShowButtons"] = false;
            var resto = _restaurantService.Get5BestScore();
            var restoVM = new RestaurantsViewModel() { restaurants = resto };
            return View(restoVM);
        }

        // GET: HomeController/Serialisation
        public IActionResult Serialisation()
        {
            return View(new SerialisationViewModel());
        }

        // POST: HomeController/Serialisation
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Serialisation(SerialisationViewModel serialisationVM)
        {
            var serialisationService = new ImportExportDataService(_restaurantService);

            try { 
                if (serialisationVM.IsImport)
                {
                    //Check if file exists
                    var fileInfo = new System.IO.FileInfo(serialisationVM.Path);
                    serialisationService.ImportData(serialisationVM.Path);
                }
                else
                {
                    serialisationService.ExportData(serialisationVM.Path);
                }
                return RedirectToAction(nameof(Index));

            } catch(Exception e)
            {
                serialisationVM.Error = e.Message;
                return View(serialisationVM);
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
