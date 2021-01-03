﻿using GuideRestoGre.Data.Models;
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
        public static IQueryable<Restaurant> FilterBestScore(this IQueryable<Restaurant> restaurants)
        {
            return restaurants.OrderByDescending(e=>e.Grade.Score);
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