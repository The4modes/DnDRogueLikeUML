using DnDRogueLikeUML.Items.WieldableItems;

namespace DnDRogueLikeUML.Creatures.Player
{
    class Barbarian : Player
    {
        public Barbarian()
        {
            HitDie = 12;
            MaxHealth = HitDie;
            Health = MaxHealth;
            Name = "Barbarian";

            CurrentLocation = typeof(Battle);
            new GreatAxe().Equip(this);
        }

    }
}
