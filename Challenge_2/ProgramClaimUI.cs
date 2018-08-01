using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Challenge_2.Claim;

namespace Challenge_2
{
    class ProgramClaimUI
    {
        public ClaimQueueRepository _claimRepo = new ClaimQueueRepository();

        public void Run()
        {
            InitialQueue();
            RunStartMenu();
        }

        private void RunStartMenu()
        {
            ShowStartMenu();

            bool continueToRunMenu = true;
            {
                while(continueToRunMenu)
                {
                    int choice = GetAndParseMenuChoice();
                    
                    switch (choice)
                    {
                        case 1:
                            SeeAllClaims();
                            break;
                        case 2:
                            EnterNewClaim();
                            break;
                        case 3:
                            NextClaim();
                            break;
                        case 4:
                            ShowStartMenu();
                            break;
                        case 5:
                            Console.Clear();
                            break;
                        case 6:
                            continueToRunMenu = false;
                            break;

                    }
                }
            }
        }

        private void InitialQueue()
        {
            Claim claim = new Claim(3298, "house", "fire", 38989m, new DateTime(2018, 07, 29), new DateTime(2018, 07, 30));
            Claim claimOne = new Claim(398, "car", "theft", 489m, new DateTime(2018, 06, 29), new DateTime(2018, 07, 30));
            _claimRepo.AddClaimToQueue(claim);
            _claimRepo.AddClaimToQueue(claimOne);
        }

        private void ShowStartMenu()
        {
            Console.WriteLine("Please enter what you would like to do. \r\n" +
                "1. Show all claims. \r\n" +
                "2. Enter a new claim. \r\n" +
                "3. Show next claim. \r\n" +
                "4. Show main menu. \r\n" +
                "5. Clear Console. \r\n" +
                "6. Exit.");
        }

        private int GetAndParseMenuChoice()
        {
            Console.WriteLine("Please enter your choice as a number. 4 to show main menu.");
            int choice = Int32.Parse(Console.ReadLine());
            return choice;
        }

        private void SeeAllClaims()
        {
            Console.Clear();
            Console.WriteLine("Claim ID\t" + "Type\t" + "Description\t" +
                "Amount\t" + "DateOfAccident\t" +
                "DateOfClaim\t" + "Is Valid\t");

            var claims = _claimRepo.GetClaims();

            foreach(var claim in claims)
            {
                Console.WriteLine($"{claim.ClaimID}\t\t" + $"{claim.Type}\t" + $"{claim.ClaimDescription}\t\t" +
                $"{claim.ClaimAmount}\t" + $"{claim.ClaimAccidentDate.ToShortDateString()}\t" +
                $"{claim.ClaimDate.ToShortDateString()} \t" + $"{claim.IsValid} \t\t");
            }

        }

        private void EnterNewClaim()
        {
            Console.WriteLine("Please follow the prompts to add a new claim to queue.");

            Console.WriteLine("Please enter claim id.");
            int claimID = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Please enter what you are listing a claim on. ");
            string type = Console.ReadLine();

            Console.WriteLine("Please enter description of claim.");
            string claimDescription = Console.ReadLine();

            Console.WriteLine("What is the amount of the claim.");
            decimal amount = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Enter date of Accident: MM/DD/YYYY");
            DateTime accident = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Enter date claim was filed MM/DD/YYYY");
            DateTime claimDate = DateTime.Parse(Console.ReadLine());

            Claim claim = new Claim(claimID, type, claimDescription, amount, accident, claimDate);

            _claimRepo.AddClaimToQueue(claim);
            Console.WriteLine("Item was added to the queue successfully.");
        }

        private void NextClaim()
        {
            Queue<Claim> claimQ = _claimRepo.GetClaims();
            Claim displayClaim = claimQ.Peek();
                Console.WriteLine($"{displayClaim.ClaimID}\n {displayClaim.Type}\n {displayClaim.ClaimDescription}\n {displayClaim.ClaimAmount}\n {displayClaim.ClaimAccidentDate}\n {displayClaim.ClaimDate} \n {displayClaim.IsValid}");

            Console.WriteLine("Would you like to handle this claim? y/n");
            string y = Console.ReadLine();
            if (y == "y")
            {
                claimQ.Dequeue();
                Console.WriteLine("Claim handled.");
            }
        }

    }
}
