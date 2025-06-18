using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Garage.Abstraction;
using Garage.Vehicles;

namespace Garage;

internal  class CreateVehicle : ICreateVehicle
{


    public  Vehicle Create(IUI _ui)
    {

        _ui.Print("Vehicl Type (1=Airplane, 2=Motorcycle, 3=Car , 4=Bus , 5=Boat):");
        int input = int.Parse(_ui.GetInput());

        if (input < 1 || input > Enum.GetValues(typeof(VehicleType)).Length)
            throw new ArgumentException("Invalid vehicle type selection.");

        VehicleType vehicleType = (VehicleType)(input - 1);

        _ui.Print("RegistrationNO:");
        var regNo = _ui.GetInput();

        _ui.Print("Color:");
        var color = _ui.GetInput();

        _ui.Print("Number of Engines:");
        uint engines = _ui.GetInputUint();

        _ui.Print("Cylinder Volume:");
        uint volume = _ui.GetInputUint();

        _ui.Print("Fuel Type (1=Gasoline, 2=Diesel):");
        input = int.Parse(_ui.GetInput());

        if (input < 1 || input > Enum.GetValues(typeof(FuelType)).Length)
            throw new ArgumentException("Invalid fuel type selected.");

        FuelType fuel = (FuelType)(input - 1);

        _ui.Print("Number of Seats:");
        uint seats = _ui.GetInputUint();

        _ui.Print("Length:");
        uint length = _ui.GetInputUint();

        return vehicleType switch
        {
            VehicleType.Airplane => new Airplane(regNo, color, engines, volume, fuel, seats, length),
            VehicleType.Car => new Car(regNo, color, engines, volume, fuel, seats, length),
            VehicleType.Bus => new Bus(regNo, color, engines, volume, fuel, seats, length),
            VehicleType.Boat => new Boat(regNo, color, engines, volume, fuel, seats, length),
            VehicleType.Motorcycle => new Motorcycle(regNo, color, engines, volume, fuel, seats, length),
            _ => throw new ArgumentException("Unsupported vehicle type.")
        };
    }


}
