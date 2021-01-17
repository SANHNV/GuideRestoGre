using GuideRestoGre.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GuideRestoGre.Data.Query
{
    /// <summary>
    /// Query extension
    /// </summary>
    public static class Query
    {
        /// <summary>
        /// Include <see cref="Grade"/> and <see cref="Address"/> to <see cref="Restaurant"/>
        /// </summary>
        /// <param name="restaurants"></param>
        /// <returns></returns>
        public static IQueryable<Restaurant> GetAll(this IQueryable<Restaurant> restaurants)
        {
            return restaurants.Include(r => r.Address).Include(r => r.Grade);
        }

        /// <summary>
        /// Filter a list of <see cref="Restaurant"/> to return the one with the corresponding id or default
        /// </summary>
        /// <param name="restaurants"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Restaurant FilterById(this IQueryable<Restaurant> restaurants, Guid? id)
        {
            return restaurants.FirstOrDefault(r => r.ID == id);
        }

        /// <summary>
        /// Filter a List of <see cref="Restaurant"/> with the given score
        /// </summary>
        /// <param name="restaurants"></param>
        /// <param name="score"></param>
        /// <returns>List of <see cref="Restaurant"/></returns>
        public static IQueryable<Restaurant> FilterByScore(this IQueryable<Restaurant> restaurants, int score)
        {
            return restaurants.Where(e => e.Grade.Score == score);
        }

        /// <summary>
        /// Filter a List of <see cref="Restaurant"/> by Score
        /// </summary>
        /// <param name="restaurants"></param>
        /// <returns>List of <see cref="Restaurant"/></returns>
        public static IQueryable<Restaurant> FilterByBestScore(this IQueryable<Restaurant> restaurants)
        {
            return restaurants.OrderByDescending(e => e.Grade.Score);
        }

        /// <summary>
        /// Filter a List of <see cref="Restaurant"/> by Score and keep the five best
        /// </summary>
        /// <param name="restaurants"></param>
        /// <param name="score"></param>
        /// <returns>List of <see cref="Restaurant"/></returns>
        public static IQueryable<Restaurant> Best5Score(this IQueryable<Restaurant> restaurants)
        {
            return restaurants.OrderByDescending(e => e.Grade.Score).Take(5);
        }
    }
}
