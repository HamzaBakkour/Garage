using Garage.Abstraction;
using Garage.UI;
using Garage.Vehicles;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace Garage;

internal class Program
{
    static void Main(string[] args)
    {
        IConfiguration config = new ConfigurationBuilder()
                                .SetBasePath(Environment.CurrentDirectory)
                                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                                .Build();

        var host = Host.CreateDefaultBuilder(args)
                        .ConfigureServices(services =>
                        {
                            services.AddSingleton<IConfiguration>(config);
                            services.AddSingleton<IUI, ConsoleUI>();
                            services.AddSingleton<ICreateVehicle, CreateVehicle>();
                            
                            services.AddSingleton<List<Vehicle>>(new List<Vehicle>
                            {
                                new Car("abc1", "Red", 1, 122),
                                new Motorcycle("abc2", "Blue", 2, 50),
                                new Bus("abc3", "Green", 4, 332)
                            });

                            // Register GarageHandler
                            services.AddSingleton<IGarageHandler<Vehicle>>(provider =>
                            {
                                var ui = provider.GetRequiredService<IUI>();
                                var vehicles = provider.GetRequiredService<List<Vehicle>>();
                                return new GarageHandler<Vehicle>(15, vehicles, ui);
                            });

                            services.AddSingleton<Main>();

                        })
                        .UseConsoleLifetime()
                        .Build();


        host.Services.GetRequiredService<Main>().Run();

        Console.WriteLine("Garage app ended.");

        //var initialVehicles = new List<Vehicle>
        //{
        //    new Car("abc1", "Red", 1, 122),
        //    new Motorcycle("abc2", "Blue", 2, 50),
        //    new Bus("abc3", "Green", 4, 332)

        //};

        //ICreateVehicle createVehicle = new CreateVehicle();



        //IUI ui = new ConsoleUI();

        //IGarageHandler<Vehicle> garageHandler = new GarageHandler<Vehicle>(15, initialVehicles, ui);


        //Main main = new Main(garageHandler, createVehicle, ui);

        //main.Run();
    }
}
