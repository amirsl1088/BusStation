using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusStation
{
    public class Ticket
    {
        public string Id { get; set; }
        public Trip Trip { get; set; }
        public List<Chair> Chairs { get; set; }
        public TicketType Type { get; set; }
    }
    public enum TicketType
    {
        reserve=1,
        buy=2
    }
}
