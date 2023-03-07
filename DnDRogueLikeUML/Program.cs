using DnDRogueLikeUML.Creatures.Player;
using DnDRogueLikeUML.Items.WieldableItems;
using System;
using System.Net;

// A DnD dungeon crawler. The game will eventually have fighting, exploring and shopping (to change weapons, armor, consumables and enchantments). More spells will be added, as well as a bunch of new mobs.  

namespace DnDRogueLikeUML
{

    internal class Program
    {
        static void Main(string[] args)
        {
            Player player = Player.GenerateClass();

            Console.WriteLine(player.Health);

            new Forest(player);
            new Forest(player);
            new Forest(player);



            if (player.Level >= 2)
            {
                new Desert(player);
            }

            Console.WriteLine($"{player.Name} survived... for now");
        }
    }
}
