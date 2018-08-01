using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_3
{
    public enum OutingType : int
        {BeerGarden = 1, Bowling = 2, Golf = 3, AmusementPark = 4, Concert = 5};
    public class Outing
    {
        

        public Outing() { }

        public Outing(OutingType outing, DateTime eventDate, decimal admissionPrice, int totalPeople)
        {
            Event = outing;
            EventDate = eventDate;
            AdmissionPrice = admissionPrice;
            TotalPeople = totalPeople;
            TotalOutingCost = AdmissionPrice * TotalPeople;
        }

        public OutingType Event { get; set; }
        public DateTime EventDate { get; set; }
        public decimal AdmissionPrice { get; set; }
        public int TotalPeople { get; set; }
        public decimal TotalOutingCost { get; set; }
        public decimal EventsTotal { get; set; }
    }
}
