using GuideRestoGre.Data.Database;
using GuideRestoGre.Data.Models;
using System.Collections.Generic;
using System.Linq;

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

        /// <summary>
        /// <inheritdoc/> 
        /// </summary>
        /// <returns></returns>
        public List<Restaurant> GetAll()
        {
            using (var db = new RestaurantDbContext())
            {
                return db.Restaurants.ToList();
            }
        }

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
        public void Update(Restaurant restaurant)
        {
            using (var db = new RestaurantDbContext())
            {
                db.Restaurants.Attach(restaurant);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="restaurant"></param>
        public void Delete(Restaurant restaurant)
        {
            using (var db = new RestaurantDbContext())
            {
                db.Restaurants.Remove(restaurant);
                db.SaveChanges();
            }
        }
    }
}
