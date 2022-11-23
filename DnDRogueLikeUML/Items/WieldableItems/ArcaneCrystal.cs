using DnDRogueLikeUML.Creatures.Player;
using System;

namespace DnDRogueLikeUML.Items.WieldableItems
{
    class ArcaneCrystal : IWieldableItem
    {
        public HumanoidCreature Wielder { get; set; }
        public string Name { get; set; }
        public string Rarity { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public string Description { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public ArcaneCrystal()
        {
            Name = "Arcane Crystal";
        }

        public void Equip(HumanoidCreature player)
        {
            Wielder = player;
            player.LeftHand.UnEquip();
            player.LeftHand = this;

            Console.WriteLine($"{Name} was equiped on {Wielder.Name} left hand");
        }

        public void UnEquip()
        {
            Wielder.LeftHand = null;
            Console.WriteLine($"{Name} was unequiped on {Wielder.Name} left hand");
        }
    }
}
