using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Challenge_1;

namespace Challenge_1_Tests
{
    [TestClass]
    public class MenuTests
    {
        private MenuListRepository _menuListRepo;

        [TestInitialize]
        public void Arrange()
        {
            _menuListRepo = new MenuListRepository();
        }

        [TestMethod]
        public void MenuList_AddMenuItemToList_ShouldIncreaseByOne()
        {
            //-- Arrange
            MenuItem menuItem = new MenuItem(6, "Salad", 4.99m, "Good", "Lettuce");
            _menuListRepo.AddItemToList(menuItem);

            //-- Act
            var actual = _menuListRepo.GetMenuItems().Count;
            var expected = 1;

            //-- Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MenuList_FindItemOnList_ShouldFindItem()
        {
            //-- Arrange
            MenuItem menuItemOne = new MenuItem(1, "hamburger", 9.99m, "delicious", "beef patty, lettuce, tomato, and onion");
            MenuItem menuItemTwo = new MenuItem(2, "b.l.t.", 7.99m, "delicious", "bacon, lettuce, tomato");
            MenuItem menuItemThree = new MenuItem(3, "tomato and cheese", 7.99m, "delicious", "tomato, cheese");
            MenuItem menuItemFour = new MenuItem(4, "tuna melt", 8.99m, "delicious", "tuna, bread, cheese");
            MenuItem menuItemFive = new MenuItem(5, "grilled cheese", 4.99m, "delicious", "cheese, bread");

            _menuListRepo.AddItemToList(menuItemOne);
            _menuListRepo.AddItemToList(menuItemTwo);
            _menuListRepo.AddItemToList(menuItemThree);
            _menuListRepo.AddItemToList(menuItemFour);
            _menuListRepo.AddItemToList(menuItemFive);

            //-- Act
            string actual = menuItemOne.MealName;
            string expected = "hamburger";

            //-- Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MenuList_RemoveMenuItemFromList_ShouldHaveCountOfOne()
        {
            //-- Arrange
            //-- Act
            MenuItem menuItem = new MenuItem(6, "Salad", 4.99m, "Good", "Lettuce");
            MenuItem menuItemTwo = new MenuItem(6, "Greens", 8.99m, "Meh", "Arugula");
            _menuListRepo.AddItemToList(menuItem);

            var actual = _menuListRepo.GetMenuItems().Count;
            var expected = 1;

            //-- Assert
            Assert.AreEqual(expected, actual);
        }

    }
}
