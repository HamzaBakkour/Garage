using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Garage.Abstraction;
using Garage.Vehicles;
using Microsoft.Extensions.DependencyInjection;


namespace Garage;

internal class Main
{

    private IGarageHandler<Vehicle> _garageHandler;
    private ICreateVehicle _createVehicle;
    private IUI _ui;

    private List<string> ListAllAsStrings() =>
                                    _garageHandler.ListAll()
                                   .Select(v => v.ToString())
                                   .ToList();

    public Main(IGarageHandler<Vehicle> garageHandler, ICreateVehicle createVehicle, IUI ui)
    {
        this._garageHandler = garageHandler;
        this._createVehicle = createVehicle;
        this._ui = ui;
    }

    public void Run() {

        do {
            ShowMenu();
            string input = _ui.GetInput();

            switch (input) {
                case "1":
                    ParkVehicle();
                    break;
                case "2":
                    LeaveVehicle();
                    break;
                case "3":
                    ListAll();
                    break;
                case "4":
                    ListAllDetailed();
                    break;
                case "5":
                    FindByRegistrationNO();
                    break;
                case "6":
                    FindAllByColor();
                    break;
                case "7":
                    FindAllByFuelType();
                    break;
                case "8":
                    FindAllByColorAndNumberOfSeats();
                    break;
                case "9":
                    Environment.Exit(0);
                    break;
            }

        }while (true);
    }



    public void ShowMenu()
    {
        _ui.Print();
        _ui.Print("1. Park Vehicle");
        _ui.Print("2. Vehicle Leave");
        _ui.Print("3. List All Parked Vehicles");
        _ui.Print("4. List All Parked Vehicles (Count)");
        _ui.Print("5. Find Vehicle Using RegstrationNO");
        _ui.Print("6. Find All Vehicles by Color");
        _ui.Print("7. Find All Vehicles by Fuel Type");
        _ui.Print("8. Find All Vehicles by Color And Number Of Seats");
        _ui.Print("9. Exit");
    }





    public void ParkVehicle()
    {
        try
        {

            if (_garageHandler.IsFull())
            {
                _ui.Print("The garage is full.");
                return;
            }

            Vehicle vehicle = _createVehicle.Create(_ui, _garageHandler.ListAll());
            bool success = _garageHandler.Park(vehicle);

            if (success)
                _ui.Print("Vehicle parked successfully.");
            else
                _ui.Print("Could not park the vehicle. Garage is either full" +
                            " or it already has this vehicle parked");
        }
        catch (ArgumentException ex)
        {
            _ui.Print($"Error: {ex.Message}");
        }
    }

    public void LeaveVehicle()
    {
        _ui.Print("RegistrationNO:");
        string regNo = _ui.GetInput();
        bool success = _garageHandler.Leave(regNo.ToUpper());

        if (success)
            _ui.Print("Vehicle leaved");
        else
            _ui.Print("No vehicle with regstration number" +
                        $" {regNo} exist");
    }

    public void ListAll()
    {
        var vehicles = _garageHandler.ListAll();

        if (vehicles.Count == 0)
        {
            _ui.Print("The garage is empty.");
            return;
        }

        foreach (var vehicle in vehicles)
            _ui.Print(vehicle.ToString());
    }

    public void ListAllDetailed()
    {
        var vehicleCounts = _garageHandler.ListAllDetailed();

        if (vehicleCounts.Count == 0)
        {
            _ui.Print("The garage is empty.");
            return;
        }

        foreach (var entry in vehicleCounts)
        {
            _ui.Print($"{entry.Key}: {entry.Value}");
        }
    }


    public void FindByRegistrationNO()
    {
        _ui.Print("RegistrationNO:");
        string regNo = _ui.GetInput();
        var vehicle = _garageHandler.FindByRegistrationNO(regNo);
        if (vehicle != null)
            _ui.Print(vehicle.ToString());
        else _ui.Print($"Vehicle with regNo {regNo} does not exist");
    }

    public void FindAllByColor()
    {
        _ui.Print("Color:");
        string color = _ui.GetInput();
        var vehicles = _garageHandler.FindAllByColor(color.ToUpper());
        
        if (vehicles.Count == 0)
        {
            _ui.Print($"No vehicles with color {color} found");
            return;
        }

        foreach (var vehicle in vehicles)
        {
            _ui.Print(vehicle.ToString());
        }
    }

    public void FindAllByFuelType()
    {
        _ui.Print("Fuel Type (1=Gasoline, 2=Diesel):");
        string inputStr = _ui.GetInput();

        if (!int.TryParse(inputStr, out int input) ||
            input < 1 || input > Enum.GetValues(typeof(FuelType)).Length)
        {
            _ui.Print("Invalid fuel type. Please enter 1 or 2.");
            return;
        }

        FuelType fuel = (FuelType)(input - 1);

        var vehicles = _garageHandler.FindAllByFuelType(fuel);

        if (vehicles.Count == 0)
        {
            _ui.Print($"No vehicles with fuel type {fuel} found.");
            return;
        }

        foreach (var vehicle in vehicles)
        {
            _ui.Print(vehicle.ToString());
        }
    }

    private void FindAllByColorAndNumberOfSeats()
    {
        _ui.Print("Color:");
        string color = _ui.GetInput();

        _ui.Print("Number of Seats:");
        string seatInput = _ui.GetInput();

        if (!uint.TryParse(seatInput, out uint seats))
        {
            _ui.Print("Invalid number of seats. Please enter a non-negative integer.");
            return;
        }

        var vehicles = _garageHandler.FindAllByColorAndNumberOfSeats(color, seats);

        if (vehicles.Count == 0)
        {
            _ui.Print($"No vehicles with color {color} and number of seats {seats} found.");
            return;
        }

        foreach (var vehicle in vehicles)
        {
            _ui.Print(vehicle.ToString());
        }

    }

}
