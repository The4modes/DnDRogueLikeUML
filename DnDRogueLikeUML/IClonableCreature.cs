using System;
using System.Collections.Generic;

namespace DnDRogueLikeUML
{
    interface IClonableCreature
    {
        public string Name { get; set; }
        public double ChallengeRating { get; set; }
        public List<Type> SpawnLocation { get; set; }

        public Enemy Clone(int numCount);
    }
}
