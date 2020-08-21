using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Challange
{
    public class KomodoCafeUI
    {
        /*Komodo cafe is getting a new menu. The manager wants to be able to create new menu items, update menu items, delete menu items, and receive a list of all items on the cafe's menu. She needs a console app
        The Menu Items:*/

        private readonly MenuItemsRepository _menuRepo = new MenuItemsRepository();
        private bool _isRunning = true;
        public void Start()
        {
            SeedItemList();
            MenuDisplay();
        }

        private void MenuDisplay()
        {
            Console.Clear();
            Console.WriteLine("Welcome To Komodo Cafe! Please Choose an item Below");
            Console.WriteLine(
                "Create. Create New Menu Items\n" +
                "List. List All Items On Menu\n" + 
                "Update. Update Menu Items\n" +
                "Delete. Delete Menu Items\n" +
                "Display. Display An item on the Menu\n" +
                "Exit. Exit");
            string input = Console.ReadLine();
            OpenMenuItem(input);
        }



        private void OpenMenuItem(string userInput)
        {
            string nameInput;
            userInput.ToLower();
            Console.Clear();
            switch (userInput)
            {
                case "create":
                    CreateNewItem();
                    break;
                case "list":
                    DisplayAllContent();
                    break;
                case "delete":
                    //  Add New Streaming Content
                    Console.WriteLine("Please enter the item's name you'd like to delete");
                    nameInput = Console.ReadLine();
                    DeleteItemByName(nameInput);
                    break;
                case "update":
                    //  Update Existing Streaming Content
                    Console.WriteLine("Please enter the item's name you'd like to update");
                    nameInput = Console.ReadLine();
                    UpdateItemByName(nameInput);
                    break;
                case "display":
                    Console.WriteLine("Please enter the item's name you'd like to Display");
                    nameInput = Console.ReadLine();
                    DisplayItemByName(nameInput);
                    break;
                case "exit":
                    // Exit
                    _isRunning = false;
                    return;
                default:
                    // INvalid Selection
                    Console.WriteLine("Invalid Input");
                    break;
            }
            if (_isRunning)
            {
                Console.Clear();
                Console.WriteLine("press any key to return to the menu"); 
                Console.ReadKey();
                MenuDisplay(); 
            }
 
        }
        private void CreateNewItem()
        {
            Console.Write("Enter a Name for your food: ");
            string title = Console.ReadLine();

            Console.Write("Give me Description of your " + title + ": ");
            string description = Console.ReadLine();

            Console.Write("What is the Number for your " + title + ": ");
            string number = Console.ReadLine();


            Console.Write("What is the price of " + title + ": ");
            decimal cost = decimal.Parse(Console.ReadLine());

            Console.Write("How many ingrediants are in " + title + ": ");
            List<string> ingrediants = new List<string>();
            int numOfIngred = int.Parse(Console.ReadLine());
            for (int i = 0; i < numOfIngred; i++)
            {
                Console.WriteLine("Please enter ingrediant #" + (i + 1));
                ingrediants.Add(Console.ReadLine());
            }

            MenuItems newItem = new MenuItems(title, number, description, cost, ingrediants);
            _menuRepo.AddItemsToDirectory(newItem);

        }

        private void DisplayAllContent()
        {
            // Get Content
            List<MenuItems> listOfItems = _menuRepo.GetItemsInDirectory();

            //Display content
            foreach (MenuItems item in listOfItems)
            {
                DisplayItem(item);
                Console.WriteLine();
            }
            Console.ReadLine();
        }

        private void DisplayItem(MenuItems content)
        {
            Console.WriteLine($"{content.MealName}\n" +
            $"# {content.MealNumber}\n" +
            $"{content.Description}\n" +
            $"Ingrediants: "); 
            foreach (string item in content.Ingrediants)
            {
                Console.Write(item + ", ");
            }
            Console.WriteLine("\n" + $"${content.Price}\n");
        }

        private void DeleteItemByName(string name)
        {
            _menuRepo.DeleteItemByName(name);
        }

        private void DisplayItemByName(string name)
        {
            // Display Item
            DisplayItem(_menuRepo.GetItemByName(name));
            Console.ReadLine();
        }

        private void UpdateItemByName(string name)
        {
            // Update Item
            MenuItems newestItem = UserUpdate();
            _menuRepo.UpdateExistingItemsInDirectory(name, newestItem);
        }
        private MenuItems UserUpdate()
        {
            Console.Write("Enter a Name for your food: ");
            string title = Console.ReadLine();

            Console.Write("Give me Description of your " + title + ": ");
            string description = Console.ReadLine();

            Console.Write("What Number is this " + title + ": ");
            string number = Console.ReadLine();


            Console.Write("What is the price of " + title + ": ");
            decimal cost = decimal.Parse(Console.ReadLine());

            Console.Write("How many ingrediants are in " + title + ": ");
            List<string> ingrediants = new List<string>();
            int numOfIngred = int.Parse(Console.ReadLine());
            for (int i = 0; i < numOfIngred; i++)
            {
                Console.WriteLine("Please enter ingrediant #" + (i + 1));
                ingrediants.Add(Console.ReadLine());
            }

            MenuItems newItem = new MenuItems(title, description, number, cost, ingrediants);
            return newItem;


        }


        private void SeedItemList()
        {
            List<string> burgerIngrediants = new List<string>();
            burgerIngrediants.Add("Bun");
            burgerIngrediants.Add("Patty");
            burgerIngrediants.Add("Lettuce");
            burgerIngrediants.Add("Two Pickles");
            MenuItems burger = new MenuItems("Burger", "1", "Tastiess burger in the south west", 6.50m, burgerIngrediants);
            List<string> dogsIngrediants = new List<string>();
            dogsIngrediants.Add("Bun");
            dogsIngrediants.Add("Weiner");
            dogsIngrediants.Add("Ketchup");
            dogsIngrediants.Add("Mustard");
            MenuItems dogs = new MenuItems("Hot Diggity dawg", "2", "Definitly not an actual dog", 4.00m, dogsIngrediants);
            List<string> saladIngrediants = new List<string>();
            saladIngrediants.Add("Leafs");
            saladIngrediants.Add("Gingersauce");
            MenuItems salad = new MenuItems("Healthy leaf thing", "3", "Green stuff", 1000.00m, saladIngrediants);
            List<string> burritoIngrediants = new List<string>();
            burritoIngrediants.Add("tortilla");
            burritoIngrediants.Add("Rice");
            burritoIngrediants.Add("Chicken");
            MenuItems burrito = new MenuItems("Burrito", "4", "tortialla blanket for meat", 7.00m, burritoIngrediants);

            _menuRepo.AddItemsToDirectory(burger);
            _menuRepo.AddItemsToDirectory(dogs);
            _menuRepo.AddItemsToDirectory(salad);
            _menuRepo.AddItemsToDirectory(burrito);
        }
    }
}
