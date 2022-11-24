using System;
using System.Collections.Generic;
using DnDRogueLikeUML.Action;
using DnDRogueLikeUML.Creatures.Enemies;
using DnDRogueLikeUML.Items.WieldableItems;

namespace DnDRogueLikeUML.Creatures.Player
{
    class Bandit : HumanoidCreature, IEnemy, IClonableCreature
    {
        public override int Health { get; set; }
        public double ChallengeRating { get; set; }
        public List<Type> SpawnLocations { get; set; } = new List<Type>() { typeof(Forest), typeof(Desert) };

        public Bandit()
        {
            Random random = new Random();
            Health = random.Next(1, 9) + random.Next(1, 9) + 2;

            new Scimitar().Equip(this);
            CurrentLocation = typeof(Battle);

            ChallengeRating = 1d / 8d;
            XP = 150;
            Name = "Bandit";
        }

        private Bandit(int num) : this()
        {
            Name += num;

            CurrentLocation = typeof(Battle);
        }

        public IEnemy Clone(int num)
        {
            return new Bandit(num);
        }
    }
}
