namespace GarageTest;

using System.Diagnostics.Metrics;
using Garage;
using Garage.Abstraction;
using Garage.Vehicles;
using Xunit;

public class GarageTest
{

    private readonly Garage<Vehicle> _garage;

    public GarageTest()
    {
        Vehicle.ClearRegistredVehicles();
        var initialVehicles = new List<Vehicle>
        {
            new Car("abc1", "Red", 1, 122),
            new Motorcycle("abc2", "blue", 2, 50),
            new Bus("abc3", "green", 4, 332)

        };

        _garage = new Garage<Vehicle>(5, initialVehicles);
    }


    [Fact]
    public void Park_ParkValidVehicle_True()
    {
        var result = _garage.Park(new Boat("abc4", "yellow", 2, 232));
        Assert.True(result);
    }


    [Fact]
    public void Leave_VehicleExistInGarage_True()
    {
        var result = _garage.Leave("ABC3");
        Assert.True(result);
    }


    [Fact]
    public void Leave_VehicleDoesNotExistInGarage_False()
    {
        var result = _garage.Leave("ABC10");
        Assert.False(result);
    }


    [Fact]
    public void ListAll__ListOfVehicles()
    {
        var result = _garage.ListAll();
        
        Assert.Equal(3, result.Count);
        Assert.Contains(result, v => v.RegistrationNO == "ABC1");
        Assert.Contains(result, v => v.RegistrationNO == "ABC2");
        Assert.Contains(result, v => v.RegistrationNO == "ABC3");
    }


    //[Fact]
    //public void ListAllDetailed__ListOfVehiclesCount()
    //{
    //    var result = _garage.ListAllDetailed();

    //    Assert.Equal(3, result.Count); 

    //    Assert.True(result.ContainsKey(VehicleType.Car));
    //    Assert.True(result.ContainsKey(VehicleType.Motorcycle));
    //    Assert.True(result.ContainsKey(VehicleType.Bus));

    //    Assert.Equal(1, result[VehicleType.Car]);
    //    Assert.Equal(1, result[VehicleType.Motorcycle]);
    //    Assert.Equal(1, result[VehicleType.Bus]);
    //}


    //[Fact]
    //public void FindByRegistrationNO_ExistingVehicle_ReturnsMatchingVehicle()
    //{
    //    var result = _garage.FindByRegstrationNO("ABC2");

    //    Assert.NotNull(result);
    //    Assert.Equal("ABC2", result.RegistrationNO);
    //}


    //[Fact]
    //public void FindByRegistrationNO_NonExistingVehicle_ReturnsNull()
    //{
    //    var result = _garage.FindByRegstrationNO("ABC10");
    //    Assert.Null(result);
    //}


    //[Fact]
    //public void FindAllByColor_ColorExists_ReturnsMatchingVehicles()
    //{
    //    var result = _garage.FindAllByColor("BLUE");
    //    Assert.Equal("ABC2", result[0].RegistrationNO);
    //    Assert.IsType<Motorcycle>(result[0]);
    //}

    //[Fact]
    //public void FindAllByColor_ColorDoesNotExist_ReturnsEmptyList()
    //{
    //    var result = _garage.FindAllByColor("YELLOW");
    //    Assert.Empty(result);
    //}


    //[Fact]
    //public void FindAllByFuelType_FuelTypeExists_ReturnsMatchingVehicles()
    //{
    //    var result = _garage.FindAllByFuelType(FuelType.Diesel);

    //    Assert.Equal(2, result.Count);
    //    Assert.Equal(FuelType.Diesel, result[0].FuelType);
    //    Assert.Equal(FuelType.Diesel, result[0].FuelType);
    //}


    //[Fact]
    //public void FindAllByColorAndNumberOfSeats_Match_ReturnsMatchingVehicles()
    //{

    //    var result = _garage.FindAllByColorAndNumberOfSeats("BLUE", 2);

    //    Assert.Single(result);
    //    Assert.Equal("ABC2", result[0].RegistrationNO);
    //    Assert.Equal(2u, result[0].NumberOfSeats);
    //    Assert.Equal("BLUE", result[0].Color);

    //}

    //[Fact]
    //public void FindAllByColorAndNumberOfSeats_SeatsOnlyMatch_ReturnsEmptyList()
    //{
    //    var result = _garage.FindAllByColorAndNumberOfSeats("RED", 2);
    //    Assert.Empty(result);
    //}

}
