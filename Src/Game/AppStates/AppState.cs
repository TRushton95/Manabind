using Manabind.Src.UI;
using Microsoft.Xna.Framework.Input;

namespace Manabind.Src.Game.AppStates
{
    public abstract class AppState
    {
        #region Fields

        private MouseState currentMouseState, prevMouseState;

        private UIManager uiManager;

        #endregion

        #region Constructors

        public AppState()
        {
            this.uiManager = new UIManager();
        }

        #endregion

        #region Methods

        public void Update()
        {
            UpdateState();
            UpdateMouseState();
        }

        protected abstract void UpdateState();

        private void UpdateMouseState()
        {
            this.prevMouseState = this.currentMouseState;
            this.currentMouseState = Mouse.GetState();
        }

        #endregion
    }
}
