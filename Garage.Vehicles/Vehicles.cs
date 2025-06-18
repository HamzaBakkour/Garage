using Garage.Abstraction;

namespace Garage.Vehicles;

public class Airplane: Vehicle
{
    public Airplane(string RegistrationNO,
                    string Color,
                    //uint NumberOfEngines,
                    //uint CylinderVolum,
                    //FuelType FuelType,
                    uint NumberOfSeats,
                    uint Length)
                    : base(VehicleType.Airplane,
                            RegistrationNO,
                            Color,
                            4,
                            500,
                            FuelType.Gasoline,
                            NumberOfSeats,
                            Length)
    {
    }
}


public class Motorcycle : Vehicle
{
    public Motorcycle(string RegistrationNO,
                    string Color,
                    //uint NumberOfEngines,
                    //uint CylinderVolum,
                    //FuelType FuelType,
                    uint NumberOfSeats,
                    uint Length)
                    : base(VehicleType.Motorcycle,
                            RegistrationNO,
                            Color,
                            1,
                            50,
                            FuelType.Diesel,
                            NumberOfSeats,
                            Length)
    {
    }
}


public class Car : Vehicle
{
    public Car(string RegistrationNO,
                string Color,
                //uint NumberOfEngines,
                //uint CylinderVolum,
                //FuelType FuelType,
                uint NumberOfSeats,
                uint Length)
                : base(VehicleType.Car,
                        RegistrationNO,
                        Color,
                        1,
                        200,
                        FuelType.Diesel,
                        NumberOfSeats,
                        Length)
    {
    }
}


public class Bus : Vehicle
{
    public Bus(string RegistrationNO,
                    string Color,
                    //uint NumberOfEngines,
                    //uint CylinderVolum,
                    //FuelType FuelType,
                    uint NumberOfSeats,
                    uint Length)
                    : base(VehicleType.Bus,
                            RegistrationNO,
                            Color,
                            1,
                            250,
                            FuelType.Diesel,
                            NumberOfSeats,
                            Length)
    {
    }
}


public class Boat : Vehicle
{
    public Boat(string RegistrationNO,
                    string Color,
                    //uint NumberOfEngines,
                    //uint CylinderVolum,
                    //FuelType FuelType,
                    uint NumberOfSeats,
                    uint Length)
                    : base(VehicleType.Boat,
                            RegistrationNO,
                            Color,
                            2,
                            130,
                            FuelType.Diesel,
                            NumberOfSeats,
                            Length)
    {
    }
}

