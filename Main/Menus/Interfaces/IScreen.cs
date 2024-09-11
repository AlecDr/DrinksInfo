namespace Drinks_Info.Menus.Interfaces;

internal interface IScreen
{
    void Run();

    List<string> GetMenuChoices();

    void RouteToOption(char option);
}
