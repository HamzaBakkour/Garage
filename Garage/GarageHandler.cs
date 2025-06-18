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


    public GarageHandler(int capacity)
    {
        _garage = new Garage<T>(capacity);
    }

    public GarageHandler(int capacity, List<T> vehicles)
    {
        _garage = new Garage<T>(capacity, vehicles);
    }

    public bool IsFull() =>
        _garage.IsFull();

    public bool Park(T vehicle) =>
                            _garage.Park(vehicle);

    public bool Leave(string registrationNO) =>
                            _garage.Leave(registrationNO);

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
