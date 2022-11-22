using System;
using System.Collections.Generic;
using DnDRogueLikeUML.Action;

namespace DnDRogueLikeUML.Items.UsableItems
{
    interface IUsableItem : IItem, IAction
    {
        public IUsableItem Clone();
    }
}
