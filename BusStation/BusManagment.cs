using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusStation
{
    public static class BusManagment
    {
        private static List<Bus> _buses = new();

        private static List<Trip> _trips = new();
        private static List<Chair> _reservechair = new();
        private static List<Ticket> _tickets = new();
        private static List<Chair> _soldchair = new();

        public static void AddVIPBus(string name)
        {
            var bus = new VIPBus(name);
            bus.Capacity = 30;
            for (var i = 1; i <= bus.Capacity; i++)
            {
                var chair = new Chair(i.ToString());
                bus.Chairs.Add(chair);
            }

            _buses.Add(bus);
        }
        public static List<Bus> GetBuses()
        {
            return _buses;
        }
        public static void AddNormalBus(string name)
        {
            var bus = new NormalBus(name);
            bus.Capacity = 44;
            for (var i = 1; i <= bus.Capacity; i++)
            {
                var chair = new Chair(i.ToString());
                bus.Chairs.Add(chair);
            }
            _buses.Add(bus);
        }

        public static void AddTrip(int type, int price, string origin,
            string destination, string busname)
        {
            if (type == 1)
            {
                var bus = new VIPBus(busname);
                bus.Capacity = 30;
                var trip = new Trip(price, origin, destination, bus);
                trip.Type = BusType.vip;

                var result = _buses.FirstOrDefault(_ => _.Name == busname);
                if (result is null)
                {
                    throw new Exception("bus not found");
                }

                _trips.Add(trip);
            }
            if (type == 2)
            {
                var bus = new NormalBus(busname);
                bus.Capacity = 44;
                var trip = new Trip(price, origin, destination, bus);
                trip.Type = BusType.normal;

                var result = _buses.FirstOrDefault(_ => _.Name == busname);
                if (result is null)
                {
                    throw new Exception("bus not found");
                }

                _trips.Add(trip);
            }
        }
        public static List<Trip> GetTrips()
        {
            return _trips;
        }
        public static void ReserveTicket(string busname, string chairnumber)
        {
            var bus = _buses.FirstOrDefault(_ => _.Name == busname);
            if (bus is null)
            {
                throw new Exception("bus not found");
            }

            var result = _reservechair.Any(_ => _.Number == chairnumber);
            if (result == true)
            {
                throw new Exception("this chair was reserved");
            }
            var ticket = new Ticket
            {
                Type = TicketType.reserve,
                Id = chairnumber
            };

            var chair = bus.Chairs.FirstOrDefault(_ => _.Number == chairnumber);
            chair!.Number = "rr";
            _reservechair.Add(chair);
            _tickets.Add(ticket);

        }
        public static void BuyTicket(string busname, string chairnumber)
        {
            var bus = _buses.FirstOrDefault(_ => _.Name == busname);
            if (bus is null)
            {
                throw new Exception("bus not found");
            }

            var result = _reservechair.Any(_ => _.Number == chairnumber);
            if (result == true)
            {
                throw new Exception("this chair was sold");
            }
            var ticket = new Ticket
            {
                Type = TicketType.buy,
                Id = chairnumber
            };
            _tickets.Add(ticket);

            var chair = bus.Chairs.FirstOrDefault(_ => _.Number == chairnumber);
            chair!.Number = "bb";
            _soldchair.Add(chair);
        }
        public static void CancelSoldTicket(string busname, string ticketid)
        {
            var bus = _buses.FirstOrDefault(_ => _.Name == busname);
            if (bus is null)
            {
                throw new Exception("bus not found");
            }
            var ticket = _tickets.FirstOrDefault(_ => _.Id == ticketid);
            var chair = bus.Chairs.FirstOrDefault(_ => _.Number == "bb");
            chair!.Number = ticketid;


        }
        public static void CancelReserveTicket(string busname, string ticketid)
        {
            var bus = _buses.FirstOrDefault(_ => _.Name == busname);
            if (bus is null)
            {
                throw new Exception("bus not found");
            }
            var ticket = _tickets.FirstOrDefault(_ => _.Id == ticketid);
            var chair = ticket.Chairs.FirstOrDefault(_ => _.Number == "rr");
            chair!.Number = ticketid;
        }

        public static List<Ticket> GetTickets()
        {
            return _tickets;
        }


    }
}

