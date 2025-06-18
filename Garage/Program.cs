using Garage.Abstraction;
using Garage.UI;
using Garage.Vehicles;

namespace Garage;

internal class Program
{
    static void Main(string[] args)
    {

        var initialVehicles = new List<Vehicle>
        {
            new Car("abc1", "Red", 1, 122),
            new Motorcycle("abc2", "Blue", 2, 50),
            new Bus("abc3", "Green", 4, 332)

        };

        ICreateVehicle createVehicle = new CreateVehicle();



        IUI ui = new ConsoleUI();

        IGarageHandler<Vehicle> garageHandler = new GarageHandler<Vehicle>(15, initialVehicles, ui);


        Main main = new Main(garageHandler, createVehicle, ui);

        main.Run();
    }
}
