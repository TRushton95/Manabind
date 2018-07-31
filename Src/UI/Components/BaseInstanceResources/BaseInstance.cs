using Manabind.Src.UI.Events;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Manabind.Src.UI.Components.BaseInstanceResources
{
    public abstract class BaseInstance : Listener
    {
        #region Fields

        private static GraphicsDevice _graphicsDevice;
        private static ContentManager _content;

        #endregion

        #region Constructors

        public BaseInstance()
            : base()
        {
        }

        #endregion

        #region Properties

        protected static GraphicsDevice GraphicsDevice => _graphicsDevice;

        protected static ContentManager Content => _content;

        protected static Textures Textures => Textures.Instance;

        protected static Settings Settings => Settings.Instance;

        #endregion

        #region Methods

        public void InitialiseResources(GraphicsDevice device, ContentManager content)
        {
            _graphicsDevice = device;
            _content = content;
            Textures.Initialise(content);
            Settings.Initialise();
        }

        #endregion
    }
}
