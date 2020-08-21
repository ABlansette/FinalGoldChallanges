using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Challenge
{
    public class BadgeRepository
    {
        /*
        A badge repository that will have methods that do the following:
        Create a dictionary of badges.
        The key for the dictionary will be the BadgeID.
        The value for the dictionary will be the List of Door Names.

        The Program will allow a security staff member to do the following:
        create a new badge
        update doors on an existing badge.
        delete all doors from an existing badge.
        show a list with all badge numbers and door access, like this:
        Here are some views:*/

        private Badge badge = new Badge();
        Dictionary<int, List<string>> doorAccessDictionary = new Dictionary<int, List<string>>();

        //CRUD
        // Create 
        public void AddNewBadgeToDictionary(Badge badge)
        {
            doorAccessDictionary.Add(badge.BadgeID, badge.ListOfDoors);
        }

        // Read
        public Dictionary<int, List<string>> GetBadgesInDictionary()
        {
            return doorAccessDictionary;
        }
        public Badge GetBadgeByID(int id)
        {
            for (int index = 0; index < doorAccessDictionary.Count; index++)
            {
                var item = doorAccessDictionary.ElementAt(index);
                if (item.Key == id)
                {
                    Badge badge = new Badge(item.Key, item.Value);
                    return badge;
                }
            }
            return null;
        }

        // Update
        public void UpdateBadge(Badge newBadge)
        {
            doorAccessDictionary[newBadge.BadgeID] = newBadge.ListOfDoors;
        }

        // Delete
        public void DeleteBadge(Badge newBadge)
        {
            doorAccessDictionary.Remove(newBadge.BadgeID);
        }

        public void DeleteBadgeByID(int id)
        {
            Badge targetBadge = GetBadgeByID(id);
            DeleteBadge(targetBadge);
        }
    }
}
