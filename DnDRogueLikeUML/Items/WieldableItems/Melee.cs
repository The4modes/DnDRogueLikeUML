using DnDRogueLikeUML.Action;
using DnDRogueLikeUML.Creatures;
using DnDRogueLikeUML.Creatures.Player;
using System;
using System.Collections.Generic;

namespace DnDRogueLikeUML.Items.WieldableItems
{
    class Melee : IWieldableItem, IAction
    {
        public Player Wielder { get; set; }
        public string Name { get; set; }
        public string Rarity { get; set; }
        public string Description { get; set; }
        public string Type { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public ICreature User { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public List<Type> AvailableLocations { get; set; }

        private int DamageDie;

        private string equippedHand;

        public Melee()
        {
            AvailableLocations = new List<Type>() { typeof(Battle) };
            DamageDie = 12;
        }

        public void DoAction(List<ICreature> targets)
        {
            Console.WriteLine("Slapidislap");
            throw new NotImplementedException();
        }

        public void Equip(Player player)
        {
            Wielder = player;
            Wielder.ActionList.Add(this);

            if (player.RightHand == null)
            {
                Name = "Right Hand";
                Console.WriteLine($"{Name} was equiped on {player.Name} right hand");
                player.RightHand = this;
            }
            else if (player.LeftHand == null)
            {
                Name = "Left Hand";
                Console.WriteLine($"{Name} was equiped on {player.Name} left hand");
                player.LeftHand = this;
            }
            else
            {
                string choice = ConsoleHandler.SingleSelect(new string[] { "[grey]Right Hand[/]", "[grey]Left Hand[/]" }, "What hand do you want to use bare fist?");

                switch (choice)
                {
                    case "[grey]Right Hand[/]":
                        player.RightHand = this;
                        Name = "Right Hand";
                        Console.WriteLine($"{Name} was equiped on {player.Name} right hand");
                        equippedHand = "Right";
                        break;
                    case "[grey]Left Hand[/]":
                        player.LeftHand = this;
                        Name = "Left Hand";
                        Console.WriteLine($"{Name} was equiped on {player.Name} left hand");
                        equippedHand = "Left";
                        break;
                    default:
                        throw new NotImplementedException("No hand selected, something went wrong");
                }
            }

            
        }

        public void UnEquip()
        {
            switch (equippedHand)
            {
                case "Right":
                    Wielder.RightHand = null;
                    Console.WriteLine($"{Name} was unequiped on {Wielder.Name} right hand");
                    break;
                case "Left":
                    Wielder.LeftHand = null;
                    Console.WriteLine($"{Name} was unequiped on {Wielder.Name} left hand");
                    break;
                default:
                    throw new NotImplementedException("Something went wrong with unequiping Hands");
            }
        }
    }
}
