using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_1
{   
    public class MenuItem
    {
        public MenuItem() { }

        public MenuItem(int number, string name, decimal price, string descrip, string ingredient)
        {
            MealNumber = number;
            MealName = name;
            MealPrice = price;
            MealDescription = descrip;
            MealIngredient = ingredient;
        }

        public int MealNumber { get; set; }
        public string MealName { get; set; }
        public decimal MealPrice { get; set; }
        public string MealDescription { get; set; }
        public string MealIngredient { get; set; }
    }
}
