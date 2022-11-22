using DnDRogueLikeUML.Items.UsableItems;
using DnDRogueLikeUML.Items.WieldableItems;
using DnDRogueLikeUML.Items;
using System;
using System.Collections.Generic;
using DnDRogueLikeUML.Action;

namespace DnDRogueLikeUML.Creatures.Enemies
{
    abstract class Enemy : ICreature
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
        public List<IAction> ActionList { get; set; }

        public void DoAction()
        {
            throw new NotImplementedException();
        }

        public List<IAction> GenerateAvailableActions()
        {
            throw new NotImplementedException();
        }
    }
}
