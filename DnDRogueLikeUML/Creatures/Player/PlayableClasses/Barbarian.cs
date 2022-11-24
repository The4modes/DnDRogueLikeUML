using DnDRogueLikeUML.Items.WieldableItems;

namespace DnDRogueLikeUML.Creatures.Player
{
    class Barbarian : Player
    {
        public Barbarian()
        {
            Name = "Barbarian";

            DisplayableStats = ChooseRolledStats();

            HitDie = 12;
            MaxHealth = HitDie;
            Health = MaxHealth;
            
            CurrentLocation = typeof(Battle);

            new GreatAxe().Equip(this);
        }

    }
}
