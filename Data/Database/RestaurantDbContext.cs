using GuideRestoGre.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace GuideRestoGre.Data.Database
{
    /// <summary>
    /// Database context of database RestauDb2020
    /// </summary>
    public class RestaurantDbContext : DbContext
    {
        #region Database sets

        public DbSet<Address> Addresses { get; set; }
        
        public DbSet<Grade> Grades { get; set; }

        public DbSet<Restaurant> Restaurants { get; set; }

        #endregion

        /// <summary>
        /// Configuration to create and/or access SQL database
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"server=MSI\SQLEXPRESS;database=restauDb2020;trusted_connection=true;");
        }
    }
}
