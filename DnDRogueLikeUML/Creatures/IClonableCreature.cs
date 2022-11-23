using System;
using System.Collections.Generic;
using DnDRogueLikeUML.Creatures.Enemies;

namespace DnDRogueLikeUML
{
    interface IClonableCreature
    {
        public string Name { get; set; }
        public double ChallengeRating { get; set; }
        public List<Type> SpawnLocations { get; set; }

        public IEnemy Clone(int numCount);
    }
}
