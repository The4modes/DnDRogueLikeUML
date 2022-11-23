using DnDRogueLikeUML.Creatures;
using DnDRogueLikeUML.Creatures.Player;
using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace DnDRogueLikeUML.Items.WieldableItems
{
    class Fist : MeleeWeapon
    {
        public Fist()
        {
            AvailableLocations = new List<Type>() { typeof(Battle) };
            DamageDie = 4;
        }

        public override void DoAction(List<ICreature> targets)
        {
            Console.WriteLine("Slapidislap");
            throw new NotImplementedException();
        }

        public override void Equip(HumanoidCreature creature)
        {
            Wielder = creature;
            
            if (creature.RightHand == null)
            {
                Name = "Right Hand";
                Wielder.ActionList.Add(this);
                creature.RightHand = this;
                equippedHand = "Right";
            }
            else if (creature.LeftHand == null)
            {
                Name = "Left Hand";
                Wielder.BonusActionList.Add(this);
                creature.LeftHand = this;
                equippedHand = "Left";
            }
            
        }

        public override void UnEquip()
        {
            switch (equippedHand)
            {
                case "Right":
                    Wielder.ActionList.Remove(this);
                    break;
                case "Left":
                    Wielder.BonusActionList.Remove(this);
                    break;
                default:
                    throw new NotImplementedException("Something went wrong with unequiping Hands");
            }
        }
    }
}
