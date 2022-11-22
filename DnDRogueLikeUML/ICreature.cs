using System;
using System.Collections.Generic;

namespace DnDRogueLikeUML
{
    interface ICreature
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int MaxHealth { get; set; }
        public int HitDie { get; set; }
        public int Level { get; set; }
        public int XP { get; set; }
        public int ArmorClass { get; set; }

        public int Strenght { get; set; }
        public int Dexterity { get; set; }
        public int Constitution { get; set; }
        public int Intelligence { get; set; }
        public int Wisdom { get; set; }
        public int Charisma { get; set; }

        public Type CurrentLocation { get; set; }

        public List<IUsableItem> UsableItemsList { get; set; }

        public List<IStackableItem> StackableItemsList { get; set; }
        public List<IWieldableItem> WieldableItemsList { get; set; }

        public IWieldableItem RightHand { get; set; }
        public IWieldableItem LeftHand { get; set; }

        public void DoAction();

        public List<IAction> GenerateAvailableActions();

    }
}
