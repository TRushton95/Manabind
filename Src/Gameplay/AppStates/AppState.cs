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

        protected RootContainer container;
        private MouseState currentMouseState, prevMouseState;

        #endregion

        #region Constructors

        public AppState()
        {
            container = new RootContainer();
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
            container.InitialiseResources(device, content, windowWidth, windowHeight);
            container.Initialise();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            container.Draw(spriteBatch);
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
