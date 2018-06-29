using Manabind.Src.UI.Components;
using Manabind.Src.UI.Components.Basic;
using Manabind.Src.UI.Components.Complex;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Manabind.Src.Gameplay.AppStates
{
    public abstract class AppState
    {
        #region Fields

        protected ComponentManager componentManager;
        protected MouseState currentMouseState, prevMouseState;

        #endregion

        #region Constructors

        public AppState()
        {
            componentManager = new ComponentManager();
        }

        #endregion

        #region Properties

        protected abstract string UIDefinitionFilename { get; }

        #endregion

        #region Methods

        public void Update()
        {
            UpdateState();
            UpdateMouseState();
        }

        public void Initialise(GraphicsDevice device, ContentManager content, int windowWidth, int windowHeight)
        {
            componentManager.InitialiseResources(device, content, windowWidth, windowHeight);
            componentManager.Initialise();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            componentManager.GetRoot().Draw(spriteBatch);
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
