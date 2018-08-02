using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Challenge_3;

namespace Challenge_3_Tests
{
    [TestClass]
    public class OutingTests
    {
        private OutingsRepo eventList;

        [TestInitialize]
        public void Arrange()
        {
            eventList = new OutingsRepo();
        }

        [TestMethod]
        public void EventList_AddEventToList_ShouldIncreaseByOne()
        {
            //-- Arrange
            Outing initialOuting = new Outing(OutingType.BeerGarden, new DateTime(2018, 04, 15), 15m, 200);
            eventList.AddEventToList(initialOuting);

            //-- Act
            var actual = eventList.PrintList().Count;
            var expected = 1;

            //-- Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EventList_PrintList_ShouldIncreaseByOne()
        {
            //-- Arrange
            Outing initialOuting = new Outing(OutingType.BeerGarden, new DateTime(2018, 04, 15), 15m, 200);
            eventList.AddEventToList(initialOuting);

            //-- Act
            var actual = eventList.PrintList().Count;
            int expected = 1;

            //-- Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EventList_SingleOutingPulledAndTotalsAdded_DecimalShouldBeEqual()
        {
            //-- Arrange
            Outing initialOuting = new Outing(OutingType.BeerGarden, new DateTime(2018, 04, 15), 15m, 200);
            Outing initialOutingTwo = new Outing(OutingType.BowlingEvent, new DateTime(2018, 02, 15), 45m, 200);
            Outing initialOutingThree = new Outing(OutingType.GolfEvent, new DateTime(2018, 06, 15), 250m, 200);
            Outing initialOutingFour = new Outing(OutingType.BeerGarden, new DateTime(2018, 01, 15), 80m, 200);
            Outing initialOutingFive = new Outing(OutingType.ConcertEvent, new DateTime(2018, 07, 15), 500m, 200);
            eventList.AddEventToList(initialOuting);
            eventList.AddEventToList(initialOutingTwo);
            eventList.AddEventToList(initialOutingThree);
            eventList.AddEventToList(initialOutingFour);
            eventList.AddEventToList(initialOutingFive);
            decimal beer = 0;

            var outings = eventList.PrintList();

            foreach (var outing in outings)
            {
                if (outing.Event == OutingType.BeerGarden)
                    beer += outing.TotalOutingCost;
            }

            //-- Act
            var actual = beer;
            decimal expected = 19000m;

            //-- Assert
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void EventList_CalculateAllCosts_DecimalShouldBeEqual()
        {
            //-- Arrange
            Outing initialOuting = new Outing(OutingType.BeerGarden, new DateTime(2018, 04, 15), 15m, 200);
            Outing initialOutingTwo = new Outing(OutingType.BowlingEvent, new DateTime(2018, 02, 15), 45m, 200);
            Outing initialOutingThree = new Outing(OutingType.GolfEvent, new DateTime(2018, 06, 15), 250m, 200);
            Outing initialOutingFour = new Outing(OutingType.BeerGarden, new DateTime(2018, 01, 15), 80m, 200);
            Outing initialOutingFive = new Outing(OutingType.ConcertEvent, new DateTime(2018, 07, 15), 500m, 200);
            eventList.AddEventToList(initialOuting);
            eventList.AddEventToList(initialOutingTwo);
            eventList.AddEventToList(initialOutingThree);
            eventList.AddEventToList(initialOutingFour);
            eventList.AddEventToList(initialOutingFive);

            var outings = eventList.PrintList();
                decimal outingsCost = 0;
                foreach (var outing in outings)
                {
                    outingsCost += outing.TotalOutingCost;
                }

            //-- Act
            var actual = outingsCost;
            var expected = 178000m;

            //-- Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
