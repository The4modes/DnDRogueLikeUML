using DnDRogueLikeUML.Creatures.Player;
using DnDRogueLikeUML.Items.WieldableItems;
using System;
using System.Net;

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
