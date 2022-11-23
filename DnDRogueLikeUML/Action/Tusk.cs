using System;
using System.Collections.Generic;
using DnDRogueLikeUML.Action;

namespace DnDRogueLikeUML.Creatures.Enemies
{
    class Tusk : IAction
    {
        public int DamageDie { get; set; }
        public string Name { get; set; }
        public string Type { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public ICreature User { get; set; }
        public List<Type> AvailableLocations { get; set; } = new List<Type>();

        public Tusk(ICreature creature)
        {
            Name = "Tusk";
            AvailableLocations = new List<Type>() { typeof(Battle) };
            User = creature;
            DamageDie = 6;
        }

        public void DoAction(List<ICreature> targets)
        {
            Random random = new Random();
            int damage = random.Next(1, DamageDie);
            Console.WriteLine($"The {User.Name} uses the move {Name} and deals {damage}");

            targets[random.Next(0, targets.Count)].Health -= damage;
        }
    }
}
