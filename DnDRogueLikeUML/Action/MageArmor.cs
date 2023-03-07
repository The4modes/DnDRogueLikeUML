using DnDRogueLikeUML.Creatures;
using System.Collections.Generic;
using System;

namespace DnDRogueLikeUML.Action
{
    class MageArmor : ISpell
    {
        public int LevelRequirement { get; private set; } = 2;
        public string ActionType { get; private set; } = "Ritual";
        public string Name { get; private set; } = "Mage Armor";
        public string Type { get; private set; } = "Buff";
        public ICreature User { get; private set; }
        public bool IsMagical { get; private set; } = true;
        public List<Type> AvailableLocations { get; set; } = new List<Type>();

        public MageArmor(ICreature creature)
        {
            AvailableLocations.Add(typeof(Forest));
            AvailableLocations.Add(typeof(Desert));

            User = creature;
        }

        public void DoAction(List<ICreature> targets)
        {
            string[] targetNames = new string[targets.Count];

            for (int i = 0; i < targets.Count; i++)
            {
                targetNames[i] = targets[i].Name;
            }

            string choice = ConsoleHandler.SingleSelect(targetNames, $"Who do you want to cast {Name} on?");

            foreach (ICreature creature in targets)
            {
                if (creature.Name == choice)
                {
                    User.ArmorClass = 13 + User.DexMod;
                    Console.WriteLine($"{User.Name} new AC is {User.ArmorClass}.");
                }
            }
        }
    }
}
