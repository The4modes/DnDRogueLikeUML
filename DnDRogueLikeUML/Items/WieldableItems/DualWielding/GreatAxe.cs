using System;
using DnDRogueLikeUML.Creatures;
using DnDRogueLikeUML.Creatures.Player;
using System.Collections.Generic;
using DnDRogueLikeUML.Action;
using DnDRogueLikeUML.Creatures.Enemies;

namespace DnDRogueLikeUML.Items.WieldableItems
{
    class GreatAxe : GreatWeapons
    {
        public GreatAxe()
        {
            Name = "GreatAxe";
            AvailableLocations = new List<Type>() { typeof(Battle) };
            DamageDie = 12;
        }

        public override void DoAction(List<ICreature> targets)
        {
            Random random = new Random();

            if (targets[0] is Player)
            {
                int damage = random.Next(1, DamageDie + 1);
                Console.WriteLine($"The {Wielder.Name} uses the move {Name} and deals {damage}");
                targets[0].Health -= damage;
            }

            else
            {
                string[] targetNames = new string[targets.Count];

                for (int i = 0; i < targets.Count; i++)
                {
                    targetNames[i] = targets[i].Name;
                }

                string targetChoice = ConsoleHandler.SingleSelect(targetNames, "What creature do you want to hit?");

                for (int i = 0; i < targetNames.Length; i++)
                {
                    if (targetNames[i] == targetChoice)
                    {
                        int damage = random.Next(1, DamageDie + 1);
                        targets[i].Health -= damage;

                        Console.WriteLine($"{Wielder.Name} swing its GreatAxe at {targets[i].Name} for {damage} damage!");
                    }
                }

            }
        }

        public IAction Clone()
        {
            return new GreatAxe();
        }
    }
}
