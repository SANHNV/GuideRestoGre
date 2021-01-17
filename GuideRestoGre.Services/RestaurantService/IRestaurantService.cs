using GuideRestoGre.Data.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        /// Delete a <see cref="Restaurant"/> in the database thanks to it id
        /// </summary>
        /// <param name="id"></param>
        Task Delete(Guid id);

        /// <summary>
        /// Return all the <see cref="Restaurant"/> in the database
        /// </summary>
        /// <returns></returns>
        List<Restaurant> GetAll();

        /// <summary>
        /// Get a <see cref="Restaurant"/> by id or return default
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Restaurant GetById(Guid? id);

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
        Task Update(Restaurant restaurant);
    }
}