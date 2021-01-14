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
        /// Return all the <see cref="Restaurant"/> matching the given score in the databse
        /// </summary>
        /// <param name="score"></param>
        /// <returns></returns>
        List<Restaurant> GetByScore(int score);

        /// <summary>
        /// Return all the <see cref="Restaurant"/> order by score descending
        /// </summary>
        /// <returns></returns>
        List<Restaurant> GetByBestScore();

        /// <summary>
        /// Return 5 <see cref="Restaurant"/> with the best score
        /// </summary>
        /// <returns></returns>
        List<Restaurant> Get5BestScore();

        /// <summary>
        /// Update a <see cref="Restaurant"/> in the database
        /// </summary>
        /// <param name="restaurant"></param>
        void Update(Restaurant restaurant);

    }
}