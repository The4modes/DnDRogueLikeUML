using DnDRogueLikeUML.Creatures;
using System.Collections.Generic;
using System;

namespace DnDRogueLikeUML.Action
{
    abstract class SingleTargetDamageSpell : ISpell
    {
        protected int DamageDie { get; set; }
        public int LevelRequirement { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Name { get; set; }
        public string Type { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool IsMagical { get; set; } = true;
        public ICreature User { get; set; }
        public List<Type> AvailableLocations { get; set; } = new List<Type>();

        public virtual void DoAction(List<ICreature> targets)
        {
            {
                Random random = new Random();

                string[] targetNames = new string[targets.Count];

                for (int i = 0; i < targets.Count; i++)
                {
                    targetNames[i] = targets[i].Name;
                }

                string targetChoice = ConsoleHandler.SingleSelect(targetNames, "What creature do you want to target with Firebolt?");

                for (int i = 0; i < targetNames.Length; i++)
                {
                    if (targetNames[i] == targetChoice)
                    {
                        int damage = 0;

                        for (int j = 0; j <= User.Level / 5; j++)
                        {
                            damage += random.Next(1, DamageDie + 1);
                        }

                        targets[i].Health -= damage;

                        Console.WriteLine($"You shot {Name} and hit {targetNames[i]} for {damage} damage");
                    }
                }

            }
        }
    }
}
