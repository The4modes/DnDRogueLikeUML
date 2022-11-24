using System.Collections.Generic;
using DnDRogueLikeUML.Action;
using DnDRogueLikeUML.Items.WieldableItems;

namespace DnDRogueLikeUML.Creatures.Player
{
    class Wizard : Player
    {
        public Wizard()
        {
            Name = "Wizard";

            DisplayableStats = ChooseRolledStats();

            HitDie = 6;
            MaxHealth = HitDie;
            Health = MaxHealth;

            CurrentLocation = typeof(Battle);

            ActionList.Add(new Firebolt(this));
            ActionList.Add(new BurningHands(this));

            new ArcaneCrystal().Equip(this);
            new WoodenWand().Equip(this);
        }
    }
}
