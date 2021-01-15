using GuideRestoGre.Data.Models;
using GuideRestoGre.Services.RestaurantService;
using GuideRestoGre.Web.ViewsModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

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
        public ActionResult Create([Bind("Name,PhoneNumber,Description,Mail")] Restaurant restaurant, string AddressStreet, string AddressZipCode, string AddressCity)
        {
            try
            {
                restaurant.Address.City = AddressCity;
                restaurant.Address.ZipCode = AddressZipCode;
                restaurant.Address.Street = AddressStreet;
                _restaurantService.Create(restaurant);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RestaurantsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RestaurantsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RestaurantsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RestaurantsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
