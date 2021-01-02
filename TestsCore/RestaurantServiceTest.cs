using GuideRestoGre.Data.Models;
using GuideRestoGre.Services.RestaurantService;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
            },
            new Restaurant(){
                ID = new Guid("00000000-0000-0000-0000-000000000002"),
                Address = new Address()
                    {   ID =  new Guid("00000000-0000-0000-0000-000000000052"),
                        Street = "51 Rue Stalingrad",
                        City = "Grenoble",
                        ZipCode = "38100"
                    },
                Description = "Le plantain doit être bien cuit, question de survie.",
                Mail = "departement51@grenoble.com",
                PhoneNumber = 0600000006,
                Name = "Département 51",
                Grade = new Grade()
                    {   ID = new Guid("00000000-0000-0000-0000-000000000102") ,
                        Comment = "C'était copieux!",
                        LastVisit = new DateTime(2019, 10, 30, 8, 30, 52),
                        Score = 2
                    }
            },
            new Restaurant(){
                ID = new Guid("00000000-0000-0000-0000-000000000003"),
                Address = new Address()
                    {   ID =  new Guid("00000000-0000-0000-0000-000000000053"),
                        Street = "5600 avenue de la Gare",
                        City = "Grenoble",
                        ZipCode = "38000"
                    },
                Description = "Raviole, tourton et autres spécialités du Champsaure à côté de chez vous.",
                Mail = "oreilledane@grenoble.fr",
                PhoneNumber = 0600000006,
                Name = "L'Oreille d'Ane",
                Grade = new Grade()
                    {   ID = new Guid("00000000-0000-0000-0000-000000000103") ,
                        Comment = "Je reviendais encore et toujours, c'ets plus près que Gap.",
                        LastVisit = new DateTime(2012, 6, 6, 8, 30, 52),
                        Score = 9
                    }
            },
            new Restaurant(){
                ID = new Guid("00000000-0000-0000-0000-000000000004"),
                Address = new Address()
                    {   ID =  new Guid("00000000-0000-0000-0000-000000000054"),
                        Street = "123 rue des bois",
                        City = "Valence",
                        ZipCode = "26000"
                    },
                Description = "Cadre chaleur aux allures provençales",
                Mail = "unairdailleurs@valence.net",
                PhoneNumber = 0600000006,
                Name = "Un Air D'Ailleurs",
                Grade = new Grade()
                    {   ID = new Guid("00000000-0000-0000-0000-000000000104") ,
                        Comment = "Vous ne voulez pas déménager à Grenoble, si possible à moins de 100m de chez moi ?",
                        LastVisit = new DateTime(2005, 5, 1, 8, 30, 52),
                        Score = 5
                    }
            },
            new Restaurant(){
                ID = new Guid("00000000-0000-0000-0000-000000000005"),
                Address = new Address()
                    {   ID =  new Guid("00000000-0000-0000-0000-000000000055"),
                        Street = "456 rue des cerises",
                        City = "Grenoble",
                        ZipCode = "38100"
                    },
                Description = "Perché, local, bio et bon pour vous",
                Mail = "mapoule@mongrenoble.monfr",
                PhoneNumber = 0600000006,
                Name = "La Poule Perchée",
                Grade = new Grade()
                    {   ID = new Guid("00000000-0000-0000-0000-000000000105") ,
                        Comment = "Alors, il parait qu'un livre de recettes\n est publié pour Noël ?",
                        LastVisit = new DateTime(2020, 12, 12, 8, 30, 52),
                        Score = 8
                    }
            },
            new Restaurant(){
                ID = new Guid("00000000-0000-0000-0000-000000000006"),
                Address = new Address()
                    {   ID =  new Guid("00000000-0000-0000-0000-000000000056")},
                Description = "Secret à partager",
                Mail = "secret@secret.secret",
                PhoneNumber = 0600000006,
                Name = "Secret",
                Grade = new Grade()
                    {   ID = new Guid("00000000-0000-0000-0000-000000000106") ,
                        Comment = "Secret... \n\n\n\nsecret.",
                        LastVisit = new DateTime(2020, 10, 10, 8, 30, 52),
                        Score = 7
                    }
            },
            new Restaurant(){
                ID = new Guid("00000000-0000-0000-0000-000000000007"),
                Address = new Address()
                    {   ID =  new Guid("00000000-0000-0000-0000-000000000057"),
                        Street = "12 Rue Last",
                        City = "Grenoble",
                        ZipCode = "38100"
                    },
                Description = "Last Restaurant of last test",
                Mail = "lastrestaurant@grenoble.fr",
                PhoneNumber = 0600000006,
                Name = "LastRestaurat",
                Grade = new Grade()
                    {   ID = new Guid("00000000-0000-0000-0000-000000000107") ,
                        Comment = "Last Restaurant...",
                        LastVisit = new DateTime(2020, 12, 12, 8, 30, 52),
                        Score = 2
                    }
            }
        };

        /// <summary>
        /// Test the constructor of <see cref="RestaurantService"/>
        /// Assert the object is not null
        /// </summary>
        [TestMethod]
        public void Constructor_NoArrange_NotNull()
        {
            //Arrange

            //Act
            var restaurantService = new RestaurantService();

            //Assert
            Assert.IsNotNull(restaurantService);
        }

        [TestMethod]
        public void Create_NoArrange_NewRestaurantInDb()
        {
            //Arrange
            var restaurantService = new RestaurantService();

            //Act
            restaurantService.Create(restaurantsDb.First());

            //Assert
            Assert.AreEqual(1, restaurantService.GetAll().Count());
        }

        [TestMethod]
        public void GetAll_NoArrange_NotNull()
        {
            //Arrange
            var restaurantService = new RestaurantService();
            restaurantService.Create(restaurantsDb.First());

            //Act
            var result = restaurantService.GetAll();

            //Assert
            Assert.IsTrue(result.Any());
        }

        [TestMethod]
        public void Update_EditNameRestaurant_NameRestaurantChangeInDb()
        {
            //Arrange
            var restaurantService = new RestaurantService();
            var restaurant = restaurantsDb.First();
            restaurant.Name = "updateTest";

            //Act
            restaurantService.Update(restaurant);

            //Assert
            Assert.AreEqual(restaurant.Name, restaurantService.GetAll().First().Name);
        }

        [TestMethod]
        public void Delete_TakeFirstRestaurant_OneLessRestaurantInDb()
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
