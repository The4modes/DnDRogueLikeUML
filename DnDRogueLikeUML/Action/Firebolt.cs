using DnDRogueLikeUML.Creatures;
using System.Collections.Generic;
using System;
using DnDRogueLikeUML.Creatures.Player;
using System.Xml.Linq;

namespace DnDRogueLikeUML.Action
{
    class Firebolt : SingleTargetDamageSpell
    {
        public Firebolt(ICreature creature)
        {
            User = creature;
            Name = "Firebolt";
            AvailableLocations = new List<Type>();
            AvailableLocations.Add(typeof(Battle));
            DamageDie = 8;
        }
    }
}
