using GuideRestoGre.Data.Database;
using GuideRestoGre.Data.Models;
using GuideRestoGre.Data.Query;
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
            var restaurants = new List<Restaurant>();
            using (var db = new RestaurantDbContext())
            {
                restaurants = db.Restaurants.ToList();
                foreach(var resto in restaurants)
                {
                    resto.Grade = db.Grades.FirstOrDefault(g => g.RestaurantId == resto.ID);
                    resto.Address = db.Addresses.FirstOrDefault(a => a.RestaurantId == resto.ID);
                }
            }
            return restaurants;
        }

        /// <summary>
        /// <inheritdoc/> 
        /// </summary>
        /// <param name="score"></param>
        /// <returns></returns>
        public List<Restaurant> GetByScore(int score)
        {
            var result = new List<Restaurant>();

            using (var db = new RestaurantDbContext())
            {                
                var matchingGrades = db.Grades.FilterByScore(score).ToList();

                foreach(var grade in matchingGrades)
                {
                    var resto = GetAll().FirstOrDefault(r=>r.ID == grade.RestaurantId);
                    if(resto != default)
                    {
                        result.Add(resto);
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// <inheritdoc/> 
        /// </summary>
        /// <returns></returns>
        public List<Restaurant> GetByBestScore()
        {
            return GetAll().AsQueryable().FilterByBestScore().ToList();
        }

        /// <summary>
        /// <inheritdoc/> 
        /// </summary>
        /// <returns></returns>
        public List<Restaurant> Get5BestScore()
        {
            return GetAll().AsQueryable().Best5Score().ToList();
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
                if(db.Restaurants.Where(r => r.ID == restaurant.ID).Any() && restaurant != null)
                    db.Restaurants.Update(restaurant);
                if (restaurant.Grade != null)
                    db.Grades.Update(restaurant.Grade);
                if (restaurant.Address != null)
                    db.Addresses.Update(restaurant.Address);

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
                if (db.Restaurants.Where(r => r.ID == restaurant.ID).Any())
                    db.Restaurants.Remove(restaurant);
                if (db.Grades.Where(g => g.RestaurantId == restaurant.ID).Any())
                    db.Grades.Remove(restaurant.Grade);
                if (db.Addresses.Where(a => a.RestaurantId == restaurant.ID).Any())
                    db.Addresses.Remove(restaurant.Address);

                db.SaveChanges();
            }
        }
    }
}
