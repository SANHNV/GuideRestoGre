using GuideRestoGre.Data.Models;
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
        public static IQueryable<Restaurant> FilterByScore(this IQueryable<Restaurant> restaurants, int score)
        {
            return restaurants.Where(e => e.Grade.Score == score);
        }

        public static IQueryable<Restaurant> FilterBestScore(this IQueryable<Restaurant> restaurants)
        {
            return restaurants.OrderBy(e=>e.Grade.Score);
        }

        public static IQueryable<Restaurant> Best5Score(this IQueryable<Restaurant> restaurants, int score)
        {
            return restaurants.OrderBy(e => e.Grade.Score).Take(5);
        }
    }
}
