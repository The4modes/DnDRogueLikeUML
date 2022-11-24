using DnDRogueLikeUML.Creatures.Player;
using System;

namespace DnDRogueLikeUML.Items.WieldableItems
{
    class WoodenWand : MeleeItem
    {
        public string EquipedHand { get; set; }

        public WoodenWand()
        {
            Name = "Wooden Wand";
        }

        public override void Equip(HumanoidCreature player)
        {
            Wielder = player;
            player.LeftHand.UnEquip();
            player.LeftHand = this;
            EquipedHand = "left hand";

            Console.WriteLine($"{Name} was equiped on {Wielder.Name} {EquipedHand}");
        }

        public override void UnEquip()
        {
            Wielder.LeftHand = null;
            EquipedHand = null;
            Console.WriteLine($"{Name} was unequiped on {Wielder.Name} {EquipedHand}");
        }
    }
}
