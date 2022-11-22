using System;
using System.Collections.Generic;

namespace DnDRogueLikeUML
{
    interface IUsableItem : IItem, IAction
    {
        public IUsableItem Clone();
    }
}
