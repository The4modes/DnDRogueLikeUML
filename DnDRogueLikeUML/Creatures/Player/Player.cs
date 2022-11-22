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

        private List<IUsableItem> usableItemsList = new List<IUsableItem>();
        private List<IStackableItem> stackableItemsList = new List<IStackableItem>();
        private List<IWieldableItem> wieldableItemsList = new List<IWieldableItem>();
        private List<IAction> actionList = new List<IAction>();
        private List<IAction> bonusActionList = new List<IAction>();

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
        public List<IAction> BonusActionList
        {
            get { return bonusActionList; }
            set { bonusActionList= value; }
        }

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
                    new Melee().Equip(this);
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
                    new Melee().Equip(this);
                }
            }
        }

        public static Player GenerateClass()
        {
            Console.WriteLine("Choose class:");

            Console.WriteLine("Sike, you get a wizard");
            return new Wizard();
        }

        public void EquipItem()
        {
            string[] wieldableItemNames = new string[WieldableItemsList.Count];

            for (int i = 0; i < WieldableItemsList.Count; i++)
            {
                wieldableItemNames[i] = WieldableItemsList[i].Name;
            }

            string choice = ConsoleHandler.SingleSelect(wieldableItemNames, "What item do you want to equip?");

            for (int i = 0; i < WieldableItemsList.Count; i++)
            {
                if (wieldableItemNames[i] == wieldableItemsList[i].Name)
                {
                    wieldableItemsList[i].Equip(this);
                }
            }
        }

        public void DoAction()
        {
            List<IAction> availableActions = GenerateAvailableActions();
            string[] choices = new string[availableActions.Count];

            for (int i = 0; i < availableActions.Count; i++)
            {
                choices[i] = availableActions[i].Name;
            }

            string choice = ConsoleHandler.SingleSelect(choices, "What action do you want to use?");

            foreach (IAction action in availableActions)
            {
                if (action.Name == choice)
                {
                    action.DoAction(new List<ICreature>() { this });
                }
            }
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
