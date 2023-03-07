using System.Xml.Linq;

namespace DnDRogueLikeUML.Action
{

    interface ISpell : IAction
    {
        public int LevelRequirement { get; }

        public string ActionType { get; }

    }
}
