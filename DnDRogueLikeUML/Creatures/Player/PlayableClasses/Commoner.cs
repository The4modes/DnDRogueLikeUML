using DnDRogueLikeUML.Items.WieldableItems;

namespace DnDRogueLikeUML.Creatures.Player
{
    class Commoner : Player
    {
        public Commoner()
        {
            HitDie = 8;
            MaxHealth = HitDie;
            Health = MaxHealth;
            Name = "Commoner";

            new Scimitar().Equip(this);

            CurrentLocation = typeof(Battle);

            
        }
    }
}
