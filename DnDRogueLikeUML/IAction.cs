using System;
using System.Collections.Generic;

namespace DnDRogueLikeUML
{
    interface IAction
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public ICreature User { get; set; }
        public List<Type> AvailableLocations{ get; set; }

        public void DoAction(List<ICreature> targets);
    }
}
