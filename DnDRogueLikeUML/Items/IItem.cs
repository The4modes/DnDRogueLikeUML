namespace DnDRogueLikeUML.Items
{
    interface IItem
    {
        public string Name { get; set; }
        public string Rarity { get; set; }
        public string Description { get; set; }
    }
}
