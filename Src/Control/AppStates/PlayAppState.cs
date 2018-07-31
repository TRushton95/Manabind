using Microsoft.Xna.Framework.Input;

namespace Manabind.Src.Control.AppStates
{
    public class PlayAppState : AppState
    {
        #region Constructors

        public PlayAppState()
        {
            componentManager.LoadUI(AppSettings.PlayUIFileName);
        }

        public PlayAppState(MouseState currentMouseState, MouseState prevMouseState)
            : base(currentMouseState, prevMouseState)
        {
            componentManager.LoadUI(AppSettings.PlayUIFileName);
        }

        #endregion

        #region Properties

        protected override string UIDefinitionFilename => AppSettings.PlayUIFileName;

        #endregion

        #region Methods

        protected override void UpdateState()
        {

        }

        #endregion
    }
}
