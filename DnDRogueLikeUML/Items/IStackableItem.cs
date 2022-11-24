using System.Transactions;

namespace DnDRogueLikeUML.Items
{

    interface IStackableItem : IItem
    {
        public int ItemStack { get; set; }

        public void AddToStack(int amount);
    }
}
