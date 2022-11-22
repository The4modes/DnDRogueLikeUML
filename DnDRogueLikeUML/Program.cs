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
            Console.WriteLine("Hello World!");

            Player player = Player.GenerateClass();

            new GreateAxe().Equip(player);

            player.DoAction();

            player.RightHand.UnEquip();

            player.DoAction();
        }
    }
}
