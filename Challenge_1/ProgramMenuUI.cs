using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_1
{
    public class ProgramMenuUI
    {
        private MenuListRepository _menuListRepo = new MenuListRepository();

        public void Run()
        {
            CreateMenuList();

            StartMenu();
        }

        private void StartMenu()
        {
            ShowStartMenu();

            bool continueToRun = true;

            while(continueToRun)
            {
                int choice = GetAndParseMenuChoice();

                switch (choice)
                {
                    case 1:
                        PrintMenu();
                        break;
                    case 2:
                        AddItemToList();
                        break;
                    case 3:
                        RemoveItemFromMenuByName();
                        break;
                    case 4:
                        ShowStartMenu();
                        break;
                    case 5:
                        Console.Clear();
                        break;
                    case 6:
                        continueToRun = false;
                        break;
                    default:
                        ShowStartMenu();
                        break;
                }
            }
        }

        private void CreateMenuList()
        {
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
        }

        private void ShowStartMenu()
        {
            Console.WriteLine("What would you like to do? \n" +
                "1. Show all menu items. \n" +
                "2. Add a menu item. \n" +
                "3. Remove a menu item. \n" +
                "4. Show Console Menu \n" +
                "5. Clear Console. \n" +
                "6. Exit. \n");
        }

        private int GetAndParseMenuChoice()
        {
            Console.WriteLine("Please choose what you'd like to do from the menu. To open Options Menu enter 4. Enter input as number:");
            string choiceAsString = Console.ReadLine();
            int choice = Int32.Parse(choiceAsString);

            return choice;
        }

        private void PrintMenu()
        {
            var items = _menuListRepo.GetMenuItems();
            foreach(MenuItem item in items)
            {
                Console.WriteLine($"Meal Number: {item.MealNumber} \r\n" +
                    $"Meal Name: {item.MealName} \r\n" +
                    $"Meal Price: {item.MealPrice} \r\n" +
                    $"Meal Description: {item.MealDescription} \r\n" +
                    $"Meal Ingredients: {item.MealIngredient} \r\n");
            }
        }

        private void AddItemToList()
        {
            Console.WriteLine("Please follow the prompts to add a new menu item.");
            MenuItem menuItem = new MenuItem();

            Console.WriteLine("Please enter number item will be on list. Must be above 5.");
            menuItem.MealNumber = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Please enter name item will be on list.");
            menuItem.MealName = Console.ReadLine();

            Console.WriteLine("Please enter price of item.");
            menuItem.MealPrice = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine("Please enter description of item.");
            menuItem.MealDescription = Console.ReadLine();

            Console.WriteLine("Please enter ingredients used in item.");
            menuItem.MealIngredient = Console.ReadLine();

            _menuListRepo.AddItemToList(menuItem);
            Console.WriteLine("Item was added to the menu successfully.");
        }

        private void RemoveItemFromMenuByName()
        {
            Console.WriteLine("What item would you like to remove? Please enter meal name.");
            var mealName = Console.ReadLine();
            var item = _menuListRepo.FindItemFromMenu(mealName);

            _menuListRepo.RemoveItemFromList(item);

            Console.WriteLine("The item was removed from the menu.");
        }
    }
}
