using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Challenge_3.Outing;

namespace Challenge_3
{
    public class OutingsRepo
    {
        private List<Outing> eventList = new List<Outing>();

        public void AddEventToList(Outing outing)
        {
            eventList.Add(outing);
        }

        public List<Outing> PrintList()
        {
            return eventList;
        }
    }
}
