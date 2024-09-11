using Drinks_Info.Helpers;
using Drinks_Info.Menus.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Drinks_Info.Menus;

internal class MainMenu : IScreen
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ConsoleHelper _consoleHelper;
    private readonly DrinksInfoHelper _drinksInfoHelper;

    public MainMenu(
        IServiceProvider serviceProvider,
        ConsoleHelper consoleHelper,
        DrinksInfoHelper drinksInfoHelper
        )
    {
        _serviceProvider = serviceProvider;
        _consoleHelper = consoleHelper;
        _drinksInfoHelper = drinksInfoHelper;
    }

    public void Run()
    {
        _consoleHelper.ClearWindow();

        string option = _consoleHelper.GetOption("Main Menu", GetMenuChoices());

        RouteToOption(option.ElementAt(0));
    }

    public void RouteToOption(char option)
    {
        switch (option)
        {
            case '1':
                ShowCategories();
                break;
            case '2':
                Environment.Exit(0);
                break;
            default:
                Run();
                break;
        }
    }

    public List<string> GetMenuChoices()
    {

        return [
        "1 - [slateblue1]S[/]how Categories",
        "2 - [slateblue1]E[/]xit",
        ];
    }

    private void ShowCategories()
    {
        _drinksInfoHelper.ChangeMenu(_serviceProvider.GetRequiredService<CategoriesScreen>());
    }


}
