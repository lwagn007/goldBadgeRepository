using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_2
{
    public class Claim
    {
        public Claim(){ }
        
        public Claim(int id, string type, string description, decimal amount, DateTime accidentDate, DateTime claimDate)
        {
            ClaimID = id;
            Type = type;
            ClaimDescription = description;
            ClaimAmount = amount;
            ClaimAccidentDate = accidentDate;
            ClaimDate = claimDate;
            IsValid = ClaimDate - ClaimAccidentDate < TimeSpan.FromDays(30);
        }

        public int ClaimID { get; set; }
        public string Type { get; set; }
        public string ClaimDescription { get; set; }
        public decimal ClaimAmount { get; set; }
        public DateTime ClaimAccidentDate { get; set; }
        public DateTime ClaimDate { get; set; }
        public bool IsValid { get; set; }
    }
}
