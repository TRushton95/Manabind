using Manabind.Src.Gameplay.Abilities;
using System.Collections.Generic;

namespace Manabind.Src.Gameplay
{
    public class Player
    {
        #region Constructors



        #endregion

        #region Properties

        public int Team
        {
            get;
            set;
        }

        public List<Unit> Units
        {
            get;
            set;
        }

        public Ability Ultimate
        {
            get;
            set;
        }

        #endregion
    }
}
