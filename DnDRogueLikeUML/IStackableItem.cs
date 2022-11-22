using System.Transactions;

namespace DnDRogueLikeUML
{

    interface IStackableItem : IItem
    {
        public int ItemStack { get; set; }

        public void AddToStack(int amount);
        public IStackableItem Clone();
    }
}
