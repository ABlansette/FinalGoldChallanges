using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Challenge
{
    /*
    The Claim has the following properties:
        ClaimID 
        ClaimType
        Description
        ClaimAmount
        DateOfIncident
        DateOfClaim
        IsValid
*/
    public class Claim
    {

        public Claim() { }

        public Claim(int claimID, ClaimType type, string description, double claimAmount, DateTime dateOfIncident, DateTime dateOfClaim)
        {
            ClaimID = claimID;
            Description = description;
            Type = type;
            ClaimAmount = claimAmount;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOfClaim;
        }

        public int ClaimID { get; set; }
        public ClaimType Type { get; set; }
        public string Description { get; set; }
        public double ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid
        {
            get
            {
                TimeSpan ageOfClaim = DateOfClaim - DateOfIncident;
                int days = ageOfClaim.Days;
                if(days <= 30)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public enum ClaimType { Car, Home, Theft }
    }
}
