using System;
using System.Collections.Generic;
using DnDRogueLikeUML.Action;
using DnDRogueLikeUML.Creatures;
using DnDRogueLikeUML.Creatures.Player;

namespace DnDRogueLikeUML.Items.UsableItems
{
    abstract class StackableUsableItem : StackableItem, IAction
    {
        public string Type { get; set; }
        public ICreature User { get; set; }
        abstract public bool IsMagical { get; set; }
        public List<Type> AvailableLocations { get; set; }

        abstract public void DoAction(List<ICreature> targets);

        public override void AddToInventory(HumanoidCreature creature)
        {
            if (!ItemManager.InventoryContains(creature, this))
            {
                creature.UsableItemsList.Add(this);
                creature.StackableItemsList.Add(this);
                creature.ActionList.Add(this);
            }
            else
            {
                ItemManager.AddToStackInventory(creature, this);
            }
        }

    }
}
