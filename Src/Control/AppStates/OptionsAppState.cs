﻿using Microsoft.Xna.Framework.Input;

namespace Manabind.Src.Control.AppStates
{
    public class OptionsAppState : AppState
    {
        #region Constructors

        public OptionsAppState()
        {
        }

        #endregion

        #region Properties

        protected override string UIDefinitionFilename => AppSettings.OptionsUIFileName;

        #endregion

        #region Methods

        protected override void UpdateState()
        {

        }

        #endregion
    }
}
