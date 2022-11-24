using System;
using DnDRogueLikeUML.Action;
using DnDRogueLikeUML.Creatures;
using DnDRogueLikeUML.Creatures.Player;
using DnDRogueLikeUML.Items.UsableItems;
using DnDRogueLikeUML.Items.WieldableItems;
using System.Collections.Generic;

namespace DnDRogueLikeUML.Items
{
    class ItemManager
    {
        public static List<IItem> items = new List<IItem>() { new PotionOfHealing() };

        public static void AddItemToInventory(HumanoidCreature creature, IItem item)
        {
            item.AddToInventory(creature);
        }

        public static bool InventoryContains(HumanoidCreature creature, IItem item)
        {
            List<IItem> itemNames = Inventory(creature);

            foreach (IItem itemInInventory in itemNames)
            {
                if (itemInInventory.Name == item.Name)
                {
                    return true;
                }
            }

            return false;
        }

        public static void AddToStackInventory(HumanoidCreature creature, IStackableItem item)
        {
            foreach (var itemInInventory in creature.StackableItemsList)
            {
                if(itemInInventory.Name == item.Name)
                {
                    itemInInventory.AddToStack(1);
                }
            }
        }

        public static List<IItem> Inventory(HumanoidCreature creature)
        {
            List<IItem> inventory = new List<IItem>();

            foreach (IItem item in creature.UsableItemsList)
            {
                if (!inventory.Contains(item))
                {
                    inventory.Add(item);
                }
            }
            foreach (IItem item in creature.StackableItemsList)
            {
                if (!inventory.Contains(item))
                {
                    inventory.Add(item);
                }
            }
            foreach (IItem item in creature.WieldableItemsList)
            {
                if (!inventory.Contains(item))
                {
                    inventory.Add(item);
                }
            }

            return inventory;
        }


    }
}

