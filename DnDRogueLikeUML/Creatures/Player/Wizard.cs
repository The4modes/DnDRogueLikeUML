using DnDRogueLikeUML.Action;

namespace DnDRogueLikeUML.Creatures.Player
{
    class Wizard : Player
    {
        public Wizard()
        {
            Name = "Wizard";

            HitDie = 6;
            MaxHealth = HitDie;
            Health = MaxHealth;
            CurrentLocation = typeof(Battle);
            ActionList.Add(new Firebolt(this));
        }
    }
}
