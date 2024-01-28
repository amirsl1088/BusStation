using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusStation
{
   public abstract class Bus
    {
        public Bus(string name)
        {
            Name = name;
            Chairs = new();
        }
        public string Name { get; set; }
        public int Id { get; set; }
        public int Capacity { get; set; }
        public List<Chair> Chairs { get; set; }
      
    }
}
