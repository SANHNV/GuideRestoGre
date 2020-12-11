using GuideRestoGre.Data.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GuideRestoGre.Services.ImportExportData
{
    /// <summary>
    /// Import and export Data in json to the database
    /// </summary>
    public class ImportExportDataService
    {
        private List<Restaurant> restaurants { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public ImportExportDataService() {

            restaurants = new List<Restaurant>();
        }

        #region public Methods

        /// <summary>
        /// Import data from json file to database
        /// </summary>
        /// <param name="path"></param>
        public void ImportData(string path)
        {
            //TODO

            using (var sr = new StreamReader(path))
            {
                restaurants = JsonConvert.DeserializeObject<List<Restaurant>>(sr.ReadToEnd());
            }

            foreach (var restaurant in restaurants)
            {
                //Insert in database
            }
        }

        /// <summary>
        /// Export data from database to json file
        /// </summary>
        /// <param name="path"></param>
        public void ExportData(string path)
        {
            //TODO

            //get database

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
