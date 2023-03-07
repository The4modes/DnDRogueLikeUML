using DnDRogueLikeUML.Creatures.Player;
using System;
using System.Collections.Generic;

namespace DnDRogueLikeUML
{
    class CreatureManager
    {
        private List<IClonableCreature> GetAllCreatures = new List<IClonableCreature>() { new Boar(), new Orc(), new Bandit() };

        public List<IClonableCreature> GetAvailableCreatures(Type location)
        {
            List<IClonableCreature> availableCreatures = new List<IClonableCreature>();

            foreach (IClonableCreature creature in GetAllCreatures)
            {
                if (creature.SpawnLocations.Contains(location))
                {
                    availableCreatures.Add(creature);
                }
            }

            return availableCreatures;
        }
    }
}
