using System;

namespace Garage.Abstraction;

public abstract class Vehicle
{
    protected static readonly List<string> RegisteredVehicles = new List<string>();

    private string _registrationNO;

    private string _color;

    private FuelType _fuelType;

    private VehicleType _vehicleType;


    public Vehicle(VehicleType VehicleType, string RegisterationNO, string Color,
                   uint NumberOfEngines, uint CylinderVolum,
                   FuelType FuelType, uint NumberOfSeats, uint Length) {

        this.VehicleType = VehicleType;
        this.RegistrationNO = RegisterationNO;
        this.Color = Color;
        this.NumberOfEngines = NumberOfEngines;
        this.CylinderVolum = CylinderVolum;
        this.FuelType = FuelType;
        this.NumberOfSeats = NumberOfSeats;
        this.Length = Length;

    }


    //TODO: print insted of throwing
    public string RegistrationNO
    {
        get => _registrationNO;
        init {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Regstration number can not be embty");
            if (value.Length > 6)
                throw new ArgumentException("Regstration number can not be longer than 6");
            if (RegisteredVehicles.Contains(value.ToUpper()))
                throw new ArgumentException("A vehicle with the same regstration number"+
                                                " already exist");

            RegisteredVehicles.Add(value.ToUpper());

            _registrationNO = value.ToUpper();
        }
    }


    //TODO: print insted of throwing
    public string Color
    {
        get => _color;
        init
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException();
            _color = value.ToUpper();
        }
    }


    public uint NumberOfEngines { get; set;}
    public uint CylinderVolum { get; set;}

    //TODO: print insted of throwing
    public FuelType FuelType {
        get => _fuelType;
        set {
            if (!Enum.IsDefined(typeof(FuelType), value))
                throw new ArgumentException("Invalid Fuel type.");
            _fuelType = value;

        }
    }

    public VehicleType VehicleType
    {
        get => _vehicleType;
        init
        {
            if (!Enum.IsDefined(typeof(VehicleType), value))
                throw new ArgumentException("Invalid Vehicle type.");
            _vehicleType = value;

        }
    }

    public uint NumberOfSeats { get; set; }

    public uint Length { get; set; }


    public override string ToString()
    {
        return
            $"Type: {VehicleType}, " +
            $"RegNo: {RegistrationNO}, " +
            $"Color: {Color}, " +
            $"Engines: {NumberOfEngines}, " +
            $"Volume: {CylinderVolum} cc, " +
            $"Fuel: {FuelType}, " +
            $"Seats: {NumberOfSeats}, " +
            $"Length: {Length} m";
    }

    public static void ClearRegistredVehicles() {
        RegisteredVehicles.Clear();
    }

}
