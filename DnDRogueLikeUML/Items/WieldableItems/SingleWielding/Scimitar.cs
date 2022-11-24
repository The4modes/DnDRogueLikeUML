using DnDRogueLikeUML.Action;
using DnDRogueLikeUML.Creatures.Enemies;
using DnDRogueLikeUML.Creatures;
using DnDRogueLikeUML.Creatures.Player;
using System;
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;

namespace DnDRogueLikeUML.Items.WieldableItems
{
    class Scimitar : LightWeapons
    {
        public Scimitar()
        {
            Name = "Scimitar";
            AvailableLocations = new List<Type>() { typeof(Battle) };
            DamageDie = 6;
        }

        public override void DoAction(List<ICreature> targets)
        {
            Random random = new Random();

            int bonus = 0;

            if (Wielder.StrMod >= Wielder.DexMod)
            {
                if (Wielder.StrMod > 0)
                {
                    bonus = Wielder.StrMod;
                }
            }
            else
            {
                if (Wielder.DexMod > 0)
                {
                    bonus = Wielder.DexMod;
                }
            }

            if (targets[0] is Player)
            {
                int damage;

                damage = random.Next(1, DamageDie + 1) + bonus;

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
                        int damage = random.Next(1, DamageDie + 1) + bonus;
                        targets[i].Health -= damage;

                        Console.WriteLine($"{Wielder.Name} stabs at {targets[i].Name} with a {Name} for {damage} damage!");
                    }
                }

            }
        }


        public IAction Clone()
        {
            return new Scimitar();
        }
    }
}
