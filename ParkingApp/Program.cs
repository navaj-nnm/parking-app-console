using ParkingApp.Business;
using ParkingApp.Business.Repositories;
using ParkingApp.Models;
using ParkingApp.Models.Contracts;
using ParkingApp.Models.Exceptions;

IParkingRepository parkingRepository = new ParkingRepository();
while (true)
{
    try
    {
        Console.WriteLine(parkingRepository.GetAvailableSlots());
        Console.WriteLine("What do you want to do? 1 for Parking, 2 for Unparking.");
        var selection = Convert.ToInt16(Console.ReadLine());
        if (selection == 1)
        {
            Console.WriteLine("Enter type of car: 1. Hatchback, 2. Sedan/ CompactSUV, 3. LargeSUV");
            int type = Convert.ToInt16(Console.ReadLine());
            Car car = new Car
            {
                Type = type switch
                {
                    1 => CarType.HatchBack,
                    2 => CarType.SedanOrCompactSUV,
                    3 => CarType.LargeSUV
                },
                RegNumber = new Random().Next(1000, 9999).ToString()
            };
            Console.WriteLine(parkingRepository.Park(car));
        }
        else if (selection == 2)
        {
            Console.WriteLine("Enter parking id:");
            var parkingId = Convert.ToInt16(Console.ReadLine());
            parkingRepository.UnPark(parkingId);
            Console.WriteLine("Car removed from parking");
        }
    }
    catch(ParkingInUseException ex)
    {
        Console.WriteLine(ex.Message);
    }
    catch (ParkingFullException ex)
    {
        Console.WriteLine(ex.Message);
    }
    catch(Exception ex)
    {
        Console.WriteLine("An unhandled exception occured");
    }
}
