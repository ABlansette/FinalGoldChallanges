using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Challange
{
    public class MenuItemsRepository
    {
        private List<MenuItems> _menuDirectory = new List<MenuItems>();
        //CRUD

        //Create
        public void AddItemsToDirectory(MenuItems item)
        {
            _menuDirectory.Add(item);
        }

        //Read
        public List<MenuItems> GetItemsInDirectory()
        {
            return _menuDirectory;
        }

        public MenuItems GetItemByName(string name)
        {
            foreach (MenuItems item in _menuDirectory)
            {
                if (item.MealName.ToUpper() == name.ToUpper())
                {
                    return item;
                }
            }
            return null;
        }


        //Update
        public void UpdateExistingItemsInDirectory(string name, MenuItems newItem)
        {
            foreach (MenuItems item in _menuDirectory)
            {

                if (item.MealName.ToUpper() == name.ToUpper())
                {
                    item.MealName = newItem.MealName;
                    item.Description = newItem.Description;
                    item.MealNumber = newItem.MealNumber;
                    item.Price = newItem.Price;
                    item.Ingrediants = newItem.Ingrediants;
                }
            }
        }

        //Delete
        public bool DeleteExistingItem(MenuItems item)
        {
            return _menuDirectory.Remove(item);
        }
        public bool DeleteItemByName(string name)
        {
            MenuItems targetItem = GetItemByName(name);
            return DeleteExistingItem(targetItem);
        }
    }
}
