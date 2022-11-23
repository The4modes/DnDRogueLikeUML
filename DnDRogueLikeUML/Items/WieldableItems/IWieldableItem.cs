using DnDRogueLikeUML.Creatures.Player;
using System.Numerics;

namespace DnDRogueLikeUML.Items.WieldableItems
{
    interface IWieldableItem : IItem
    {
        public HumanoidCreature Wielder { get; set; }

        public void Equip(HumanoidCreature player);

        public void UnEquip();
    }
}
