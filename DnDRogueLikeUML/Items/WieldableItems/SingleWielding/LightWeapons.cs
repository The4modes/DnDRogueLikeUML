using System;
using DnDRogueLikeUML.Creatures;
using DnDRogueLikeUML.Creatures.Enemies;
using DnDRogueLikeUML.Creatures.Player;

namespace DnDRogueLikeUML.Items.WieldableItems
{
    abstract class LightWeapons : MeleeWeapon
    {
        public override void Equip(HumanoidCreature creature)
        {
            Wielder =  creature;

            if (creature is IEnemy)
            {
                Wielder.ActionList.Add(this);
                Wielder.RightHand.UnEquip();
                Wielder.RightHand = this;
                equippedHand = "Right";
            }
            else
            {
                string handToEquip = ConsoleHandler.SingleSelect(new string[]
                { "Right Hand - Main Action", "Left Hand - Bonus Action" }
                , $"What hand do you want to equip the {Name} on?");

                if (handToEquip == "Right Hand - Main Action")
                {
                    Wielder.RightHand.UnEquip();
                    Wielder.ActionList.Add(this);
                    Wielder.RightHand = this;
                    equippedHand = "Right";
                }
                else if (handToEquip == "Left Hand - Bonus Action")
                {
                    Wielder.LeftHand.UnEquip();
                    Wielder.BonusActionList.Add(this);
                    Wielder.LeftHand = this;
                    equippedHand = "Left";
                }

                creature.WieldableItemsList.Remove(this);
                Console.WriteLine($"{Name} was equiped on {creature.Name}");
            }
        }

        public override void UnEquip()
        {
            if(equippedHand == "Right")
            {
                Wielder.ActionList.Remove(this);
                Wielder.RightHand = null;
                new Fist().Equip(Wielder);
            }
            else if(equippedHand == "Left")
            {
                Wielder.BonusActionList.Remove(this);
                Wielder.LeftHand = null;
                new Fist().Equip(Wielder);
            }
            
            Console.WriteLine($"{Name} was unequiped from {Wielder.Name}");

            Wielder.WieldableItemsList.Add(this);
            Wielder = null;
        }
    }
}
