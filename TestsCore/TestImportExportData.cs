using Microsoft.VisualStudio.TestTools.UnitTesting;
using GuideRestoGre.Services.ImportExportData;
using GuideRestoGre.Services.RestaurantService;

namespace GuideRestoGre.TestsCore
{
    /// <summary>
    /// Test for <see cref="Services.ImportExportData"/>
    /// </summary>
    [TestClass]
    public class TestImportExportData
    {
        /// <summary>
        /// Test the constructor of <see cref="ImportExportDataService"/> given a restaurantService
        /// Assert the object is not null
        /// </summary>
        [TestMethod]
        public void Constructor_TakeARestaurantService_NotNull()
        {
            //Arrange
            var restaurantService = new RestaurantService();

            //Act
            var importExportData = new ImportExportDataService(restaurantService);

            //Assert
            Assert.IsNotNull(importExportData);
        }
    }
}
