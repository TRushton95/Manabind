using Microsoft.Xna.Framework.Input;

namespace Manabind.Src.Control.AppStates
{
    public class MenuAppState : AppState
    {
        #region Constructors

        public MenuAppState()
        {
        }

        public MenuAppState(MouseState currentMouseState, MouseState prevMouseState)
            : base(currentMouseState, prevMouseState)
        {
        }

        #endregion

        #region Properties

        protected override string UIDefinitionFilename => AppSettings.MenuUIFileName;

        #endregion
    }
}
