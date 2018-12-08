using System.Collections.Generic;

namespace Manabind.Src.Gameplay
{
    public abstract class Faction
    {
        #region Properties

        public string Name
        {
            get;
            set;
        }

        public List<Unit> AvailableUnits
        {
            get;
            set;
        }

        //Ability UltimateAbility

        #endregion
    }
}
