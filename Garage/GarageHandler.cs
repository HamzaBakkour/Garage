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


    public GarageHandler(int capacity, List<T> vehicles, IUI ui)
    {
        _garage = new Garage<T>(capacity, vehicles);
        this._ui = ui;
    }

    public bool IsFull() => _garage.IsFull();


    public bool Park(T vehicle) =>
                                _garage.Park(vehicle);

    public bool Leave(string registrationNO) =>
                            _garage.Leave(registrationNO);


    public List<T> ListAll() =>
                            _garage.ListAll();

    public T? FindByRegistrationNO(string registrationNO) =>
                            _garage.ListAll()
                            .Where(v => v != null && v.RegistrationNO == registrationNO.ToUpper())
                            .FirstOrDefault();

    public List<T> FindAllByColor(string color) =>
                                _garage.ListAll()
                                .Where(v => v != null && v.Color == color.ToUpper())
                                .ToList();

    public List<T> FindAllByFuelType(FuelType fuelType) =>
                                _garage.ListAll()
                                .Where(v => v != null && v.FuelType == fuelType)
                                .ToList();

    public Dictionary<VehicleType, int> ListAllDetailed() =>
                                _garage.ListAll()
                                .Where(v => v != null)
                                .GroupBy(v => v.VehicleType)
                                .ToDictionary(g => g.Key, g => g.Count());

    public List<T> FindAllByColorAndNumberOfSeats(string color, uint numberOfSeats) =>
                                _garage.ListAll()
                                .Where(v => v != null && v.Color == color && v.NumberOfSeats == numberOfSeats)
                                .ToList();

}
