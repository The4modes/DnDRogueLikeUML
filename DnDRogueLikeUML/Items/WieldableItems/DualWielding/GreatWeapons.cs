using System;
using DnDRogueLikeUML.Creatures;
using DnDRogueLikeUML.Items.UsableItems;
using DnDRogueLikeUML.Creatures.Player;
using DnDRogueLikeUML.Creatures.Enemies;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Numerics;

namespace DnDRogueLikeUML.Items.WieldableItems
{
    abstract class GreatWeapons : MeleeWeapon
    {
        public override void Equip(HumanoidCreature creature)
        {
            Wielder = creature;
            Wielder.ActionList.Add(this);

            creature.RightHand.UnEquip();
            creature.LeftHand.UnEquip();
            creature.RightHand = this;
            creature.LeftHand = this;
            

            if (!(creature is IEnemy))
            {
                creature.WieldableItemsList.Remove(this);
                Console.WriteLine($"{Name} was equiped on {creature.Name}");
            }
            
        }

        public override void UnEquip()
        {
            Wielder.ActionList.Remove(this);

            Wielder.RightHand = null;
            Wielder.LeftHand = null;
            Console.WriteLine($"{Name} was unequiped from {Wielder.Name}");
            Wielder.WieldableItemsList.Add(this);
            Wielder = null;
        }
    }
}
