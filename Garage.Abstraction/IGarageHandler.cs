using Garage.Abstraction;

namespace Garage;

public interface IGarageHandler<T> where T : Vehicle
{

    bool IsFull();
    void Park();
    void Leave();

    T? FindByRegistrationNO(string registrationNO);

    List<T> ListAll();

    Dictionary<VehicleType, int> ListAllDetailed();

    List<T> FindAllByColor(string color);

    List<T> FindAllByFuelType(FuelType fuelType);

    List<T> FindAllByColorAndNumberOfSeats(string color, uint numberOfSeats);

}