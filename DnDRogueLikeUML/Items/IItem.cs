using DnDRogueLikeUML.Creatures;
using DnDRogueLikeUML.Creatures.Player;

namespace DnDRogueLikeUML.Items
{
    interface IItem
    {
        public string Name { get; set; }
        public string Rarity { get; set; }
        public string Description { get; set; }

        public void AddToInventory(HumanoidCreature creature);
    }
}
