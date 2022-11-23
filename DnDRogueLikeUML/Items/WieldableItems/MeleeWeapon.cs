using DnDRogueLikeUML.Action;
using DnDRogueLikeUML.Creatures;
using System.Collections.Generic;

namespace DnDRogueLikeUML.Items.WieldableItems
{
    abstract class MeleeWeapon : MeleeItem, IAction
    {
        protected int DamageDie { get; set; }

        public abstract void DoAction(List<ICreature> targets);
    }
}
