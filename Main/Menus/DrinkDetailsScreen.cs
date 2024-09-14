using Drinks_Info.Data.DTOs.Drinks;
using Drinks_Info.Helpers;
using Drinks_Info.Menus.Interfaces;
using Drinks_Info.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Spectre.Console;

namespace Drinks_Info.Menus;

internal class DrinkDetailsScreen : IScreen
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ConsoleHelper _consoleHelper;
    private readonly DrinksInfoHelper _drinksInfoHelper;
    private readonly IDrinksService _drinksService;
    private DrinkCompleteDTO? Drink { get; set; }

    public DrinkDetailsScreen(
        IServiceProvider serviceProvider,
        ConsoleHelper consoleHelper,
        DrinksInfoHelper drinksInfoHelper,
        IDrinksService drinksService
        )
    {
        _serviceProvider = serviceProvider;
        _consoleHelper = consoleHelper;
        _drinksInfoHelper = drinksInfoHelper;
        _drinksService = drinksService;
    }

    public void Run()
    {
        _consoleHelper.ClearWindow();
        _consoleHelper.ShowMessage("Fetching Drink...");

        try
        {
            DrinkCompleteDTO? drink = _drinksService.FindDrinkById(_drinksInfoHelper.SelectedDrinkId!.Value).Result;
            Drink = drink;

            _consoleHelper.ClearWindow();

            ShowDrinkDetails();

            _consoleHelper.PressAnyKeyToContinue();
            _drinksInfoHelper.SelectedCategory = null;
            _drinksInfoHelper.SelectedDrinkId = null;
            _drinksInfoHelper.ChangeMenu(_serviceProvider.GetRequiredService<MainMenu>());
        }
        catch (Exception ex)
        {
            _consoleHelper.ClearWindow();
            _consoleHelper.PressAnyKeyToContinue("Something went wrong in the application, try again later;");
            MainMenu();

        }
    }

    private void ShowDrinkDetails()
    {

        string? imagePath = _drinksService.GetImage(Drink!.Thumb, int.Parse(Drink!.Id)).Result;

        if (imagePath != null)
        {
            // Load an image
            var image = new CanvasImage(imagePath);

            // Set the max width of the image.
            // If no max width is set, the image will take
            // up as much space as there is available.
            image.MaxWidth(32);

            // Render the image to the console
            AnsiConsole.Write(image);

        }

        _consoleHelper.ShowMessage($"[slateblue1]Id[/]: {Drink!.Id}");
        _consoleHelper.ShowMessage($"[slateblue1]Name[/]: {Drink!.Name}");
        _consoleHelper.ShowMessage($"[slateblue1]Drink Alternative[/]: {Drink!.DrinkAlternative}");
        _consoleHelper.ShowMessage($"[slateblue1]Tags[/]: {Drink!.Tags}");
        _consoleHelper.ShowMessage($"[slateblue1]Category[/]: {Drink!.Category}");
        _consoleHelper.ShowMessage($"[slateblue1]Glass[/]: {Drink!.Glass}");
        _consoleHelper.ShowMessage($"[slateblue1]Instructions[/]: {Drink!.Instructions}");
        _consoleHelper.ShowMessage($"[slateblue1]Thumb[/]: {Drink!.Thumb}");
        _consoleHelper.ShowMessage($"[slateblue1]Date Modified[/]: {Drink!.DateModified}");
        _consoleHelper.ShowMessage($"[slateblue1]Ingredients[/]: {String.Join(", ", Drink!.Ingredients)}");
    }



    public void RouteToOption(char option)
    { }

    public List<string> GetMenuChoices()
    {
        return [];
    }
}
