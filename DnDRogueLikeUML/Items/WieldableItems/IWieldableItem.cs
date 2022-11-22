using DnDRogueLikeUML.Creatures.Player;
using System.Numerics;

namespace DnDRogueLikeUML.Items.WieldableItems
{
    interface IWieldableItem : IItem
    {
        public Player Wielder { get; set; }

        public void Equip(Player player);

        public void UnEquip();
    }
}
