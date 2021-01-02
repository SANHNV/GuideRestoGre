using GuideRestoGre.Data.Models;
using System.Collections.Generic;

namespace GuideRestoGre.Services.RestaurantService
{
    /// <summary>
    /// Interface for Restaurant Service
    /// </summary>
    public interface IRestaurantService
    {
        /// <summary>
        /// Create a <see cref="Restaurant"/> in the database
        /// </summary>
        /// <param name="restaurant"></param>
        void Create(Restaurant restaurant);

        /// <summary>
        /// Delete a <see cref="Restaurant"/> in the database
        /// </summary>
        /// <param name="restaurant"></param>
        void Delete(Restaurant restaurant);

        /// <summary>
        /// Return all the <see cref="Restaurant"/> in the database
        /// </summary>
        /// <returns></returns>
        List<Restaurant> GetAll();

        /// <summary>
        /// Update a <see cref="Restaurant"/> in the database
        /// </summary>
        /// <param name="restaurant"></param>
        void Update(Restaurant restaurant);
    }
}