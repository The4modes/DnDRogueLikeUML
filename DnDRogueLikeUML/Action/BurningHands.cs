using DnDRogueLikeUML.Creatures;
using System.Collections.Generic;
using System;

namespace DnDRogueLikeUML.Action
{
    class BurningHands : MultiTargetDamageSpell
    {
        protected override int MaxTargets { get; set; }

        public BurningHands(ICreature creature)
        {
            User = creature;
            Name = "Burning Hands";
            AvailableLocations = new List<Type>();
            AvailableLocations.Add(typeof(Battle));
            DamageDie = 8;
            MaxTargets = 3;
        }
    }
}
