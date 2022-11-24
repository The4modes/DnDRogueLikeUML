using DnDRogueLikeUML.Creatures;
using System.Collections.Generic;
using System;
using System.Linq;

namespace DnDRogueLikeUML.Action
{
    class Fireball : SingleTargetDamageSpell
    {
        public Fireball(ICreature creature)
        {
            User = creature;
            Name = "Fireball";
            AvailableLocations = new List<Type>();
            AvailableLocations.Add(typeof(Battle));
            DamageDie = 6;
        }

        public override void DoAction(List<ICreature> targets)
        {
            {
                Random random = new Random();

                string[] targetNames = new string[targets.Count];

                for (int i = 0; i < targets.Count; i++)
                {
                    targetNames[i] = targets[i].Name;
                }

                int bonus = 0;

                if (User.IntMod > 0)
                {
                    bonus = User.IntMod;
                }

                int damage = bonus;

                damage += (from roll in Enumerable.Range(0, 8) select random.Next(1, DamageDie + 1)).Sum();

                foreach (ICreature creature in targets)
                {
                    if (random.Next(1, 21) + creature.DexMod >= User.Intelligence)
                    {
                        Console.WriteLine($"{creature.Name} saved the DEX save and took {damage / 2} damage.");
                        creature.Health -= damage / 2;
                    }
                    else
                    {
                        Console.WriteLine($"{creature.Name} missed the DEX save and took {damage} damage!");
                        creature.Health -= damage;
                    }
                    
                }
            }
        }
    }
}
