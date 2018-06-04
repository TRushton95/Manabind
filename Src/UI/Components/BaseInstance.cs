using Microsoft.Xna.Framework.Graphics;

namespace Manabind.Src.UI.Components
{
    public abstract class BaseInstance
    {
        private static GraphicsDevice _graphicsDevice;

        public GraphicsDevice GraphicsDevice
        {
            get
            {
                return _graphicsDevice;
            }
        }

        public void InitialiseResources(GraphicsDevice device)
        {
            _graphicsDevice = device;
        }
    }
}
