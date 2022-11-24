using DnDRogueLikeUML.Creatures.Player;
using System;

namespace DnDRogueLikeUML.Items.WieldableItems
{
    class ArcaneCrystal : MeleeItem
    {
        public string EquipedHand { get; set; }

        public ArcaneCrystal()
        {
            Name = "Arcane Crystal";
        }

        public override void Equip(HumanoidCreature player)
        {
            Wielder = player;
            player.RightHand.UnEquip();
            player.RightHand = this;
            EquipedHand = "right hand";

            Console.WriteLine($"{Name} was equiped on {Wielder.Name} {EquipedHand}");
        }

        public override void UnEquip()
        {
            Wielder.RightHand = null;
            EquipedHand = null;
            Console.WriteLine($"{Name} was unequiped on {Wielder.Name} {EquipedHand}");
        }
    }
}
