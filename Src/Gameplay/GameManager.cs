using Manabind.Src.Gameplay.AppStates;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Manabind.Src.Gameplay
{
    public static class GameManager
    {
        #region Fields

        private static AppState appState;

        #endregion

        #region Methods

        public static void Initialise(GraphicsDevice device, ContentManager content)
        {
            appState = new MenuAppState();
            appState.Initialise(device, content);
        }

        public static void Update()
        {
            appState.Update();
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            appState.Draw(spriteBatch);
        }

        #endregion
    }
}
