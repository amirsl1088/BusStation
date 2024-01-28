using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusStation
{
    public class Trip
    {
        public Trip(int price,
            string origin ,string destination,Bus bus)
        {
           
            Price = price;
            Origin = origin;
            Destination = destination;
            Bus = bus;
           
        }
        public int Id { get; set; }
        public BusType Type { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public int Price { get; set; }
        public Bus Bus { get; set; }
     
       

    }
    public enum BusType
    {
        vip=1,normal=2
    }
}
