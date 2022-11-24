using System.Collections.Generic;
using System;
using Spectre.Console;
using System.Threading;

namespace DnDRogueLikeUML
{
    class ConsoleHandler
    {
        public static void DisplayStats(string[] stats)
        {
            Table table = new Table().Centered();

            AnsiConsole.Live(table)
                .Start(ctx =>
                {
                    table.AddColumn("Stats:");
                    ctx.Refresh();
                    Thread.Sleep(1000);

                    table.AddColumn("Str");
                    ctx.Refresh();

                    table.AddColumn("Dex");
                    ctx.Refresh();

                    table.AddColumn("Con");
                    ctx.Refresh();

                    table.AddColumn("Int");
                    ctx.Refresh();

                    table.AddColumn("Wis");
                    ctx.Refresh();

                    table.AddColumn("Cha");
                    ctx.Refresh();

                    table.AddRow(stats);
                    ctx.Refresh();
                });
        }

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
