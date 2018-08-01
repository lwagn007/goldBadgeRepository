using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_1
{
    public class MenuListRepository
    {
        private List<MenuItem> _menuItems = new List<MenuItem>();

        public void AddItemToList(MenuItem item)
        {
            _menuItems.Add(item);
        }

        public void RemoveItemFromList(MenuItem item)
        {
            _menuItems.Remove(item);
        }

        public List<MenuItem> GetMenuItems()
        {
            return _menuItems;
        }

        public MenuItem FindItemFromMenu(string mealName)
        {
            var item = new MenuItem();

            foreach(var menuItem in _menuItems)
            {
                if (mealName == menuItem.MealName)
                {
                    item = menuItem;
                    break;
                }
            }
            return item;
        }
    }
}
