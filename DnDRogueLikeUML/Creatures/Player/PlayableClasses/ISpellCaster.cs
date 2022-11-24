using System.Collections.Generic;
using DnDRogueLikeUML.Action;

namespace DnDRogueLikeUML.Creatures.Player
{
    interface ISpellCaster
    {
        public Dictionary<string, int> SpellSlots { get; set; }

        public List<ISpell> Spells { get; set; }

        public void AddSpell(ISpell spell);
    }
}
