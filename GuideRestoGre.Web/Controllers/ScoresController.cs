using GuideRestoGre.Data.Models;
using GuideRestoGre.Services.RestaurantService;
using GuideRestoGre.Web.ViewsModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace GuideRestoGre.Web.Controllers
{
    public class ScoresController : Controller
    {
        private readonly IRestaurantService _restaurantService;

        public ScoresController(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }

        // GET: ScoresController
        public ActionResult Index()
        {
            return View(new RestaurantsViewModel() { restaurants = _restaurantService.GetByBestScore() });
        }

        // GET: ScoresController/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restaurant = _restaurantService.GetById(id);

            if (restaurant == null)
            {
                return NotFound();
            }

            return View(restaurant);
        }


        // POST: ScoresController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ID,Name,PhoneNumber,Description,Mail,Address,Grade")] Restaurant restaurant)
        {
            try
            {
                await _restaurantService.Update(restaurant);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(restaurant);
            }
        }

    }
}
