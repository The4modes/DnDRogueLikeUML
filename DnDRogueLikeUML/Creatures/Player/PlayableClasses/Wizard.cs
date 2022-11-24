using System.Collections.Generic;
using DnDRogueLikeUML.Action;
using DnDRogueLikeUML.Items.WieldableItems;

namespace DnDRogueLikeUML.Creatures.Player
{
    class Wizard : Player, ISpellCaster
    {
        public Dictionary<string, int> SpellSlots { get; set; } = new Dictionary<string, int>();
        public List<ISpell> Spells { get; set; 
        } = new List<ISpell>();

        public Wizard()
        {
            Name = "Wizard";

            DisplayableStats = ChooseRolledStats();

            HitDie = 6;
            MaxHealth = HitDie;
            Health = MaxHealth;

            CurrentLocation = typeof(Battle);

            SpellSlots.Add("FirstLevel:", 2);

            AddSpell(new Firebolt(this));
            AddSpell(new BurningHands(this));

            new ArcaneCrystal().Equip(this);
            new WoodenWand().Equip(this);
        }
        
        protected override void LevelUp()
        {
            base.LevelUp();
            switch (Level)
            {
                case 2:
                    AddSpell(new MageArmor(this));
                    break;
                case 3:
                    AddSpell(new Fireball(this));
                    SpellSlots.Add("ThirdLevel:", 1);
                    break;
                default:
                    break;
            }
        }

        public void AddSpell(ISpell spell)
        {
            Spells.Add(spell);
            if (spell.ActionType == "Main")
            {
                ActionList.Add(spell);
            }
            else if(spell.ActionType == "Bonus")
            {
                BonusActionList.Add(spell);
            }
            
        }
    }
}
