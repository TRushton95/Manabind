using Manabind.Src.UI;
using Microsoft.Xna.Framework.Input;

namespace Manabind.Src.Gameplay.AppStates
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
            this.uiManager.LoadUI(this.UIDefinitionFilename);
        }

        #endregion

        #region Properties

        protected abstract string UIDefinitionFilename
        {
            get;
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
