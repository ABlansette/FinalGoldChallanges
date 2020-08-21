using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Challenge
{
    /*A badge class that has the following properties:
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
    public class Badge
    {
        public Badge() { }
        public Badge(int badgeID, List<string> listOfDoors)
        {
            BadgeID = badgeID;
            ListOfDoors = listOfDoors;
        }

        public int BadgeID { get; set; }
        public List<string> ListOfDoors = new List<string>();

    }
}
