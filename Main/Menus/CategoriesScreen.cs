using Drinks_Info.Data.DTOs.Categories;
using Drinks_Info.Helpers;
using Drinks_Info.Menus.Interfaces;
using Drinks_Info.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Drinks_Info.Menus;

internal class CategoriesScreen : IScreen
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ConsoleHelper _consoleHelper;
    private readonly DrinksInfoHelper _drinksInfoHelper;
    private readonly IDrinksService _drinksService;
    private List<CategoryDTO> Categories { get; set; }

    public CategoriesScreen(
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
        _consoleHelper.ShowMessage("Fetching categories...");

        List<CategoryDTO> categories = _drinksService.AllCategories().Result;
        Categories = new List<CategoryDTO>(categories);

        _consoleHelper.ClearWindow();

        string option = _consoleHelper.GetOption("Categories", GetMenuChoices());
        RouteToOption(option.ElementAt(0));
    }

    public void RouteToOption(char option)
    {
        int intOption = int.Parse(option.ToString());
        int categoriesCount = Categories.Count + 1;

        if (intOption <= categoriesCount)
            DrinksMenu(intOption);
        else if (intOption == categoriesCount + 1)
            MainMenu();
        else
            Run();
    }

    public List<string> GetMenuChoices()
    {
        List<string> options = [];
        int i;

        for (i = 0; i < Categories.Count; i++)
        {
            CategoryDTO category = Categories.ElementAt(i);

            options.Add($"{i + 1} - [slateblue1]{category.Name}[/]");
        }

        options.Add($"{i + 1} - [slateblue1]Main Menu[/]");

        return options;
    }

    private void MainMenu()
    {
        _drinksInfoHelper.ChangeMenu(_serviceProvider.GetRequiredService<MainMenu>());
    }

    private void DrinksMenu(int categoryIndex)
    {
        _drinksInfoHelper.SelectedCategory = Categories[categoryIndex - 1];
        _drinksInfoHelper.ChangeMenu(_serviceProvider.GetRequiredService<DrinksScreen>());
    }
}
