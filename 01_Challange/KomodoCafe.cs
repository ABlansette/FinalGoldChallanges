using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Challange
{
    class KomodoCafe
    {
        /*
        Your Task:
        Create a Menu Class with properties, constructors, and fields.
        Create a MenuRepository Class that has methods needed.
        Create a Test Class for your repository methods. (You don't need to test your constructors or objects, just your methods)
        Create a Program file that allows the cafe manager to add, delete, and see all items in the menu list.*/
        static void Main(string[] args)
        {
            KomodoCafeUI komodoCafeUI = new KomodoCafeUI();
            komodoCafeUI.Start();
        }
    }
}
