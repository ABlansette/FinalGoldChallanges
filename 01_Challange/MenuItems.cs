using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Challange
{
    public class MenuItems
    {
        /*
        A meal number, so customers can say "I'll have the #5"
        A meal name
        A description
        A list of ingredients,
        A price*/

        public MenuItems() { }

        public MenuItems(string mealName, string mealNumber, string description, decimal price, List<string> ingrediants)
        {
            MealNumber = mealNumber;
            MealName = mealName;
            Description = description;
            Price = price;
            Ingrediants = ingrediants;
        }

        public string MealNumber { get; set; }
        public string MealName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public List<string> Ingrediants { get; set; }
    }
}
