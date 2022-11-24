using System;
using System.Collections.Generic;
using System.Reflection;
using DnDRogueLikeUML.Action;
using DnDRogueLikeUML.Items.UsableItems;
using DnDRogueLikeUML.Items;

namespace DnDRogueLikeUML.Creatures.Player
{
    abstract class Player : HumanoidCreature
    {
        private int health;
        private int maxHealth;
        private int xp = 0;

        public override int Health
        {
            get
            {
                return health;
            }
            set
            {
                if (value <= MaxHealth)
                {
                    health = value;
                }
                else
                {
                    health = MaxHealth;
                }

                if (health <= 0)
                {
                    Environment.Exit(0);
                }

            }
        }

        public override int XP
        {
            get
            {
                return xp;
            }
            set
            {
                xp = value;
                if (levelThresholds.Count > 0)
                {
                    LevelUpCheck();
                }
            }
        }

        private List<int> levelThresholds = new List<int>() { 300, 900, 2700, 6500, 14000, 23000 };

        protected Player()
        {
            Level = 1;
            ItemManager.AddItemToInventory(this, new PotionOfHealing(this));
        }

        public override void DoAction(List<ICreature> creatures)
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
                    action.DoAction(creatures);
                }
            }
        }

        public void ChooseEquipment()
        {
            string[] wieldableItemNames = new string[WieldableItemsList.Count];

            for (int i = 0; i < WieldableItemsList.Count; i++)
            {
                wieldableItemNames[i] = WieldableItemsList[i].Name;
            }

            string choice = ConsoleHandler.SingleSelect(wieldableItemNames, "What item do you want to equip?");

            for (int i = 0; i < WieldableItemsList.Count; i++)
            {
                if (wieldableItemNames[i] == WieldableItemsList[i].Name)
                {
                    WieldableItemsList[i].Equip(this);
                }
            }
        }

        public static Player GenerateClass()
        {
            string classChoice = ConsoleHandler.SingleSelect(new[]
            { "[grey]Wizard[/]", "[grey]Barbarian[/]", "[grey]Commoner[/]" },
                "What class do you want to play?");

            switch (classChoice)
            {
                case "[grey]Wizard[/]":
                    return new Wizard();
                case "[grey]Barbarian[/]":
                    return new Barbarian();
                default:
                    return new Commoner();
            }
        }

        private void LevelUp()
        {
            Random random = new Random();

            Level++;
            int roll = random.Next(1, HitDie + 1);
            MaxHealth += roll;
            Health = MaxHealth;
            Console.WriteLine($"{Name} just leveled up to level: {Level}");
            Console.WriteLine($"{Name} new max health is: {MaxHealth}\nHealth has also been restored.");

        }

        private void LevelUpCheck()
        {
            Console.WriteLine(XP);
            if (XP >= levelThresholds[0])
            {
                LevelUp();
                levelThresholds.RemoveAt(0);
            }
        }
    }
}
