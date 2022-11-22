namespace DnDRogueLikeUML
{
    interface IWieldableItem : IItem
    {
        public ICreature Wielder { get; set; }

        public void Equip(ICreature creature);

        public void UnEquip();

        public IWieldableItem Clone();
    }
}
