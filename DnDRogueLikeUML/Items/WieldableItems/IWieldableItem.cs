using System;
using DnDRogueLikeUML.Creatures;

namespace DnDRogueLikeUML.Items.WieldableItems
{
    interface IWieldableItem : IItem
    {
        public ICreature Wielder { get; set; }

        public void Equip(ICreature creature);

        public void UnEquip();

        public IWieldableItem Clone();
    }
}
