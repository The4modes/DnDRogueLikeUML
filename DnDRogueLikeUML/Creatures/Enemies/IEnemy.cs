using DnDRogueLikeUML.Items.UsableItems;
using DnDRogueLikeUML.Items.WieldableItems;
using DnDRogueLikeUML.Items;
using System;
using System.Collections.Generic;
using DnDRogueLikeUML.Action;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DnDRogueLikeUML.Creatures.Enemies
{
    interface IEnemy : ICreature
    {
        public double ChallengeRating { get; set; }

        public List<Type> SpawnLocations { get; set; }
    }
    
}
