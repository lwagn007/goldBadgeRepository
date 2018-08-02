using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_3
{
    public class ProgramOutingUI
    {
        private OutingsRepo eventList = new OutingsRepo();

        public void Run()
        {
            InitialList();
            RunStartMenu();
        }

        private void RunStartMenu()
        {
            ShowStartMenu();

            bool continueToRunMenu = true;
            {
                while (continueToRunMenu)
                {
                    int choice = GetAndParseMenuChoice();

                    switch (choice)
                    {
                        case 1:
                            SeeAllOutings();
                            break;
                        case 2:
                            EnterNewOuting();
                            break;
                        case 3:
                            AllOutingsTotal();
                            break;
                        case 4:
                            ShowStartMenu();
                            break;
                        case 5:
                            Console.Clear();
                            break;
                        case 6:
                            OutingCost();
                            break;
                        case 7:
                            continueToRunMenu = false;
                            break;
                    }
                }
            }
        }

        private void InitialList()
        {
            Outing initialOuting = new Outing(OutingType.BeerGarden, new DateTime(2018, 04, 15), 15m, 200);
            Outing initialOutingTwo = new Outing(OutingType.Bowling, new DateTime(2018, 02, 15), 45m, 200);
            Outing initialOutingThree = new Outing(OutingType.Golf, new DateTime(2018, 06, 15), 250m, 200);
            Outing initialOutingFour = new Outing(OutingType.AmusementPark, new DateTime(2018, 01, 15), 80m, 200);
            Outing initialOutingFive= new Outing(OutingType.Concert, new DateTime(2018, 07, 15), 500m, 200);

            eventList.AddEventToList(initialOuting);
            eventList.AddEventToList(initialOutingTwo);
            eventList.AddEventToList(initialOutingThree);
            eventList.AddEventToList(initialOutingFour);
            eventList.AddEventToList(initialOutingFive);
        }

        private void ShowStartMenu()
        {
            Console.WriteLine("Please enter what you would like to do.\r\n" +
                "1. See all events. \r\n" +
                "2. Enter a new event \r\n" +
                "3. View total of all outings this year.\r\n" +
                "4. Show Main Menu\r\n" +
                "5. Clear Console.\r\n" +
                "6. Total cost for one outing event type.\r\n" +
                "7. Exit. \r\n");
        }

        private int GetAndParseMenuChoice()
        {
            Console.WriteLine("Please enter the number of your menu choice. 4 to show main menu.");
            int choice = Int32.Parse(Console.ReadLine());
            return choice;
        }

        private void SeeAllOutings()
        {
            Console.Clear();
            Console.WriteLine("Event Type\t" + "Event Date\t" + "Admission Price\t\t" +
                "Total People\t" + "Event Total");

            var outings = eventList.PrintList();

            foreach(var outing in outings)
            {
                Console.WriteLine($"{outing.Event}\t" + $"{outing.EventDate.ToShortDateString()}\t\t" +
                    $"${outing.AdmissionPrice}\t\t" + $"{outing.TotalPeople}\t\t" + $"${outing.TotalOutingCost}");
            }
        }

        private void EnterNewOuting()
        {
            Console.WriteLine("Please follow the prompts to add a new claim to the list. \r\n" +
                "1 = BeerGarden,\r\n" +
                "2 = Bowling,\r\n" + 
                "3 = Golf \r\n" + 
                "4 = AmusementPark\r\n" + 
                "5 = Concert");

            Console.WriteLine("Please enter type of event as number.");
            int newOutingType = Int32.Parse(Console.ReadLine());
            OutingType outingEnum = OutingType.BeerGarden;
                switch (newOutingType)
                {
                    case 1:
                        string outingOne = "BeerGarden";
                        outingEnum = (OutingType)Enum.Parse(typeof(OutingType), outingOne);
                        break;
                    case 2:
                        string outingTwo = "Bowling";
                        outingEnum = (OutingType) Enum.Parse(typeof(OutingType), outingTwo);
                        break;
                    case 3:
                        string outingThree = "Golf";
                        outingEnum = (OutingType)Enum.Parse(typeof(OutingType), outingThree);
                        break;
                    case 4:
                        string outingFour = "AmusementPark";
                        outingEnum = (OutingType)Enum.Parse(typeof(OutingType), outingFour);
                        break;
                    case 5:
                        string outingFive = "Concert";
                        outingEnum = (OutingType)Enum.Parse(typeof(OutingType), outingFive);
                        break;
                }

            Console.WriteLine("Please enter date of event. Please enter MM/DD/YYYY");
            DateTime date = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Please enter admission or ticket price.");
            decimal admission = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Please enter total people in attendance of event.");
            int people = Int32.Parse(Console.ReadLine());

            Outing outing = new Outing(outingEnum, date, admission, people);
            eventList.AddEventToList(outing);
            Console.WriteLine("Event was recorded successfully.");
        }

        private void AllOutingsTotal()
        {
            var outings = eventList.PrintList();
            decimal outingsCost = 0;
                foreach (var outing in outings)
                {
                    outingsCost += outing.TotalOutingCost;
                }
            Console.WriteLine(outingsCost);
        }

        private void OutingCost()
        {
            var outings = eventList.PrintList();
            List<Outing> listEventType = new List<Outing>();
            Console.WriteLine("Which event would you like to see total cost? \r\n" +
               "1 = BeerGarden,\r\n" +
               "2 = Bowling,\r\n" +
               "3 = Golf \r\n" +
               "4 = AmusementPark\r\n" +
               "5 = Concert");

            Console.WriteLine("Please enter type of event as number.");
            int newOutingType = Int32.Parse(Console.ReadLine());
            decimal beer = 0;
            decimal bowling = 0;
            decimal golf = 0;
            decimal amusementPark = 0;
            decimal concert = 0;

            switch (newOutingType)
            {
                case 1:
                    foreach(var outing in outings)
                    {
                        if (outing.Event == OutingType.BeerGarden)
                            beer += outing.TotalOutingCost;
                    }
                    Console.WriteLine($"Beer: {beer}");
                    break;

                case 2:
                    foreach (var outing in outings)
                    {
                        if (outing.Event == OutingType.Bowling)
                            bowling += outing.TotalOutingCost;
                    }
                    Console.WriteLine($"Bowling: {bowling}");
                    break;

                case 3:
                    foreach (var outing in outings)
                    {
                        if (outing.Event == OutingType.Golf)
                            golf += outing.TotalOutingCost;
                    }
                    Console.WriteLine($"Golf: {golf}");
                    break;

                case 4:
                    foreach (var outing in outings)
                    {
                        if (outing.Event == OutingType.AmusementPark)
                            amusementPark += outing.TotalOutingCost;
                    }
                    Console.WriteLine($"Amusement Park: {amusementPark}");
                    break;

                case 5:
                    foreach (var outing in outings)
                    {
                        if (outing.Event == OutingType.Concert)
                            concert += outing.TotalOutingCost;
                    }
                    Console.WriteLine($"Concert: {concert}");
                    break;
            }
        }
    }
}
