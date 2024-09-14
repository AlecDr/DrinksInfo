using Drinks_Info.Data.DTOs.Drinks;
using Drinks_Info.Helpers;
using Drinks_Info.Menus.Interfaces;
using Drinks_Info.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Drinks_Info.Menus;

internal class DrinksScreen : IScreen
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ConsoleHelper _consoleHelper;
    private readonly DrinksInfoHelper _drinksInfoHelper;
    private readonly IDrinksService _drinksService;
    private List<DrinkSimplifiedDTO> Drinks { get; set; }

    public DrinksScreen(
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
        _consoleHelper.ShowMessage("Fetching Drinks...");
        try
        {


            List<DrinkSimplifiedDTO> drinks = _drinksService.AllDrinksByCategoryName(_drinksInfoHelper.SelectedCategory!.Name).Result;
            Drinks = new List<DrinkSimplifiedDTO>(drinks);

            _consoleHelper.ClearWindow();

            string option = _consoleHelper.GetOption("Drinks", GetMenuChoices());
            RouteToOption(option.ElementAt(0));
        }
        catch (Exception ex)
        {
            _consoleHelper.ClearWindow();
            _consoleHelper.PressAnyKeyToContinue("Something went wrong in the application, try again later;");
            MainMenu();

        }
    }

    public void RouteToOption(char option)
    {
        int intOption = int.Parse(option.ToString());
        int drinksCount = Drinks.Count + 1;

        if (intOption <= drinksCount)
            DrinkDetailsScreen(intOption);
        else if (intOption == drinksCount + 1)
            MainMenu();
        else
            Run();
    }

    public List<string> GetMenuChoices()
    {
        List<string> options = [];
        int i;

        for (i = 0; i < Drinks.Count; i++)
        {
            DrinkSimplifiedDTO drink = Drinks.ElementAt(i);

            options.Add($"{i + 1} - [slateblue1]{drink.Name}[/]");
        }

        options.Add($"[slateblue1]{i + 1}[/] - Main Menu");

        return options;
    }

    private void MainMenu()
    {
        _drinksInfoHelper.ChangeMenu(_serviceProvider.GetRequiredService<MainMenu>());
    }

    private void DrinkDetailsScreen(int drinkIndex)
    {
        _drinksInfoHelper.SelectedDrinkId = int.Parse(Drinks[drinkIndex - 1].Id);
        _drinksInfoHelper.ChangeMenu(_serviceProvider.GetRequiredService<DrinkDetailsScreen>());
    }


}
