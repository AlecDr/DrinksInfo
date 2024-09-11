using Drinks_Info.Data.DTOs.Categories;
using Drinks_Info.Menus;
using Drinks_Info.Menus.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Drinks_Info.Helpers;

internal class DrinksInfoHelper
{
    private readonly ConsoleHelper _consoleHelper;
    private readonly IServiceProvider _serviceProvider;
    private IScreen? _currentMenu;
    public CategoryDTO? SelectedCategory { get; set; }
    public int? SelectedDrinkId { get; set; }

    public DrinksInfoHelper(ConsoleHelper consoleHelper, IServiceProvider serviceProvider)
    {
        _consoleHelper = consoleHelper;
        _serviceProvider = serviceProvider;
    }

    internal IScreen? CurrentMenu => _currentMenu;

    internal void Run()
    {
        if (CurrentMenu == null)
        {
            _currentMenu = _serviceProvider.GetRequiredService<MainMenu>();
        }

        CurrentMenu!.Run();
    }

    internal void ChangeMenu(IScreen menu)
    {
        _currentMenu = menu;
        Run();
    }


}
