using GuideRestoGre.Data.Database;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GuideRestoGre.TestsCore
{
    /// <summary>
    /// Test Database SQL
    /// </summary>
    [TestClass]
    public class DatabaseTest
    {
        /// <summary>
        /// Test the Database is created
        /// </summary>
        [TestMethod]
        public void Connexion_NoArrange_EnsureCreation()
        {
            //Arrange
            var created = false;

            //Act
            using (var database = new RestaurantDbContext())
            {
                created = database.Database.EnsureCreated();
            }

            //Assert
            Assert.IsTrue(created);
        }
    }
}
