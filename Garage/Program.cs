using Garage.Abstraction;
using Garage.UI;

namespace Garage;

internal class Program
{
    static void Main(string[] args)
    {

        // Create the handler
        IGarageHandler<Vehicle> garageHandler = new GarageHandler<Vehicle>(5);

        // Create the UI
        IUI ui = new ConsoleUI();

        ICreateVehicle createVehicle = new CreateVehicle();

        // Create your application controller
        Main main = new Main(garageHandler, createVehicle, ui);

        // Start the program
        main.Run();
    }
}
