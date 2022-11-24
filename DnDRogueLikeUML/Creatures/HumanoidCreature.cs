using System.Collections.Generic;
using DnDRogueLikeUML.Items.WieldableItems;

namespace DnDRogueLikeUML.Creatures.Player
{
    abstract class HumanoidCreature : Creature
    {
        private IWieldableItem rightHand;
        private IWieldableItem leftHand;

        public IWieldableItem RightHand
        {
            get
            {
                return rightHand;
            }
            set
            {
                if(RightHand is Fist && value.GetType() != typeof(Fist))
                {
                    RightHand.UnEquip();
                }
                rightHand = value;
            }
        }
        public IWieldableItem LeftHand
        {
            get
            {
                return leftHand;
            }
            set
            {
                if (LeftHand is Fist && value.GetType() != typeof(Fist))
                {
                    LeftHand.UnEquip();
                }
                leftHand = value;
            }
        }

        public List<IWieldableItem> WieldableItemsList { get; set; } = new List<IWieldableItem>();

        public HumanoidCreature()
        {
            // Equipes both hands so they are never empty
            new Fist().Equip(this);
            new Fist().Equip(this);
        }
    }
}
