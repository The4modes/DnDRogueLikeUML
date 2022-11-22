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

            player.WieldableItemsList.Add( new GreatLongSword() );
            player.WieldableItemsList.Add( new GreatAxe() );

            player.EquipItem();

            player.DoAction();

            player.RightHand.UnEquip();

            Console.WriteLine(player.RightHand);

            player.DoAction();
        }
    }
}
