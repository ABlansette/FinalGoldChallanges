using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Challenge
{
    public class ClaimRepository
    {
        private List<Claim> _claimDirectory = new List<Claim>();
        // CRUD

        // Create
        public void AddClaim(Claim item)
        {
            _claimDirectory.Add(item);
        }

        // Read
        public List<Claim> GetclaimsInDirectory()
        {
            return _claimDirectory;
        }

        public Claim GetItemByID(int id)
        {
            foreach (Claim item in _claimDirectory)
            {
                if (item.ClaimID == id)
                {
                    return item;
                }
            }
            return null;
        }

        public void FixIndexOfItem()
        {
            foreach (Claim item in _claimDirectory)
            {
                item.ClaimID = _claimDirectory.IndexOf(item) + 1;
            }
        }

        // Update
        public void UpdateItem(int id, Claim newClaim)
        {
            foreach (Claim item in _claimDirectory)
            {
                if (item.ClaimID == id)
                {
                    item.Type = newClaim.Type;
                    item.ClaimID = newClaim.ClaimID;
                    item.Description = newClaim.Description;
                    item.ClaimAmount = newClaim.ClaimAmount;
                    item.DateOfClaim = newClaim.DateOfClaim;
                    item.DateOfIncident = newClaim.DateOfIncident;
                }
            }
        }

        // Delete
        public void DeleteClaim(Claim newClaim)
        {
            _claimDirectory.Remove(newClaim);
        }
        public void DeleteClaimByID(int id)
        {
            Claim targetClaim = GetItemByID(id);
            DeleteClaim(targetClaim);
        }
    }
}
