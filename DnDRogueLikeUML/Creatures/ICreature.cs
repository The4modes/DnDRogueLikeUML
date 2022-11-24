using System;
using System.Collections.Generic;
using DnDRogueLikeUML.Action;
using DnDRogueLikeUML.Items;
using DnDRogueLikeUML.Items.UsableItems;
using DnDRogueLikeUML.Items.WieldableItems;

namespace DnDRogueLikeUML.Creatures
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

        public List<IAction> UsableItemsList { get; set; }

        public List<IStackableItem> StackableItemsList { get; set; }

        public List<IAction> ActionList { get; set; }

        public List<IAction> BonusActionList { get; set; }

        public void DoAction(List<ICreature> creatures);

        public List<IAction> GenerateAvailableActions();

    }
}
