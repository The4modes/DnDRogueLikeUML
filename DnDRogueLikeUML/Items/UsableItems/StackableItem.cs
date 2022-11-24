using DnDRogueLikeUML.Creatures;
using DnDRogueLikeUML.Creatures.Player;

namespace DnDRogueLikeUML.Items.UsableItems
{
    abstract class StackableItem : IStackableItem
    {
        public int ItemStack { get; set; }
        public string Name { get; set; }
        public string Rarity { get; set; }
        public string Description { get; set; }

        public virtual void AddToInventory(HumanoidCreature creature)
        {
            if(!ItemManager.InventoryContains(creature, this))
            {
                creature.StackableItemsList.Add(this);
            }
            else
            {
                ItemManager.AddToStackInventory(creature, this);
            }

        }

        public void AddToStack(int amount)
        {
            ItemStack += amount;
        }
    }
}
