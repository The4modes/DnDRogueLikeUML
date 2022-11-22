using DnDRogueLikeUML.Action;
using DnDRogueLikeUML.Items.WieldableItems;

namespace DnDRogueLikeUML.Creatures.Player
{
    class Wizard : Player
    {
        public Wizard()
        {
            Name = "Wizard";

            new Melee().Equip(this);

            HitDie = 6;
            MaxHealth = HitDie;
            Health = MaxHealth;
            CurrentLocation = typeof(Battle);
            ActionList.Add(new Firebolt(this));
        }
    }
}
