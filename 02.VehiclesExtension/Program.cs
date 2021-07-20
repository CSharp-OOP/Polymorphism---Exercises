using System;
using System.Linq;

namespace _02.VehiclesExtension
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string[] carTokens = ParseArray();
            string[] truckTokens = ParseArray();
            string[] busTokens = ParseArray();

            Vehicle car = new Car(double.Parse(carTokens[1]), double.Parse(carTokens[2]), double.Parse(carTokens[3]));
            Vehicle truck = new Truck(double.Parse(truckTokens[1]), double.Parse(truckTokens[2]), double.Parse(truckTokens[3]));
            Bus bus = new Bus(double.Parse(busTokens[1]), double.Parse(busTokens[2]), double.Parse(busTokens[3]));

            int numberOfCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCommands; i++)
            {
                string[] line = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                string command = line[0];
                string type = line[1];
                double amount = double.Parse(line[2]);


                if (command is "Drive")
                {
                    if (type is "Car")
                    {
                        CanDrive(car, amount);

                    }
                    else if (type is "Truck")
                    {
                        CanDrive(truck, amount);
                    }
                    else //Bus
                    {
                        bus.IsEmpty = false;
                        CanDrive(bus, amount);
                    }
                }
                else if (command is "Refuel")
                {
                    try
                    {
                        if (type is "Car")
                        {
                            car.Refuel(amount);
                        }
                        else if (type is "Truck")
                        {
                            truck.Refuel(amount);
                        }
                        else
                        {
                            bus.Refuel(amount);
                        }
                    }
                    catch (InvalidOperationException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else //drive empty
                {
                    bus.IsEmpty = true;
                    CanDrive(bus, amount);
                }
            }

            Console.WriteLine($"Car: {car.FuelQuantity:F2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:F2}");
            Console.WriteLine($"Bus: {bus.FuelQuantity:F2}");
        }

        public static void CanDrive(Vehicle vehicle, double distance)
        {
            bool canDrive = vehicle.CanDrive(distance);

            string result = canDrive
                ? $"{vehicle.GetType().Name} travelled {distance} km"
                : $"{vehicle.GetType().Name} needs refueling";

            Console.WriteLine(result);
        }
        private static string[] ParseArray() => Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
    }
}
