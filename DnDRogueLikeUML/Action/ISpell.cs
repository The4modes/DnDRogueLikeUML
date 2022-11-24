using System.Xml.Linq;

namespace DnDRogueLikeUML.Action
{

    interface ISpell : IAction
    {
        public int LevelRequirement { get; set; }

        public string ActionType { get; set; }

    }
}
