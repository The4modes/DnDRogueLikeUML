using System;
using System.Collections.Generic;
using System.Reflection;
using DnDRogueLikeUML.Action;
using DnDRogueLikeUML.Items;
using DnDRogueLikeUML.Items.UsableItems;
using DnDRogueLikeUML.Items.WieldableItems;

namespace DnDRogueLikeUML.Creatures.Player
{
    abstract class Player : ICreature
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

        public List<IUsableItem> usableItemsList = new List<IUsableItem>();
        public List<IStackableItem> stackableItemsList = new List<IStackableItem>();
        public List<IWieldableItem> wieldableItemsList = new List<IWieldableItem>();
        public List<IAction> actionList = new List<IAction>();

        public List<IUsableItem> UsableItemsList 
        {
            get { return usableItemsList; }
            set { usableItemsList = value; }
        }  
        public List<IStackableItem> StackableItemsList
        {
            get{ return stackableItemsList; }
            set { stackableItemsList = value; }
        }
        public List<IWieldableItem> WieldableItemsList
        {
            get { return wieldableItemsList; }
            set { wieldableItemsList = value; }
        }
        public List<IAction> ActionList
        {
            get { return actionList; }
            set { actionList = value; }
        }

        public IWieldableItem RightHand 
        {
            get
            {
                return this.RightHand;
            }
            set
            {
                if (this.RightHand != null)
                {
                    this.RightHand.UnEquip();
                }

                this.RightHand = value;
            }
        }
        public IWieldableItem LeftHand 
        {
            get
            {
                return this.LeftHand;
            }
            set
            {
                if (this.LeftHand != null)
                {
                    this.LeftHand.UnEquip();
                }

                this.LeftHand = value;
            }
        }

        public static Player GenerateClass()
        {
            Console.WriteLine("Choose class:");

            Console.WriteLine("Sike, you get a wizard");
            return new Wizard();
        }

        public void DoAction()
        {
            GenerateAvailableActions()[0].DoAction(new List<ICreature>() { this});
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
