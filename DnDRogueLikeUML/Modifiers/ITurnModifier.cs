using DnDRogueLikeUML.Creatures;

namespace DnDRogueLikeUML.Modifiers
{
    interface ITurnModifier
    {
        public int Turns { get; set; }

        public string Name { get;}

        public ICreature AppliedCreature { get;}

        public void Turn();
    }
}
