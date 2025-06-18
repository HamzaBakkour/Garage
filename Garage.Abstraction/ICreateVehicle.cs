using Garage.Abstraction;

namespace Garage;

public interface ICreateVehicle
{
    Vehicle Create(IUI _ui, List<Vehicle> registeredVehicles);
}