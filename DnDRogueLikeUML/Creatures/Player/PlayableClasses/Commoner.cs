using DnDRogueLikeUML.Items.WieldableItems;

namespace DnDRogueLikeUML.Creatures.Player
{
    class Commoner : Player
    {
        public Commoner()
        {
            Name = "Commoner";

            DisplayableStats = ChooseRolledStats();

            HitDie = 8;
            MaxHealth = HitDie;
            Health = MaxHealth;
            
            CurrentLocation = typeof(Battle);

            new Scimitar().Equip(this);
        }
    }
}
