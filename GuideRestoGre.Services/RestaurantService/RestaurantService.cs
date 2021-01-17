using GuideRestoGre.Data.Database;
using GuideRestoGre.Data.Models;
using GuideRestoGre.Data.Query;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuideRestoGre.Services.RestaurantService
{
    /// <summary>
    /// Restaurant Service with CRUD methods
    /// </summary>
    public class RestaurantService : IRestaurantService
    {
        /// <summary>
        /// Constructor of <see cref="RestaurantService"/>
        /// </summary>
        public RestaurantService()
        {
        }

        #region GET

        /// <summary>
        /// <inheritdoc/> 
        /// </summary>
        /// <returns></returns>
        public List<Restaurant> GetAll()
        {
            using (var db = new RestaurantDbContext())
            {
                return db.Restaurants.GetAll().ToList();
            }
        }

        /// <summary>
        /// <inheritdoc/> 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Restaurant GetById(Guid? id)
        {
            using(var db = new RestaurantDbContext())
            {
                var result = db.Restaurants.GetAll().FirstOrDefault(r => r.ID == id);
                return result;
            }
        }

        /// <summary>
        /// <inheritdoc/> 
        /// </summary>
        /// <param name="score"></param>
        /// <returns></returns>
        public List<Restaurant> GetByScore(int score)
        {
            using (var db = new RestaurantDbContext())
            {
                return db.Restaurants.GetAll().FilterByScore(score).ToList();
            }
        }

        /// <summary>
        /// <inheritdoc/> 
        /// </summary>
        /// <returns></returns>
        public List<Restaurant> GetByBestScore()
        {
            using (var db = new RestaurantDbContext())
            {
                return db.Restaurants.GetAll().FilterByBestScore().ToList();
            }
        }

        /// <summary>
        /// <inheritdoc/> 
        /// </summary>
        /// <returns></returns>
        public List<Restaurant> Get5BestScore()
        {
            using (var db = new RestaurantDbContext())
            {
                return db.Restaurants.GetAll().Best5Score().ToList();
            }
        }

        #endregion

        #region CUD

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="restaurant"></param>
        public void Create(Restaurant restaurant)
        {
            using (var db = new RestaurantDbContext())
            {
                db.Restaurants.Add(restaurant);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="restaurant"></param>
        public async Task Update(Restaurant restaurant)
        {
            if (RestaurantExists(restaurant.ID))
            {
                using (var db = new RestaurantDbContext())
                {
                    db.Restaurants.Update(restaurant);

                    await db.SaveChangesAsync();
                }
            }
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="restaurant"></param>
        public async Task Delete(Guid id)
        {
            using (var db = new RestaurantDbContext())
            {
                var restaurant = GetById(id);
                if (restaurant.ID != null)
                    db.Restaurants.Remove(restaurant);

                db.SaveChanges();
            }
        }

        #endregion

        /// <summary>
        /// Return true if the <see cref="Restaurant.ID"/> exists
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool RestaurantExists(Guid id)
        {
            using (var db = new RestaurantDbContext())
            {
                return db.Restaurants.Any(e => e.ID == id);
            }
        }
    }
}
