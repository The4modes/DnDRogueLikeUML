using DnDRogueLikeUML.Creatures;
using System.Collections.Generic;
using System;

namespace DnDRogueLikeUML.Action
{
    abstract class MultiTargetDamageSpell : ISpell
    {
        protected int DamageDie { get; set; }
        public int LevelRequirement { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Name { get; set; }
        public string Type { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool IsMagical { get; set; } = true;
        public ICreature User { get; set; }
        public List<Type> AvailableLocations { get; set; } = new List<Type>();

        abstract protected int MaxTargets { get; set; }

        public virtual void DoAction(List<ICreature> targets)
        {
            Random random = new Random();

            string[] targetNames = new string[targets.Count];

            for (int i = 0; i < targets.Count; i++)
            {
                targetNames[i] = targets[i].Name;
            }

            List<string> targetChoice = new List<string>();

            while (targetChoice.Count <= 0 || targetChoice.Count > MaxTargets)
            {
                targetChoice = ConsoleHandler.MultiSelect(targetNames, $"What creatures do you want to target with [red]{Name}[/]?\nYou can choose up to 3 creatures.");
            }

            int bonus = 0;

            if (User.IntMod > 0)
            {
                bonus = User.IntMod;
            }

            int damage = random.Next(1, DamageDie + 1) + bonus;

            for (int j = 0; j < targetChoice.Count; j++)
            {
                for (int i = 0; i < targetNames.Length; i++)
                {
                    if (targetNames[i] == targetChoice[j])
                    {
                        targets[i].Health -= damage;

                        Console.WriteLine($"You shot {Name} and hit {targetNames[i]} for {damage} damage");
                    }
                }
            }

        }
    }
}
