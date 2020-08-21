using System;
using System.Collections.Generic;
using _01_Challange;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _01_Challenge_Test_KomodoCafe
{
    [TestClass]
    public class MenuItemsRepositoryTest
    {
        private MenuItemsRepository _repo;
        private MenuItems _item;
        [TestInitialize]
        
        [TestMethod]
        public void MenuInitalize()
        {
            List<string> burgIng = new List<string>();
            burgIng.Add("Bun");
            burgIng.Add("Patty");
            burgIng.Add("Lettuce");
            burgIng.Add("Two Pickles");
            MenuItems newItem = new MenuItems("Burger", "6", "Tasty", 5.99m, burgIng);

            Assert.AreEqual("Burger", newItem.MealName);
            Assert.AreEqual("6", newItem.MealNumber);
            Assert.AreEqual("Tasty", newItem.Description);
        }
        [TestMethod]
        public void GetItemByName_ShouldGetCorrectItem()
        {
            //Arrange
            var cafe = new MenuItemsRepository();
            List<string> burgIng = new List<string>();
            burgIng.Add("Bun");
            burgIng.Add("Patty");
            burgIng.Add("Lettuce");
            burgIng.Add("Two Pickles");
            MenuItems burg = new MenuItems("Burger", "6", "Tasty", 5.99m, burgIng);
            List<string> dogIng = new List<string>();
            dogIng.Add("Bun");
            dogIng.Add("Dog");
            MenuItems dog = new MenuItems("Dog", "7", "Tasty", 5.99m, dogIng);
            List<string> saladIng = new List<string>();
            saladIng.Add("Leafs");
            saladIng.Add("GingerSauce");
            MenuItems salad = new MenuItems("Salad", "8", "MostTasty", 5.99m, saladIng);

            //Act
            cafe.AddItemsToDirectory(burg);
            cafe.AddItemsToDirectory(dog);
            cafe.AddItemsToDirectory(salad);
            var specificItem = cafe.GetItemByName("salad");

            //Assert
            Assert.AreEqual(salad, specificItem);
        }
        [TestMethod]
        public void UpdateItem_ShouldGetUpdatedItem()
        {
            var cafe = new MenuItemsRepository();
            List<string> dogIng = new List<string>();
            dogIng.Add("Bun");
            dogIng.Add("Dog");
            MenuItems dog = new MenuItems("Dog", "7", "Tasty", 5.99m, dogIng);
            List<string> saladIng = new List<string>();
            saladIng.Add("Leafs");
            saladIng.Add("GingerSauce");
            MenuItems salad = new MenuItems("Salad", "8", "MostTasty", 5.99m, saladIng);


            cafe.AddItemsToDirectory(dog);
            cafe.UpdateExistingItemsInDirectory("dog", salad);

            Assert.IsNotNull(cafe.GetItemByName("Salad"));

        }

        [TestMethod]
        public void DeleteItem_ShouldGetDeletedItem()
        {
            var cafe = new MenuItemsRepository();
            List<string> dogIng = new List<string>();
            dogIng.Add("Bun");
            dogIng.Add("Dog");
            MenuItems dog = new MenuItems("Dog", "7", "Tasty", 5.99m, dogIng);
            List<string> saladIng = new List<string>();
            saladIng.Add("Leafs");
            saladIng.Add("GingerSauce");
            MenuItems salad = new MenuItems("Salad", "8", "MostTasty", 5.99m, saladIng);


            cafe.AddItemsToDirectory(dog);
            cafe.DeleteItemByName("dog");

            Assert.IsNull(cafe.GetItemByName("dog"));

        }
    }
}
