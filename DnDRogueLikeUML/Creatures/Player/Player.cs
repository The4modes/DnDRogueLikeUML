using System;
using System.Collections.Generic;
using System.Reflection;
using DnDRogueLikeUML.Action;
using DnDRogueLikeUML.Items.UsableItems;
using DnDRogueLikeUML.Items;
using System.Linq;
using System.Numerics;

namespace DnDRogueLikeUML.Creatures.Player
{
    abstract class Player : HumanoidCreature
    {
        
        public string[] DisplayableStats { get; set; }

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
            string[] choices = new string[availableActions.Count + 1];

            for (int i = 0; i < availableActions.Count; i++)
            {
                choices[i] = availableActions[i].Name;
            }

            choices[choices.Length - 1] = "Skip action";

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

        protected string[] ChooseRolledStats()
        {
            List<int> roll1 = GenerateStats();
            List<int> roll2 = GenerateStats();
            string[] roll1String = new string[roll1.Count + 1];
            string[] roll2String = new string[roll2.Count + 1];
            roll1String[0] = "";
            roll2String[0] = "";

            for (int i = 0; i < roll1String.Length - 1; i++)
            {
                roll1String[i + 1] = roll1[i].ToString();
                roll2String[i + 1] = roll2[i].ToString();
            }
            Console.WriteLine("Roll 1:");
            ConsoleHandler.DisplayStats(roll1String);

            Console.WriteLine();

            Console.WriteLine("Roll 2");
            ConsoleHandler.DisplayStats(roll2String);

            string choice = ConsoleHandler.SingleSelect(new string[] { "[grey]Roll 1[/]", "[grey]Roll 2[/]", }, "Which stats do you want to use?");

            switch (choice)
            {
                case "[grey]Roll 1[/]":
                    ApplyStats(roll1);
                    return roll1String;
                case "[grey]Roll 2[/]":
                    ApplyStats(roll2);
                    return roll2String;
                default:
                    throw new NotImplementedException("No choice was made... somehow");
            }
        }

        private void ApplyStats(List<int> stats)
        {
            Strenght = stats[0];
            Dexterity = stats[1];
            Constitution = stats[2];
            Intelligence = stats[3];
            Wisdom = stats[4];
            Charisma = stats[5];
        }

        private List<int> GenerateStats()
        {
            List<int> rolledStats = new List<int>();

            Random random = new Random();

            for (int i = 0; i < 6; i++)
            {
                rolledStats.Add((from roll in Enumerable.Range(0, 4) select random.Next(1, 7)).OrderBy(x => x).ToList().GetRange(1, 3).Sum());
            }

            return rolledStats;
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

        protected virtual void LevelUp()
        {
            Random random = new Random();

            Level++;
            MaxHealth += random.Next(1, HitDie + 1);
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
