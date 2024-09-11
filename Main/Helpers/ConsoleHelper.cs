using Microsoft.Extensions.DependencyInjection;
using Spectre.Console;

namespace Drinks_Info.Helpers;

internal class ConsoleHelper
{
    private readonly IServiceProvider _serviceProvider;

    public ConsoleHelper(
        IServiceProvider serviceProvider
    )
    {
        _serviceProvider = serviceProvider;
    }

    internal string GetOption(string menuTitle, List<string> menuChoices, string? menuSubtitle = null)
    {
        DrinksInfoHelper drinksInfoCardsHelper = _serviceProvider.GetRequiredService<DrinksInfoHelper>();

        string option = ShowMenu(menuChoices, menuTitle, menuSubtitle);

        while (option == null || option.Trim() == "")
        {
            ClearWindow();
            GetOption(menuTitle, menuChoices);
        }

        return option;
    }

    internal string ShowMenu(List<string> menuChoices, string menuTitle, string? menuSubTitle = null)
    {
        ShowMessage($"DrinksInfo - [underline darkslategray2]{menuTitle}[/] {menuSubTitle ?? ""}", true, true, false);
        ShowMessage("");

        return GetChoice(menuChoices, "Choose an option bellow");
    }

    internal void ClearWindow()
    {
        AnsiConsole.Clear();
    }

    internal void ShowMessage(
        string message,
        bool breakLine = true,
        bool shouldClearWindow = false,
        bool figlet = false)
    {
        if (shouldClearWindow)
        {
            ClearWindow();
        }

        if (figlet)
        {
            if (breakLine)
            {
                AnsiConsole.WriteLine();
                AnsiConsole.Write(
            new FigletText(message)
                .LeftJustified()
                .Color(Color.SlateBlue1));
            }
            else
            {

                AnsiConsole.Write(
                new FigletText(message)
                    .LeftJustified()
                    .Color(Color.SlateBlue1));
            }
        }
        else
        {
            if (breakLine)
            {
                AnsiConsole.MarkupLine(message);
            }
            else
            {
                AnsiConsole.Markup(message);
            }
        }

    }

    internal string GetChoice(
        List<string> choices,
        string title,
        int pageSize = 10,
        string moreChoicesText = "[grey](Move up and down to reveal more options)[/]")
    {
        var highlightStyle = new Style().Foreground(Color.SlateBlue1);

        return AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title(title)
                .PageSize(pageSize)
                .HighlightStyle(highlightStyle)
                .MoreChoicesText(moreChoicesText)
                .AddChoices(choices));
    }

    internal void PressAnyKeyToContinue(string? message = null)
    {
        ShowMessage("");

        if (message != null)
        {
            ShowMessage(message);
        }

        ShowMessage("Press any key to continue");
        AnsiConsole.Console.Input.ReadKey(false);
    }

    internal void ShowTitle(string message, bool mustClearWindow = true)
    {
        ShowMessage($"DrinksInfo - [underline slateblue1]{message}[/]", true, mustClearWindow, false);
        ShowMessage("");
    }
}
