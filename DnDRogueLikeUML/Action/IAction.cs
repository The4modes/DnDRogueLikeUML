using System;
using System.Collections.Generic;
using DnDRogueLikeUML.Creatures;

namespace DnDRogueLikeUML.Action
{
    interface IAction
    {
        public string Name { get; }
        public string Type { get; }
        public ICreature User { get; }
        public bool IsMagical { get; }
        public List<Type> AvailableLocations { get; }

        public void DoAction(List<ICreature> targets);
    }
}
