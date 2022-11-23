using System;
using System.Collections.Generic;
using System.Xml.Linq;
using DnDRogueLikeUML.Action;
using DnDRogueLikeUML.Items;
using DnDRogueLikeUML.Items.UsableItems;

namespace DnDRogueLikeUML.Creatures.Player
{

    abstract class Creature : ICreature
    {
        public string Name { get; set; }
        public virtual int Health { get; set; }
        public int MaxHealth { get; set; }
        public int HitDie { get; set; }
        public int Level { get; set; }
        public virtual int XP { get; set; }
        public int ArmorClass { get; set; }

        public int Strenght { get; set; }
        public int Dexterity { get; set; }
        public int Constitution { get; set; }
        public int Intelligence { get; set; }
        public int Wisdom { get; set; }
        public int Charisma { get; set; }

        public Type CurrentLocation { get; set; }

        public List<IUsableItem> UsableItemsList { get; set; } = new List<IUsableItem>();
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
