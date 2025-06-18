using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Garage.Abstraction;

namespace Garage;

internal class GarageHandler<T> : IGarageHandler<T> where T : Vehicle
{
    private readonly Garage<T> _garage;
    private readonly IUI _ui;
    private ICreateVehicle _createVehicle;


    public GarageHandler(int capacity, List<T> vehicles, ICreateVehicle createVehicle, IUI ui)
    {
        _garage = new Garage<T>(capacity, vehicles);
        this._createVehicle = createVehicle;
        this._ui = ui;
    }

    public bool IsFull() => _garage.IsFull();


    public void Park()
    {
        try
        {
            Vehicle vehicle = _createVehicle.Create(_ui);

            if (vehicle is T typedVehicle)
            {
                bool success = _garage.Park(typedVehicle);
                _ui.Print(success
                    ? "Vehicle parked successfully."
                    : "Could not park the vehicle. The garage is full" +
                        " or the vehicle is already parked.");
            }
            else
            {
                _ui.Print("Error: The created vehicle is not of the expected type.");
            }
        }
        catch (Exception ex)
        {
            _ui.Print($"Unexpected error: {ex.Message}");
        }
    }

    public void Leave() {
        _ui.Print("RegistrationNO:");
        string regNo = _ui.GetInput();
        bool success = _garage.Leave(regNo.ToUpper());

        _ui.Print(success
        ? "Vehicle leaved"
        : $"No vehicle with regstration number {regNo} exist");
    }


    public List<T> ListAll() =>
                            _garage.ListAll();

    public T? FindByRegistrationNO(string registrationNO) =>
                            _garage.FindByRegstrationNO(registrationNO);

    public List<T> FindAllByColor(string color) =>
                            _garage.FindAllByColor(color);

    public List<T> FindAllByFuelType(FuelType fuelType) =>
                            _garage.FindAllByFuelType(fuelType);

    public Dictionary<VehicleType, int> ListAllDetailed() =>
                            _garage.ListAllDetailed();

    public List<T> FindAllByColorAndNumberOfSeats(string color, uint numberOfSeats) =>
                        _garage.FindAllByColorAndNumberOfSeats(color, numberOfSeats);

}
