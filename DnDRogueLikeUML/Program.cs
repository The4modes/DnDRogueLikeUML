using DnDRogueLikeUML.Creatures.Player;
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

            player.DoAction();
        }
    }
}
