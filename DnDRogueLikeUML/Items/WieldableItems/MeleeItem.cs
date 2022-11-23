using DnDRogueLikeUML.Creatures;
using DnDRogueLikeUML.Creatures.Player;
using System;
using System.Collections.Generic;

namespace DnDRogueLikeUML.Items.WieldableItems
{
    abstract class MeleeItem : IWieldableItem
    {
        public HumanoidCreature Wielder { get; set; }
        public string Name { get; set; }
        public string Rarity { get; set; }
        public string Description { get; set; }
        public string Type { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public ICreature User { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public List<Type> AvailableLocations { get; set; }

        protected string equippedHand;

        public abstract void Equip(HumanoidCreature creature);
        public abstract void UnEquip();
    }
}
