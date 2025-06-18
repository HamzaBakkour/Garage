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

    private void ValidateRegNo(string regNO, List<Vehicle> registeredVehicles) {

        if (registeredVehicles.Any(v => v.RegistrationNO == regNO.ToUpper()))
            throw new ArgumentException("A vehicle with the same regstration number" +
                                            " already exist");
        if (string.IsNullOrWhiteSpace(regNO))
            throw new ArgumentException("Regstration number can not be embty");
        if (regNO.Length > 6)
            throw new ArgumentException("Regstration number can not be longer than 6");

    }


    public  Vehicle Create(IUI _ui, List<Vehicle> registeredVehicles)
    {

        _ui.Print("Vehicl Type (1=Airplane, 2=Motorcycle, 3=Car , 4=Bus , 5=Boat):");
        string inputStr = _ui.GetInput();

        if (!int.TryParse(inputStr, out int input) ||
            input < 1 || input > Enum.GetValues(typeof(VehicleType)).Length)
        {
            throw new ArgumentException("Invalid vehicle type selection. Please enter a number between 1 and 5.");
        }

        VehicleType vehicleType = (VehicleType)(input - 1);

        _ui.Print("RegistrationNO:");
        var regNo = _ui.GetInput();
        ValidateRegNo(regNo, registeredVehicles);


        _ui.Print("Color:");
        var color = _ui.GetInput();


        _ui.Print("Number of Seats:");
        uint seats = _ui.GetInputUint();

        _ui.Print("Length:");
        uint length = _ui.GetInputUint();

        return vehicleType switch
        {
            VehicleType.Airplane => new Airplane(regNo, color, seats, length),
            VehicleType.Car => new Car(regNo, color, seats, length),
            VehicleType.Bus => new Bus(regNo, color, seats, length),
            VehicleType.Boat => new Boat(regNo, color, seats, length),
            VehicleType.Motorcycle => new Motorcycle(regNo, color, seats, length),
            _ => throw new ArgumentException("Unsupported vehicle type.")
        };
    }
}
