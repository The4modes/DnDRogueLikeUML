using System.Collections.Generic;
using System;
using Spectre.Console;

namespace DnDRogueLikeUML
{
    class ConsoleHandler
    {
        public static string SingleSelect(string[] choices, string title)
        {
            Random random = new Random();

            string targetChoice = AnsiConsole.Prompt(
                        new SelectionPrompt<string>()
                            .Title(title)
                            .PageSize(10)
                            .HighlightStyle<string>(Style.Plain)
                            .AddChoices(choices));

            return targetChoice;
        }

        public static List<string> MultiSelect(string[] choices, string title)
        {
            List<string> choice = AnsiConsole.Prompt(new MultiSelectionPrompt<string>()
                    .Title(title)
                    .NotRequired()
                    .PageSize(10)
                    .MoreChoicesText("[grey](Move up and down to reveal more)[/]")
                    .AddChoices(choices));

            return choice;
        }
    }
}
