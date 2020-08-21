using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static _02_Challenge.Claim;

namespace _02_Challenge
{
    public class ProgramUI
    {
        /*
         * The app will need methods to do the following:
        Show a claims agent a menu:
        Choose a menu item:
        1. See all claims
        2. Take care of next claim
        3. Enter a new claim
        4. Modify an existing claim
         */

        private bool _isRunning = true;
        private readonly ClaimRepository _claimRepo = new ClaimRepository();
        public void Start()
        {
            AddClaimsToListOfClaims();
            _claimRepo.FixIndexOfItem();
            SelectionScreen();
        }

        private void SelectionScreen()
        {
            _claimRepo.FixIndexOfItem();
            Console.Clear();
            Console.WriteLine(
                "1.  See all claims\n" +
                "2.  Take care of next claim\n" +
                "3.  Enter a new claim\n" +
                "4.  Modify an existing claim\n" +
                "5.  Exit");

            string userInput = Console.ReadLine();

            DoSelection(userInput);
        }

        private void DoSelection(string selection)
        {
            Console.Clear();
            while (_isRunning)
            {

                switch (selection)
                {
                    case "1":
                    case "1.":
                        SeeAllClaims();
                        break;
                    case "2":
                    case "2.":
                        TakeCareOfNextClaim();
                        break;
                    case "3":
                    case "3.":
                        EnterANewClaim();
                        break;
                    case "4":
                    case "4.":
                        ModifyAnExistingClaim();
                        break;
                    case "5":
                    case "5.":
                        _isRunning = false;
                        return;
                    default:
                        Console.WriteLine("Invalid");
                        break;
                }
                Console.WriteLine("Press Any Key To Return To The Selection Screen");
                Console.ReadKey();
                SelectionScreen();
            }
        }

        private void SeeAllClaims()
        {
            Console.WriteLine("ClaimId\t" + "Type\t" + "Description\t\t" + "Amount\t" + "DateOfAccident\t" + "\tDateOfClaim");
            List<Claim> listOfClaims = _claimRepo.GetclaimsInDirectory();
            foreach (Claim item in listOfClaims)
            {
                DisplayClaim(item);
            }
        }
        private void DisplayClaim(Claim item)
        {
            if (item.IsValid == true)
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            Console.WriteLine($"{item.ClaimID}\t" + $"{item.Type}\t" + $"{item.Description}\t\t" + $"${item.ClaimAmount}\t" + $"{item.DateOfIncident}\t" + $"{item.DateOfClaim}\t" + $"{item.IsValid}");
            Console.ForegroundColor = ConsoleColor.White;
        }
        private void DisplayNextClaim(Claim next)
        {
            Console.WriteLine("ClaimID: " + next.ClaimID);
            Console.WriteLine("Type: " + next.Type);
            Console.WriteLine("Description: " + next.Description);
            Console.WriteLine("ClaimAmmount: $" + next.ClaimAmount);
            Console.WriteLine("DateOfIncident: " + next.DateOfIncident);
            Console.WriteLine("DateOfClaim: " + next.DateOfClaim);
            Console.WriteLine("IsValid: " + next.IsValid);
            Console.WriteLine("Would you Like to deal with this claim now? (yes or no)");
            string input = Console.ReadLine();
            TakeOffTop(CheckInput(input), next);

        }

        private void TakeCareOfNextClaim()
        {
            Claim next = _claimRepo.GetItemByID(1);
            DisplayNextClaim(next);
        }
        private bool CheckInput(string input)
        {
            input = input.ToLower();
            if (input == "yes" || input == "y" || input == "ye" || input == "yep" || input == "definitly" || input == "yepp")
            {

                return true;
            }
            else
            {
                return false;
            }
        }

        private void TakeOffTop(bool affirmation, Claim next)
        {
            if (affirmation == true)
            {
                _claimRepo.DeleteClaim(next);
                _claimRepo.FixIndexOfItem();
            }
        }

        private void EnterANewClaim()
        {
            Claim newClaim = new Claim();
            Console.WriteLine("Type: (Car, Home, Theft)");
            newClaim.Type = NewType(Console.ReadLine());
            Console.WriteLine("Description: ");
            newClaim.Description = Console.ReadLine();
            Console.WriteLine("Amount: ");
            newClaim.ClaimAmount = double.Parse(Console.ReadLine());
            Console.WriteLine("DateOfIncident: (YYYY/MM/DD)");
            newClaim.DateOfIncident = NewDate(Console.ReadLine());
            Console.WriteLine("DateOfClaim: (YYYY/MM/DD)");
            newClaim.DateOfClaim = NewDate(Console.ReadLine());

            _claimRepo.AddClaim(newClaim);
            _claimRepo.FixIndexOfItem();
        }

        private ClaimType NewType(string type)
        {
            while (true)
            {
                type = type.ToLower();
                if (type == "car")
                {
                    return ClaimType.Car;
                }
                if (type == "home")
                {
                    return ClaimType.Home;
                }
                if (type == "theft")
                {
                    return ClaimType.Theft;
                }
                Console.WriteLine("Invalid, Type: (Car, Home, Theft)");
                type = Console.ReadLine();
            }
        }

        private DateTime NewDate(string newDate)
        {
            while (true)
            {
                if (newDate.Length == 10)
                {
                    if (newDate[4] == '/' && newDate[7] == '/')
                    {
                        return DateTime.Parse(newDate);
                    }
                }
                Console.WriteLine("Invalid, DateOfIncident: (YYYY/MM/DD)");
                newDate = Console.ReadLine();
            }
        }

        private void ModifyAnExistingClaim()
        {
            Claim newClaim = new Claim();
            Console.WriteLine("Which Claim would you like too change?");
            newClaim.ClaimID = int.Parse(Console.ReadLine());
            Console.WriteLine("Type: (Car, Home, Theft)");
            newClaim.Type = NewType(Console.ReadLine());
            Console.WriteLine("Description: ");
            newClaim.Description = Console.ReadLine();
            Console.WriteLine("Amount: ");
            newClaim.ClaimAmount = double.Parse(Console.ReadLine());
            Console.WriteLine("DateOfIncident: (YYYY/MM/DD)");
            newClaim.DateOfIncident = NewDate(Console.ReadLine());
            Console.WriteLine("DateOfClaim: (YYYY/MM/DD)");
            newClaim.DateOfClaim = NewDate(Console.ReadLine());

            _claimRepo.UpdateItem(newClaim.ClaimID, newClaim);
        }

        private void AddClaimsToListOfClaims()
        {
            DateTime crashIncident = new DateTime(2019, 01, 02);
            DateTime crashClaim = new DateTime(2019, 01, 01);
            Claim Crash = new Claim(1, ClaimType.Car, "Crash on 161st", 1000, crashIncident, crashClaim);
            DateTime housefireIncident = new DateTime(2019, 01, 02);
            DateTime houseFireClaim = new DateTime(2019, 01, 01);
            Claim HouseFire = new Claim(2, ClaimType.Home, "oven fire", 3456, housefireIncident, houseFireClaim);
            DateTime stolenPhoneIncident = new DateTime(2019, 01, 02);
            DateTime stolenPhoneClaim = new DateTime(2019, 01, 01);
            Claim StolenPhone = new Claim(3, ClaimType.Theft, "Stolen Phone", 306, stolenPhoneIncident, stolenPhoneClaim);

            _claimRepo.AddClaim(Crash);
            _claimRepo.AddClaim(HouseFire);
            _claimRepo.AddClaim(StolenPhone);
        }
    }
}
