using GuideRestoGre.Data.Database;
using GuideRestoGre.Data.Models;
using System;
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
                if(db.Restaurants.Where(r => r.ID == restaurant.ID).Any() && restaurant != null)
                    db.Restaurants.Update(restaurant);
                if(db.Grades.Where(g => g.RestaurantId == restaurant.ID).Any() && restaurant.Grade != null)
                    db.Grades.Update(restaurant.Grade);
                if(db.Addresses.Where(a => a.RestaurantId == restaurant.ID).Any() && restaurant.Address != null)
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
                    db.Grades.Remove(GetGradeById(restaurant.ID));
                if (db.Addresses.Where(a => a.RestaurantId == restaurant.ID).Any())
                    db.Addresses.Remove(GetAddressById(restaurant.ID));

                db.SaveChanges();
            }
        }

        private Grade GetGradeById(Guid id)
        {
            using (var db = new RestaurantDbContext())
            {
                return db.Grades.Where(x => x.RestaurantId == id).FirstOrDefault();
            }
        }

        private Address GetAddressById(Guid id)
        {
            using (var db = new RestaurantDbContext())
            {
                return db.Addresses.Where(x => x.RestaurantId == id).FirstOrDefault();
            }
        }
    }
}
