using System;
using System.Collections.Generic;
using DnDRogueLikeUML.Action;
using DnDRogueLikeUML.Creatures;

namespace DnDRogueLikeUML.Items.UsableItems
{

    class PotionOfHealing : StackableUsableItem
    {
        public override bool IsMagical { get; set; } = false;
        private ICreature Wielder { get; set; }

        public PotionOfHealing()
        {
            Name = "Potion of Healing";
            Rarity = "Common";
            ItemStack = 1;
            AvailableLocations = new List<Type>() { typeof(Forest), typeof(Battle), typeof(Desert) };
        }

        public PotionOfHealing(ICreature creature) : this()
        {
            Wielder = creature;
        }

        public override void DoAction(List<ICreature> creature)
        {
            Random random = new Random();

            int healing = random.Next(1, 5) + random.Next(1, 5) + 2;
            Wielder.Health += healing;

            Console.WriteLine($"{Wielder.Name} used a {Name} and healed {healing} health.");

            ItemStack -= 1;

            if (ItemStack == 0)
            {
                Wielder.UsableItemsList.Remove(this);
                Wielder.StackableItemsList.Remove(this);
                Wielder.ActionList.Remove(this); // vill lägga in så action list listar ut ifall potion finns i inventory
            }
        }

        public IAction Clone()
        {
            return new PotionOfHealing();
        }
    }
}
