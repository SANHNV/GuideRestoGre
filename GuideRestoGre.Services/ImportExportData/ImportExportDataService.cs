using GuideRestoGre.Data.Models;
using GuideRestoGre.Services.RestaurantService;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace GuideRestoGre.Services.ImportExportData
{
    /// <summary>
    /// Import and export Data in json to the database
    /// </summary>
    public class ImportExportDataService
    {
        private List<Restaurant> restaurants { get; set; }

        private readonly IRestaurantService restaurantService;

        /// <summary>
        /// Constructor
        /// </summary>
        public ImportExportDataService(IRestaurantService restaurantService) {

            restaurants = new List<Restaurant>();
            this.restaurantService = restaurantService;
        }

        #region public Methods

        /// <summary>
        /// Import data from json file to database
        /// </summary>
        /// <param name="path"></param>
        public void ImportData(string path)
        {
            using (var sr = new StreamReader(path))
            {
                restaurants = JsonConvert.DeserializeObject<List<Restaurant>>(sr.ReadToEnd());
            }

            foreach (var restaurant in restaurants)
            {
                restaurantService.Create(restaurant);
            }
        }

        /// <summary>
        /// Export data from database to json file
        /// </summary>
        /// <param name="path"></param>
        public void ExportData(string path)
        {
            restaurants = restaurantService.GetAll();

            var json = JsonConvert.SerializeObject(restaurants);

            using (var streamWriter = new StreamWriter(path))
            {
                foreach(var line in json)
                {
                    streamWriter.WriteLine(line);
                }
            }
        }

        #endregion
    }
}
