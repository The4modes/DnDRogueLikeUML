using System;
using System.Collections.Generic;
using System.Xml.Linq;
using DnDRogueLikeUML.Action;
using DnDRogueLikeUML.Creatures.Enemies;
using DnDRogueLikeUML.Items.WieldableItems;

namespace DnDRogueLikeUML.Creatures.Player
{
    class Boar : Creature, IEnemy, IClonableCreature
    {

        public override int Health { get; set; }
        public double ChallengeRating { get; set; }
        public List<Type> SpawnLocations { get; set; } = new List<Type>() { typeof(Forest)};

        public Boar()
        {
            Random random = new Random();
            Health = random.Next(1, 9) + random.Next(1, 9) + 4;
            ActionList = new List<IAction>() { new Tusk(this) };
            CurrentLocation = typeof(Battle);
            ChallengeRating = 0.25d;
            XP = 300;
            Name = "Boar";
        }

        public Boar(int num) : this()
        {
            Name += num;
        }

        public IEnemy Clone(int num)
        {
            return new Boar(num);
        }
    }
}
