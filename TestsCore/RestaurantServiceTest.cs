using GuideRestoGre.Data.Database;
using GuideRestoGre.Data.Models;
using GuideRestoGre.Services.RestaurantService;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GuideRestoGre.TestsCore
{
    [TestClass]
    public class RestaurantServiceTest
    {
        /// <summary>
        /// List of restaurant to delete
        /// </summary>
        private List<Restaurant> restaurantsToDelete = new List<Restaurant>();

        /// <summary>
        /// Delete all the <see cref="restaurantsToDelete"/> from the databse
        /// </summary>
        private void deleteTestResto()
        {
            var restaurantService = new RestaurantService();

            foreach (var resto in restaurantsToDelete)
            {
                restaurantService.Delete(resto);
            }
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

        /// <summary>
        /// Test <see cref="RestaurantService.Create(Restaurant)"/>
        /// Assert a <see cref="Restaurant"/> was added to the database
        /// </summary>
        [TestMethod]
        public void C_Create_ANewRestaurant_NewRestaurantInDb()
        {
            //Arrange
            var resto = new Restaurant();
            restaurantsToDelete.Add(resto);

            var restaurantService = new RestaurantService();
            var count = restaurantService.GetAll().Count();

            //Act
            restaurantService.Create(resto);

            //Assert
            Assert.AreNotEqual(count, restaurantService.GetAll().Count());

            //Clean up database
            deleteTestResto();
        }

        /// <summary>
        /// Test <see cref="RestaurantService.GetAll"/> with a new restaurant created
        /// Assert the total restaurants count isn't equal after a new restaurant was created
        /// </summary>
        [TestMethod]
        public void Da_GetAll_AddARestaurant_NotNull()
        {
            //Arrange
            var restaurantService = new RestaurantService();
            var countBefore = restaurantService.GetAll().Count();

            restaurantsToDelete.Add(new Restaurant());
            restaurantService.Create(restaurantsToDelete.Last());

            //Act
            var result = restaurantService.GetAll();

            //Assert
            Assert.AreNotEqual(countBefore, result);

            //Clean up database
            deleteTestResto();
        }

        /// <summary>
        /// Test <see cref="RestaurantService.GetByScore(int)"/>
        /// Assert 1 <see cref="Restaurant"/> was return with a score of 5
        /// </summary>
        [TestMethod]
        public void Db_GetByScore_TakeAScore_1RestaurantScore5()
        {
            //Arrange
            var restaurantService = new RestaurantService();
            restaurantsToDelete.Add(new Restaurant() { Grade = new Grade() { Score = 1 } });
            restaurantService.Create(restaurantsToDelete.Last());
            restaurantsToDelete.Add(new Restaurant() { Grade = new Grade() { Score = 5 } });
            restaurantService.Create(restaurantsToDelete.Last());
            restaurantsToDelete.Add(new Restaurant() { Grade = new Grade() { Score = 8 } });
            restaurantService.Create(restaurantsToDelete.Last());

            //Act
            var result = restaurantService.GetByScore(5);

            //Assert
            Assert.AreEqual(1, result.Count());
            Assert.AreEqual(5, result.First().Grade.Score);

            //Clean up database
            deleteTestResto();
        }

        /// <summary>
        /// Test <see cref="RestaurantService.GetByBestScore"/>
        /// Assert the first element return has a score of 9 and is different from the first element of the original list
        /// </summary>
        [TestMethod]
        public void Dc_GetByBestScore_ListRestaurantBefore_ReturnListBestScoredRestaurant()
        {
            //Arrange
            var restaurantService = new RestaurantService();
            restaurantsToDelete.Add(new Restaurant() { Name = "test", Grade = new Grade() { Score = 1 } });
            restaurantService.Create(restaurantsToDelete.Last());
            restaurantsToDelete.Add(new Restaurant() { Name = "test", Grade = new Grade() { Score = 5 } });
            restaurantService.Create(restaurantsToDelete.Last());
            restaurantsToDelete.Add(new Restaurant() { Name = "test", Grade = new Grade() { Score = 9 } });
            restaurantService.Create(restaurantsToDelete.Last());
            var restosBefore = restaurantService.GetAll();

            //Act
            var result = restaurantService.GetByBestScore();

            //Assert
            Assert.AreEqual(9, result.First().Grade.Score);
            Assert.AreNotEqual(restosBefore.First().Grade.Score, result.First().Grade.Score);

            //Clean up database
            deleteTestResto();
        }

        /// <summary>
        /// Test <see cref="RestaurantService.Get5BestScore"/>
        /// Assert the first <see cref="Restaurant"/> result element has a score of 9, the next result element of 8
        /// and the first element of the original list isn't equal to the first element of the order list
        /// </summary>
        [TestMethod]
        public void Dd_Get5BestScore_ListRestaurantBefore_ReturnList5BestScoredRestaurant()
        {
            //Arrange
            var restaurantService = new RestaurantService();
            restaurantsToDelete.Add(new Restaurant() { Grade = new Grade() { Score = 1 } });
            restaurantService.Create(restaurantsToDelete.Last());
            restaurantsToDelete.Add(new Restaurant() { Grade = new Grade() { Score = 3 } });
            restaurantService.Create(restaurantsToDelete.Last());
            restaurantsToDelete.Add(new Restaurant() { Grade = new Grade() { Score = 5 } });
            restaurantService.Create(restaurantsToDelete.Last());
            restaurantsToDelete.Add(new Restaurant() { Grade = new Grade() { Score = 8 } });
            restaurantService.Create(restaurantsToDelete.Last());
            restaurantsToDelete.Add(new Restaurant() { Grade = new Grade() { Score = 9 } });
            restaurantService.Create(restaurantsToDelete.Last());
            var restosBefore = restaurantService.GetAll();

            //Act
            var result = restaurantService.Get5BestScore();

            //Assert
            Assert.AreEqual(9, result.First().Grade.Score);
            Assert.AreNotEqual(restosBefore.First(), result.First());

            //Clean up database
            deleteTestResto();
        }


        /// <summary>
        /// Test <see cref="RestaurantService.Update(Restaurant)"/>
        /// Assert the name, score and street were update in the database
        /// </summary>
        [TestMethod]
        public void E_Update_EditNameRestaurant_NameRestaurantChangeInDb()
        {
            //Arrange
            var restaurantService = new RestaurantService();
            var restaurant = new Restaurant() { ID = new Guid("10000000-0000-0000-0000-000000000000"), Name = "TestUpgarde", Grade = new Grade() { Score = 1 } };
            restaurantsToDelete.Add(restaurant);
            restaurantService.Create(restaurantsToDelete.First());

            restaurant.Name = "updateTest";
            restaurant.Grade.Score = 5;
            restaurant.Address.Street = "test";

            //Act
            restaurantService.Update(restaurant);
            var updateResto = restaurantService.GetAll().Where(e => e.ID == restaurant.ID).FirstOrDefault();

            //Assert
            Assert.AreEqual(restaurant.Name, updateResto.Name);
            Assert.AreEqual(restaurant.Grade.Score, updateResto.Grade.Score);
            Assert.AreEqual(restaurant.Address.Street, updateResto.Address.Street);

            //Clean up database
            deleteTestResto();
        }

        /// <summary>
        /// Test <see cref="RestaurantService.Delete(Restaurant)"/>
        /// Assert the total count of <see cref="Restaurant"/> is different
        /// </summary>
        [TestMethod]
        public void F_Delete_TakeFirstRestaurant_OneLessRestaurantInDb()
        {
            //Arrange
            var restaurantService = new RestaurantService();
            restaurantsToDelete.Add(new Restaurant() { ID = new Guid("11000000-0000-0000-0000-000000000000") });
            restaurantService.Create(restaurantsToDelete.First());
            var count = restaurantService.GetAll().Count();

            //Act
            restaurantService.Delete(restaurantsToDelete.First());

            //Assert
            Assert.AreNotEqual(count, restaurantService.GetAll().Count());

            //Clean up database
            deleteTestResto();

        }
    }
}
