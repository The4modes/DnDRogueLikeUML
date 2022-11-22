using System;
using System.Collections.Generic;

namespace DnDRogueLikeUML
{
    abstract class Player : ICreature
    {
        public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Health { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int MaxHealth { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int HitDie { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Level { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int XP { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int ArmorClass { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Strenght { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Dexterity { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Constitution { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Intelligence { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Wisdom { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Charisma { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Type CurrentLocation { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public List<IUsableItem> UsableItemsList { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public List<IStackableItem> StackableItemsList { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public List<IWieldableItem> WieldableItemsList { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IWieldableItem RightHand { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IWieldableItem LeftHand { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void DoAction()
        {
            throw new NotImplementedException();
        }

        public List<IAction> GenerateAvailableActions()
        {
            throw new NotImplementedException();
        }
    }
}
