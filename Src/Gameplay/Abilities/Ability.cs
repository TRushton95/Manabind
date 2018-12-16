using Manabind.Src.Gameplay.Interfaces;
using Manabind.Src.UI.Components.Complex;

namespace Manabind.Src.Gameplay.Abilities
{
    public class Ability : IIconable
    {
        #region Properties

        public string Name
        {
            get;
            set;
        }

        public int Cost
        {
            get;
            set;
        }

        public Icon Icon
        {
            get;
            set;
        }

        #endregion
    }
}
