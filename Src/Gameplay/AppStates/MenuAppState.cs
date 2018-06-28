using System;

namespace Manabind.Src.Gameplay.AppStates
{
    public class MenuAppState : AppState
    {
        #region Constructors

        public MenuAppState()
        {
        }

        #endregion

        #region Properties

        protected override string UIDefinitionFilename => AppSettings.MenuUIFileName;

        #endregion

        #region Methods

        protected override void UpdateState()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
