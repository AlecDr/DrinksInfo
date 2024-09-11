using Drinks_Info.Data.Repositories.Implementations;
using Drinks_Info.Data.Repositories.Interfaces;
using Drinks_Info.Helpers;
using Drinks_Info.Menus;
using Drinks_Info.Services.Implementations;
using Drinks_Info.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Drinks_Info;

internal class Program
{
    static void Main(string[] args)
    {
        // Step 1: Create a service collection (DI container)
        var serviceCollection = new ServiceCollection();

        // Step 2: Register your services
        ConfigureServices(serviceCollection);

        // Step 3: Build the service provider
        var serviceProvider = serviceCollection.BuildServiceProvider();

        // Step 4: Request the required service and run your application
        var app = serviceProvider.GetService<Program>();

        DrinksInfoHelper drinksInfoHelper = serviceProvider.GetRequiredService<DrinksInfoHelper>();

        try
        {
            drinksInfoHelper.Run();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }

    private static void ConfigureServices(IServiceCollection services)
    {
        // Register the others menus
        services.AddTransient<MainMenu>();
        services.AddTransient<CategoriesScreen>();
        services.AddTransient<DrinksScreen>();
        services.AddTransient<DrinkDetailsScreen>();

        // register Singletons
        services.AddSingleton<ConsoleHelper>();
        services.AddSingleton<DrinksInfoHelper>();

        // Register services with the container
        services.AddTransient<HttpClient>();
        services.AddTransient<IDrinksService, DrinksService>();
        services.AddTransient<IDrinkRepository, DrinkRepository>();
        services.AddTransient<ICategoryRepository, CategoryRepository>();
        services.AddTransient<IImagesRepository, ImagesRepository>();

        // Register the main app class (entry point for the app)
        services.AddSingleton<Program>();
    }
}
