using System;
using Microsoft.Xna.Framework.Graphics;

namespace Manabind.Src.Gameplay.AppStates
{
    public class MenuAppState : AppState
    {
        #region Constructors

        public MenuAppState()
        {
            container.LoadUI(AppSettings.MenuUIFileName);
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
