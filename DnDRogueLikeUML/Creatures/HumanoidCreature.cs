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
                rightHand = value;

                if (rightHand == null)
                {
                    new Fist().Equip(this);
                }
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
                leftHand = value;

                if (leftHand == null)
                {
                    new Fist().Equip(this);
                }
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
