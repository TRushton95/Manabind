using Microsoft.Xna.Framework.Graphics;

namespace Manabind.Src.UI.Components.BaseInstanceResources
{
    public abstract class BaseInstance
    {
        #region Fields

        private static GraphicsDevice _graphicsDevice;

        #endregion

        #region Properties

        protected static GraphicsDevice GraphicsDevice => _graphicsDevice;

        protected static Textures Textures => Textures.Instance;

        #endregion

        #region Methods

        public void InitialiseResources(GraphicsDevice device)
        {
            _graphicsDevice = device;
        }

        #endregion
    }
}
