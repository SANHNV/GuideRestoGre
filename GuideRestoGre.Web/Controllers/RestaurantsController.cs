using GuideRestoGre.Data.Models;
using GuideRestoGre.Services.RestaurantService;
using GuideRestoGre.Web.ViewsModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace GuideRestoGre.Web.Controllers
{
    public class RestaurantsController : Controller
    {
        private readonly IRestaurantService _restaurantService;

        public RestaurantsController(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }

        // GET: RestaurantsController
        public ActionResult Index()
        {
            var restoVM = new RestaurantsViewModel() { restaurants = _restaurantService.GetAll() };
            return View(restoVM);
        }

        // GET: RestaurantsController
        public ActionResult IndexOrder()
        {
            var restoVM = new RestaurantsViewModel() { restaurants = _restaurantService.GetByBestScore() };
            return View(restoVM);
        }

        // GET: RestaurantsController/Details/5
        public ActionResult Details(Guid id)
        {
            //var resto = new RestaurantsViewModel() { restaurants = _restaurantService.GetById(id) };
            return View();
        }

        // GET: RestaurantsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RestaurantsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Name,PhoneNumber,Description,Mail,Address,Grade")] Restaurant restaurant)
        {
            try
            {
                restaurant.ID = Guid.NewGuid();
                _restaurantService.Create(restaurant);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(restaurant);
            }
        }

        // GET: RestaurantsController/Edit/5
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

            ViewData["AddressCity"] = restaurant.Address.City;
            ViewData["AddressZipCode"] = restaurant.Address.ZipCode;
            ViewData["AddressStreet"] = restaurant.Address.Street;
            return View(restaurant);
        }

        // POST: RestaurantsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ID,Name,PhoneNumber,Description,Mail,Address,Grade")] Restaurant restaurant)
        {
            try
            {
                await _restaurantService.Update(restaurant);

                return RedirectToAction(nameof(Index));
            }
            catch(Exception e)
            {
                Debug.Write("OYE OYE : " + e);
                return View(restaurant);
            }
        }

        // GET: RestaurantsController/Delete/5
        public ActionResult Delete(Guid? id)
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

        // POST: RestaurantsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            try
            {
                _restaurantService.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(Delete));
            }
        }
    }
}
