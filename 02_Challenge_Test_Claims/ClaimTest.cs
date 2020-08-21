using System;
using _02_Challenge;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _02_Challenge_Test_Claims
{
    [TestClass]
    public class ClaimTest
    {
        [TestMethod]
        public void ClaimInitalization()
        { DateTime dateInc = new DateTime(2019, 01, 01);
          DateTime dateClaim = new DateTime(2019, 01, 01);
          Claim claim = new Claim(4, Claim.ClaimType.Car, "crash on 161st", 200, dateInc, dateClaim);

            Assert.AreEqual(4, claim.ClaimID);
            Assert.AreEqual(200, claim.ClaimAmount);
            Assert.AreEqual(dateInc, claim.DateOfIncident);
        }
        [TestMethod]
        public void GetClaimByID_ShouldGetCorrectClaim()
        {
            //Arrange
            var insurance = new ClaimRepository();
            DateTime dateInc = new DateTime(2019, 01, 01);
            DateTime dateClaim = new DateTime(2019, 01, 01);
            Claim claim = new Claim(1, Claim.ClaimType.Car, "crash on 161st", 200, dateInc, dateClaim);
            Claim claimTwo = new Claim(2, Claim.ClaimType.Home, "crash on 161st", 200, dateInc, dateClaim);
            Claim claimThree = new Claim(3, Claim.ClaimType.Theft, "crash on 161st", 230, dateInc, dateClaim);

            insurance.AddClaim(claim);
            insurance.AddClaim(claimTwo);
            insurance.AddClaim(claimThree);

            //Act
            var specififcClaim = insurance.GetItemByID(2);

            //Assert
            Assert.AreEqual(claimTwo, specififcClaim);
        }

        [TestMethod]
        public void UpdateItem_ShouldGetCorrectClaim()
        {
            var insurance = new ClaimRepository();
            DateTime dateInc = new DateTime(2019, 01, 01);
            DateTime dateClaim = new DateTime(2019, 01, 01);
            Claim claim = new Claim(1, Claim.ClaimType.Car, "crash on 161st", 200, dateInc, dateClaim);
            Claim claimTwo = new Claim(2, Claim.ClaimType.Home, "crash on 161st", 200, dateInc, dateClaim);
            insurance.AddClaim(claim);

            insurance.UpdateItem(1, claimTwo);

            Assert.AreEqual(2, claimTwo.ClaimID);
        }

        public void DeleteItem_ShouldGetCorrectClaim()
        {
            var insurance = new ClaimRepository();
            DateTime dateInc = new DateTime(2019, 01, 01);
            DateTime dateClaim = new DateTime(2019, 01, 01);
            Claim claim = new Claim(1, Claim.ClaimType.Car, "crash on 161st", 200, dateInc, dateClaim);
            Claim claimTwo = new Claim(2, Claim.ClaimType.Home, "crash on 161st", 200, dateInc, dateClaim);
            insurance.AddClaim(claim);

            insurance.UpdateItem(1, claimTwo);

            Assert.AreEqual(2, claimTwo.ClaimID);
        }
    }
}
