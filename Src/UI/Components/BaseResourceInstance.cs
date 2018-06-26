using Microsoft.Xna.Framework.Graphics;

namespace Manabind.Src.UI.Components
{
    public abstract class BaseResourceInstance
    {
        #region Fields

        private static GraphicsDevice _graphicsDevice;

        #endregion

        #region Properties

        public GraphicsDevice GraphicsDevice
        {
            get
            {
                return _graphicsDevice;
            }
        }

        #endregion

        #region Methods

        public void InitialiseResources(GraphicsDevice device)
        {
            _graphicsDevice = device;
        }

        #endregion
    }
}
