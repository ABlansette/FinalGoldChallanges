using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Challenge
{
    public class ProgramUI
    {
        /*Komodo Insurance
Komodo Insurance is fixing their badging system.

Here's what they need:
An app that maintains a dictionary of details about employee badge information. (Hint: A dictionary is a collection type in C#. You'll want to use that.)

Essentially, an badge will have a badge number that gives access to a specific list of doors. For instance, a developer might have access to Door A1 & A5. A claims agent might have access to B2 & B4.

Your task will be to create the following:
A badge class that has the following properties:
BadgeID
List of door names for access
A badge repository that will have methods that do the following:
Create a dictionary of badges.
The key for the dictionary will be the BadgeID.
The value for the dictionary will be the List of Door Names.


The Program will allow a security staff member to do the following:
create a new badge
update doors on an existing badge.
delete all doors from an existing badge.
show a list with all badge numbers and door access, like this:
Here are some views:
Menu

Hello Security Admin, What would you like to do?

Add a badge
Edit a badge.
List all Badges*/

        private BadgeRepository _BadgeRepo = new BadgeRepository();
        private bool _isRunning = true;

        public void Start()
        {
            SeedData();
            RunMenu();
        }

        private void RunMenu()
        {
            Console.Clear();
            Console.WriteLine(
                "1.  Add A Badge\n" +
                "2.  Edit A Badge\n" +
                "3.  List All Badges\n" +
                "4.  Exit");

            string userInput = Console.ReadLine();

            DeciferSelection(userInput);
        }

        private void DeciferSelection(string userInput)
        {
            while (_isRunning)
            {

                Console.Clear();
                switch (userInput)
                {
                    case "1":
                    case "1.":
                        AddABadge();
                        break;
                    case "2":
                    case "2.":
                        EditABadge();
                        break;
                    case "3":
                    case "3.":
                        ListAllData();
                        break;
                    case "4":
                    case "4.":
                        _isRunning = false;
                        break;

                }
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
                RunMenu();
            }


        }
        private void AddABadge()
        {
            Badge badge = EnterData();
            _BadgeRepo.AddNewBadgeToDictionary(badge);

        }
        private Badge EnterData()
        {

            string badgeID = "00001";
            Console.WriteLine("Please enter a badge number that is 5 digits long (00001-99999)");
            badgeID = Console.ReadLine();
            int newBadgeID = int.Parse(badgeID);
            
            Console.WriteLine("How Many Doors does this Badge have access to?"); 
            string itteration = Console.ReadLine();
            int newItteration = int.Parse(itteration);
            List<string> doors = new List<string>();
            for (int i = 0; i < newItteration; i++)
            {
                Console.Write("Enter a door Name ");
                doors.Add(Console.ReadLine());
            }
            Badge newBadge = new Badge(newBadgeID, doors);
            return newBadge;
        }

        private void EditABadge()
        {
            Console.WriteLine("Which Badge would you like to edit?");
            Console.Write("Badge number: ");
            int id = int.Parse(Console.ReadLine());
            Badge badge = _BadgeRepo.GetBadgeByID(id);
            Console.WriteLine("How Many Doors does this Badge have access to?");
            int itteration = int.Parse(Console.ReadLine());
            List<string> doors = new List<string>();
            for (int i = 0; i < itteration; i++)
            {
                Console.Write("Enter a door Name ");
                doors.Add(Console.ReadLine());
            }
            badge.ListOfDoors = doors;
            _BadgeRepo.UpdateBadge(badge);
        }
        private void ListAllData()
        {
            Console.WriteLine("Key\n" +
                "Badge#\tDoorAccess");
            Dictionary<int, List<string>> newDictionary = _BadgeRepo.GetBadgesInDictionary();
            for (int index = 0; index < newDictionary.Count; index++)
            {
                Display(newDictionary.ElementAt(index).Key, newDictionary[newDictionary.ElementAt(index).Key]);
            }
        }

        private void Display(int id, List<string> doors)
        {
            Console.Write(id + "\t");
            foreach (string item in doors)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }

        private void SeedData()
        {
            List<string> listOne = new List<string>();
            listOne.Add("A1");
            listOne.Add("A6");
            listOne.Add("B1");
            listOne.Add("B6");
            Badge badgeOne = new Badge(12345, listOne);
            _BadgeRepo.AddNewBadgeToDictionary(badgeOne);
            List<string> listTwo = new List<string>();
            listTwo.Add("A1");
            listTwo.Add("A2");
            listTwo.Add("B3");
            listTwo.Add("B4");
            Badge badgeTwo = new Badge(73423, listTwo);
            _BadgeRepo.AddNewBadgeToDictionary(badgeTwo);
            List<string> listThree = new List<string>();
            listThree.Add("A4");
            listThree.Add("A6");
            Badge badgeThree = new Badge(28387, listThree);
            _BadgeRepo.AddNewBadgeToDictionary(badgeThree);
            List<string> listFour = new List<string>();
            listFour.Add("A1");
            listFour.Add("C1");
            listFour.Add("C6");
            listFour.Add("B6");
            Badge badgeFour = new Badge(23793, listFour);
            _BadgeRepo.AddNewBadgeToDictionary(badgeFour);
        }
    }
}
