using BusStation;

while (true)
{
    try
    {
        Run();
    }catch(Exception exception)
    {
        Console.WriteLine(exception.Message);
    }
}
void Run()
{
    Console.WriteLine("choose option=\n1-add vipbus\n2-add normalbus\n3-add trip\n4add pasenger" +
        "\n5-show trips with details\n6-reserve ticket\n7-buy ticket\n8-cancel ticket\n9report trip" +
        "\n10-exit");
    var input = int.Parse(Console.ReadLine()!);
    switch (input)
    {
        case 1:
            {
                var busNmae = GetString("enter bus name");
                BusManagment.AddVIPBus(busNmae);
                break;
            }
        case 2:
            {
                var busName = GetString("enter bus name");
                BusManagment.AddNormalBus(busName);
                break;
            }
        case 3:
            {
                var busName = GetString("enter bus name");
                var type = GetInt("1-vip \n2-normal");
              
                var origin = GetString("enter origin");
                var destination = GetString("enter destnation");
                var price = GetInt("enter ticket price");
                BusManagment.AddTrip(type, price, origin, destination, busName);
                break;
            }
        case 4:
            {
                break;
            }

        case 5:
            {
                foreach(var trip in BusManagment.GetTrips())
                {
                    Console.WriteLine($"busname={trip.Bus.Name},bustype={trip.Type}," +
                        $"origin={trip.Origin},destination={trip.Destination}," +
                        $"price={trip.Price}");
                }
                break;
            }
        case 6:
            {
                foreach (var trip in BusManagment.GetTrips())
                {
                    Console.WriteLine($"busname={trip.Bus.Name},bustype={trip.Type}," +
                        $"origin={trip.Origin},destination={trip.Destination}," +
                        $"price={trip.Price}");
                }
                Console.WriteLine("****************************");
                var busName = GetString("above the list enter your busname for reserv");
                var bus = BusManagment.GetBuses().FirstOrDefault(_ => _.Name == busName);
                if(bus is null)
                {
                    throw new Exception("bus not found");
                }
                foreach(var chair in bus.Chairs)
                {
                    Console.WriteLine(chair.Number);
                }
                var chairNumber = GetString("enter number of chair");
                BusManagment.ReserveTicket(bus.Name, chairNumber);

                break;
            }
        case 7:
            {
                foreach (var trip in BusManagment.GetTrips())
                {
                    Console.WriteLine($"busname={trip.Bus.Name},bustype={trip.Type}," +
                        $"origin={trip.Origin},destination={trip.Destination}," +
                        $"price={trip.Price}");
                }
                Console.WriteLine("****************************");
                var busName = GetString("above the list enter your busname for buy ticket");
                var bus = BusManagment.GetBuses().FirstOrDefault(_ => _.Name == busName);
                if (bus is null)
                {
                    throw new Exception("bus not found");
                }
                foreach (var chair in bus.Chairs)
                {
                    Console.WriteLine(chair.Number);
                }
                var chairNumber = GetString("enter number of chair");
                BusManagment.BuyTicket(bus.Name, chairNumber);
                break;
            }
        case 8:
            {
                foreach (var trip in BusManagment.GetTrips())
                {
                    Console.WriteLine($"busname={trip.Bus.Name},bustype={trip.Type}," +
                        $"origin={trip.Origin},destination={trip.Destination}," +
                        $"price={trip.Price}");

                }
                Console.WriteLine("***************************");
                var busName = GetString("enter bus name");
                foreach(var ticket in BusManagment.GetTickets())
                {
                    Console.WriteLine($"ticket id={ticket.Id}");
                }
                var ticketId = GetString("enter id witch you want to cancel");
                break;
            }
    }

}
 string GetString(string message)
{
    Console.WriteLine(message);
    var result = Console.ReadLine()!;
    return result;
}
 int GetInt(string message)
{
    Console.WriteLine(message);
    var result = int.Parse(Console.ReadLine()!);
    return result;
}