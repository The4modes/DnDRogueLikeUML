using DnDRogueLikeUML.Items.WieldableItems;

namespace DnDRogueLikeUML.Creatures.Player
{
    class Commoner : Player
    {
        public Commoner()
        {
            new Fist().Equip(this);
            new Fist().Equip(this);

            HitDie = 8;
            MaxHealth = HitDie;
            Health = MaxHealth;
            Name = "Commoner";

            CurrentLocation = typeof(Battle);

            
        }
    }
}
