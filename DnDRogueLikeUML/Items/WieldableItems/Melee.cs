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
            DamageDie = 4;
        }

        public void DoAction(List<ICreature> targets)
        {
            Console.WriteLine("Slapidislap");
            throw new NotImplementedException();
        }

        public void Equip(Player player)
        {
            Wielder = player;
            
            if (player.RightHand == null)
            {
                Name = "Right Hand";
                Wielder.ActionList.Add(this);
                player.RightHand = this;
                equippedHand = "Right";
            }
            else if (player.LeftHand == null)
            {
                Name = "Left Hand";
                Wielder.BonusActionList.Add(this);
                player.LeftHand = this;
                equippedHand = "Left";
            }
            
        }

        public void UnEquip()
        {
            switch (equippedHand)
            {
                case "Right":
                    Wielder.ActionList.Remove(this);
                    break;
                case "Left":
                    Wielder.BonusActionList.Remove(this);
                    break;
                default:
                    throw new NotImplementedException("Something went wrong with unequiping Hands");
            }
        }
    }
}
