using Garage.Abstraction;

namespace Garage.Vehicles;

public class Airplane: Vehicle
{
    public Airplane(string RegistrationNO,
                    string Color,
                    uint NumberOfEngines,
                    uint CylinderVolum,
                    FuelType FuelType,
                    uint NumberOfSeats,
                    uint Length)
                    : base(VehicleType.Airplane,
                            RegistrationNO,
                            Color,
                            NumberOfEngines,
                            CylinderVolum,
                            FuelType,
                            NumberOfSeats,
                            Length)
    {
    }
}


public class Motorcycle : Vehicle
{
    public Motorcycle(string RegistrationNO,
                    string Color,
                    uint NumberOfEngines,
                    uint CylinderVolum,
                    FuelType FuelType,
                    uint NumberOfSeats,
                    uint Length)
                    : base(VehicleType.Motorcycle,
                            RegistrationNO,
                            Color,
                            NumberOfEngines,
                            CylinderVolum,
                            FuelType,
                            NumberOfSeats,
                            Length)
    {
    }
}


public class Car : Vehicle
{
    public Car(string RegistrationNO,
                string Color,
                uint NumberOfEngines,
                uint CylinderVolum,
                FuelType FuelType,
                uint NumberOfSeats,
                uint Length)
                : base(VehicleType.Car,
                        RegistrationNO,
                        Color,
                        NumberOfEngines,
                        CylinderVolum,
                        FuelType,
                        NumberOfSeats,
                        Length)
    {
    }
}


public class Bus : Vehicle
{
    public Bus(string RegistrationNO,
                    string Color,
                    uint NumberOfEngines,
                    uint CylinderVolum,
                    FuelType FuelType,
                    uint NumberOfSeats,
                    uint Length)
                    : base(VehicleType.Bus,
                            RegistrationNO,
                            Color,
                            NumberOfEngines,
                            CylinderVolum,
                            FuelType,
                            NumberOfSeats,
                            Length)
    {
    }
}


public class Boat : Vehicle
{
    public Boat(string RegistrationNO,
                    string Color,
                    uint NumberOfEngines,
                    uint CylinderVolum,
                    FuelType FuelType,
                    uint NumberOfSeats,
                    uint Length)
                    : base(VehicleType.Boat,
                            RegistrationNO,
                            Color,
                            NumberOfEngines,
                            CylinderVolum,
                            FuelType,
                            NumberOfSeats,
                            Length)
    {
    }
}

