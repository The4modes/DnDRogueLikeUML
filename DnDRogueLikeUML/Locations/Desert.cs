using DnDRogueLikeUML.Creatures;
using DnDRogueLikeUML.Creatures.Player;
using System;
using System.Collections.Generic;

namespace DnDRogueLikeUML
{
    class Desert : ILocation
    {
        private int NumberOfEncounters;

        private static Random random = new Random();

        private static List<Type> availableCreatures = new List<Type>() { };

        public Desert(Player player)
        {
            NumberOfEncounters = random.Next(1, 5);
            player.CurrentLocation = typeof(Desert);
            for (int i = 0; i < NumberOfEncounters; i++)
            {
                LocationScript(player);
            }
        }

        public void LocationScript(Player player)
        {
            Console.WriteLine($"{player.Name} walks in to a Desert");

            if (random.NextDouble() < 0.75)
            {
                new Battle(player);
            }
            else
            {
                DesertExploration(player);
            }
        }

        private void DesertExploration(Player player)
        {
            Random random = new Random();

            string choice = ConsoleHandler.SingleSelect(new string[]
            { "Explore - [grey]chance to find loot[/]",
                "Rest - [grey]restore some health[/]" },
                "What do you want to do next?");

            switch (choice)
            {
                case "Explore - [grey]chance to find loot[/]":
                    Console.WriteLine("You have found a potion!");
                    //ItemManager.AddItemToInventory(player, new PotionOfHealing(player));
                    //ItemManager.DisplayInventory(player);
                    break;
                case "Rest - [grey]restore some health[/]":
                    int healed = random.Next(1, player.MaxHealth);
                    player.Health += healed;
                    Console.WriteLine($"{player.Name} healed {healed}. Current HP: {player.Health}");
                    break;
                default:
                    throw new NotImplementedException("Something went wrong with the choice");
            }

            player.DoAction(new List<ICreature>() { player });
        }
    }
}
