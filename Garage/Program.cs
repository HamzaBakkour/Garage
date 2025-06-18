using Garage.Abstraction;
using Garage.UI;

namespace Garage;

internal class Program
{
    static void Main(string[] args)
    {

        IGarageHandler<Vehicle> garageHandler = new GarageHandler<Vehicle>(5);

        IUI ui = new ConsoleUI();

        ICreateVehicle createVehicle = new CreateVehicle();

        Main main = new Main(garageHandler, createVehicle, ui);

        main.Run();
    }
}
