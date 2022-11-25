using DnDRogueLikeUML.Creatures;
using System;

namespace DnDRogueLikeUML.Modifiers
{
    class Poison : ITurnModifier
    {
        public int Turns { get; set; } = 2;
        public string Name { get; set; } = "Poison";
        public ICreature AppliedCreature { get; private set; }
        private int TurnDamage { get; set; } = 3;

        public Poison()
        {

        }

        public Poison(ICreature target)
        {
            ITurnModifier modifier = ModifierManager.Contains(target, this);

            if (modifier != null)
            {
                modifier.Turns += this.Turns;
                Console.WriteLine($"{Name} has been applied to {modifier.AppliedCreature.Name}");
            }
            else
            {
                AppliedCreature = target;
                Console.WriteLine($"{Name} has been applied to {AppliedCreature.Name}");
            }
        }

        public static void Apply(ICreature creature)
        {
            creature.TurnModifiers.Add(new Poison(creature));
        }

        public void Turn()
        {
            AppliedCreature.Health -= TurnDamage;
            Console.WriteLine($"{AppliedCreature.Name} took {TurnDamage} from {Name}");
            Turns--;
        }
    }
}
