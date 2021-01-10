using GuideRestoGre.Data.Database;
using GuideRestoGre.Data.Models;
using GuideRestoGre.Services.RestaurantService;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GuideRestoGre.TestsCore
{
    [TestClass]
    public class RestaurantServiceTest
    {

        /// <summary>
        /// fake list of Restaurant
        /// </summary>
        private static readonly List<Restaurant> restaurantsDb = new List<Restaurant>()
        {
            new Restaurant(){
                ID = new Guid("00000000-0000-0000-0000-000000000001"),
                Address = new Address()
                    {   ID =  new Guid("00000000-0000-0000-0000-000000000050"),
                        Street = "12 Rue Ampère",
                        City = "Grenoble",
                        ZipCode = "38100"
                    },
                Description = "Très bon restaurant de sushi",
                Mail = "wasabi@grenoble.fr",
                PhoneNumber = 0600000006,
                Name = "Wasabi",
                Grade = new Grade()
                    {   ID = new Guid("00000000-0000-0000-0000-000000000100") ,
                        Comment = "Très déçu qu'ils ne fassent pas de tartiflettes...",
                        LastVisit = new DateTime(2020, 12, 12, 8, 30, 52),
                        Score = 2
                    }
            }
        };

        /// <summary>
        /// Test the Database is created
        /// </summary>
        [TestMethod]
        public void A_Connexion_NoArrange_EnsureCreation()
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

        /// <summary>
        /// Test the constructor of <see cref="RestaurantService"/>
        /// Assert the object is not null
        /// </summary>
        [TestMethod]
        public void B_Constructor_NoArrange_NotNull()
        {
            //Arrange

            //Act
            var restaurantService = new RestaurantService();

            //Assert
            Assert.IsNotNull(restaurantService);
        }

        [TestMethod]
        public void C_Create_NoArrange_NewRestaurantInDb()
        {
            //Arrange
            var restaurantService = new RestaurantService();

            //Act
            restaurantService.Create(restaurantsDb.First());

            //Assert
            Assert.AreEqual(1, restaurantService.GetAll().Count());
        }

        [TestMethod]
        public void D_GetAll_NoArrange_NotNull()
        {
            //Arrange
            var restaurantService = new RestaurantService();

            //Act
            var result = restaurantService.GetAll();

            //Assert
            Assert.IsTrue(result.Any());
        }

        [TestMethod]
        public void Ea_Update_EditNameRestaurant_NameRestaurantChangeInDb()
        {
            //Arrange
            var restaurantService = new RestaurantService();
            var restaurant = restaurantsDb.First();
            restaurant.Name = "updateTest";
            restaurant.Grade.Score = 5;
            restaurant.Address.Street = "test";

            //Act
            restaurantService.Update(restaurant);

            //Assert
            Assert.AreEqual(restaurant.Name, restaurantService.GetAll().First().Name);
        }

        [TestMethod]
        public void F_Delete_TakeFirstRestaurant_OneLessRestaurantInDb()
        {
            //Arrange
            var restaurantService = new RestaurantService();
            var count = restaurantService.GetAll().Count();
            var restaurant = restaurantService.GetAll().First();

            //Act
            restaurantService.Delete(restaurant);

            //Assert
            Assert.AreNotEqual(count, restaurantService.GetAll().Count());
        }
    }
}
