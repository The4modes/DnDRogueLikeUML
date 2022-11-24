using System;
using System.Collections.Generic;
using DnDRogueLikeUML.Action;
using DnDRogueLikeUML.Items.WieldableItems;
using DnDRogueLikeUML.Items.UsableItems;
using DnDRogueLikeUML.Creatures.Enemies;

namespace DnDRogueLikeUML.Creatures.Player
{
    class Orc : HumanoidCreature, IEnemy, IClonableCreature
    {
        public override int Health { get; set; }
        public double ChallengeRating { get; set; }
        public List<Type> SpawnLocations { get; set; } = new List<Type>() { typeof(Forest) , typeof(Desert)};

        public Orc()
        {
            Random random = new Random();
            Health = random.Next(1, 9) + random.Next(1, 9) + 4;

            new GreatAxe().Equip(this);
            CurrentLocation = typeof(Battle);

            ChallengeRating = 0.5d;
            XP = 200;
            Name = "Orc";
        }

        private Orc(int num) : this()
        {
            Name += num;

            CurrentLocation = typeof(Battle);
        }

        public IEnemy Clone(int num)
        {
            return new Orc(num);
        }

    }
}
