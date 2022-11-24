using DnDRogueLikeUML.Action;
using DnDRogueLikeUML.Creatures;
using DnDRogueLikeUML.Creatures.Player;
using System.Collections.Generic;

namespace DnDRogueLikeUML.Items.WieldableItems
{
    abstract class MeleeWeapon : MeleeItem, IAction
    {
        public bool IsMagical { get; set; }
        protected int DamageDie { get; set; }

        public abstract void DoAction(List<ICreature> targets);

        public override void AddToInventory(HumanoidCreature creature)
        {
            base.AddToInventory(creature);
            creature.UsableItemsList.Add(this);
        }
    }
}
