using System;
using System.Collections.Generic;
using _03_Challenge;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _03_Challenge_Test_Badges
{
    [TestClass]
    public class BadgeTest
    {

        [TestMethod]
        public void BadgeInitialization()
        {
            List<string> listOne = new List<string>();
            listOne.Add("A1");
            listOne.Add("A6");
            listOne.Add("B1");
            listOne.Add("B6");
            Badge badgeOne = new Badge(12345, listOne);
            List<string> listTwo = new List<string>();
            listTwo.Add("A1");
            listTwo.Add("A2");
            listTwo.Add("B3");
            listTwo.Add("B4");
            Badge badgeTwo = new Badge(73423, listTwo);


            Assert.AreEqual(12345, badgeOne.BadgeID);
            Assert.AreEqual(73423, badgeTwo.BadgeID);
            Assert.AreEqual(listTwo, badgeTwo.ListOfDoors);
        }
        [TestMethod]
        public void GetBadgesInDictionary_ShouldReturnCorrectBadge()
        {
            Dictionary<int, List<string>> doorAc = new Dictionary<int, List<string>>();

            

            var badges = new BadgeRepository();
            List<string> listFour = new List<string>();
            listFour.Add("A1");
            listFour.Add("C1");
            listFour.Add("C6");
            listFour.Add("B6");
            Badge badgeFour = new Badge(23793, listFour);

            badges.AddNewBadgeToDictionary(badgeFour);
            doorAc.Add(23793, listFour);


            Assert.IsNotNull(badges.GetBadgesInDictionary());

        }
        [TestMethod]
        public void UpdateBadge_ShouldGetUpdatedBadge()
        {
            List<string> listOne = new List<string>();
            listOne.Add("A1");
            listOne.Add("A6");
            listOne.Add("B1");
            listOne.Add("B6");
            Badge badgeOne = new Badge(12345, listOne);
            List<string> listTwo = new List<string>();
            listTwo.Add("A1");
            listTwo.Add("A2");
            listTwo.Add("B3");
            listTwo.Add("B4");
            Badge badgeTwo = new Badge(12345, listTwo);


            var badges = new BadgeRepository();

            badges.AddNewBadgeToDictionary(badgeOne);
            badges.UpdateBadge(badgeTwo);

            Assert.AreEqual(listTwo, listTwo);
        }
        [TestMethod]
        public void DeleteBadgeShouldReturn()
        {
            var badges = new BadgeRepository();
            List<string> listOne = new List<string>();
            listOne.Add("A1");
            listOne.Add("A6");
            listOne.Add("B1");
            listOne.Add("B6");
            Badge badgeOne = new Badge(12345, listOne);
            List<string> listTwo = new List<string>();
            listTwo.Add("A1");
            listTwo.Add("A2");
            listTwo.Add("B3");
            listTwo.Add("B4");
            Badge badgeTwo = new Badge(73423, listTwo);

            badges.AddNewBadgeToDictionary(badgeOne);
            badges.AddNewBadgeToDictionary(badgeTwo);

            badges.DeleteBadgeByID(12345);

            Assert.IsNull(badges.GetBadgeByID(12345));

        }
    }
}
