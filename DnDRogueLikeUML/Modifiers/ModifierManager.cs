using DnDRogueLikeUML.Creatures;

namespace DnDRogueLikeUML.Modifiers
{
    class ModifierManager
    {
        
        public static ITurnModifier Contains(ICreature creature, ITurnModifier modifier)
        {
            ITurnModifier creatureMod = null;

            foreach (ITurnModifier mod in creature.TurnModifiers)
            {
                if (mod.GetType() == modifier.GetType())
                {
                    creatureMod = mod;
                }
            }

            return creatureMod;
        }
    }
}
