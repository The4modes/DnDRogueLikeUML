using System;
using System.Collections.Generic;
using System.Numerics;
using System.Xml.Linq;
using DnDRogueLikeUML.Action;
using DnDRogueLikeUML.Items;
using DnDRogueLikeUML.Items.UsableItems;

namespace DnDRogueLikeUML.Creatures.Player
{

    abstract class Creature : ICreature
    {
        protected int health;

        protected int xp = 0;

        protected int maxHealth;

        public string Name { get; set; }
        public virtual int Health { get; set; }
        public virtual int MaxHealth { get => maxHealth; set => maxHealth = ConMod + value; }
        public int HitDie { get; set; }
        public int Level { get; set; } = 1;
        public virtual int XP { get; set; }
        public int ArmorClass { get; set; } = 10;

        public int Strenght { get; set; } = 10;
        public int Dexterity { get; set; } = 10;
        public int Constitution { get; set; } = 10;
        public int Intelligence { get; set; } = 10;
        public int Wisdom { get; set; } = 10;
        public int Charisma { get; set; } = 10;

        public int StrMod { get => (int)Math.Floor((double)(Strenght - 10) / 2); }
        public int DexMod { get => (int)Math.Floor((double)(Dexterity - 10) / 2); }
        public int ConMod { get => (int)Math.Floor((double)(Constitution - 10) / 2); }
        public int IntMod { get => (int)Math.Floor((double)(Intelligence - 10) / 2); }
        public int WisMod { get => (int)Math.Floor((double)(Wisdom - 10) / 2); }
        public int ChaMod { get => (int)Math.Floor((double)(Charisma - 10) / 2); }

        public Type CurrentLocation { get; set; }

        public List<IAction> UsableItemsList { get; set; } = new List<IAction>();
        public List<IStackableItem> StackableItemsList { get; set; } = new List<IStackableItem>();

        public List<IAction> ActionList { get; set; } = new List<IAction>();
        public List<IAction> BonusActionList { get; set; } = new List<IAction>();

        public virtual void DoAction(List<ICreature> creatures)
        {
            Random random = new Random();

            List<IAction> availableActions = GenerateAvailableActions();

            availableActions[random.Next(0, availableActions.Count)].DoAction(creatures);
        }

        public List<IAction> GenerateAvailableActions()
        {
            List<IAction> actions = new List<IAction>();

            foreach (IAction action in ActionList)
            {
                if (action.AvailableLocations.Contains(CurrentLocation))
                {
                    actions.Add(action);
                }
            }
            return actions;
        }
    }
}
