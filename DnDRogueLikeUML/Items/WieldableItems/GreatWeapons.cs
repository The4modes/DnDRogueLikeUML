using System;
using DnDRogueLikeUML.Creatures;
using DnDRogueLikeUML.Items.UsableItems;
using DnDRogueLikeUML.Creatures.Player;
using System.Collections.Generic;
using System.Xml.Linq;

namespace DnDRogueLikeUML.Items.WieldableItems
{
    abstract class GreatWeapons : IWieldableItem, IUsableItem
    {
        public Player Wielder { get; set; }
        public string Name { get; set; }
        public string Rarity { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Description { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Type { get; set; }
        public ICreature User { get; set; }
        public List<Type> AvailableLocations { get; set; }

        public void Equip(Player player)
        {
            Wielder = player;
            Wielder.ActionList.Add(this);
            player.RightHand = this;
            player.LeftHand = this;

            Console.WriteLine($"{Name} was equiped on {player.Name}");
        }

        public void UnEquip()
        {
            Wielder.ActionList.Remove(this);

            Wielder.RightHand = null;
            Wielder.LeftHand = null;
            Console.WriteLine($"{Name} was unequiped from {Wielder.Name}");
            Wielder = null;

            
        }

        public abstract void DoAction(List<ICreature> targets);
    }
}
