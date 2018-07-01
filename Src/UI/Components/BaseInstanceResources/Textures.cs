using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Manabind.Src.UI.Components.BaseInstanceResources
{
    public class Textures
    {
        #region Fields

        private static Textures _instance;

        //Fonts
        public static SpriteFont ButtonFont;
        public static SpriteFont HeadingFont;

        #endregion

        #region Properties

        public static Textures Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Textures();
                }

                return _instance;
            }
        }

        #endregion

        #region Methods

        public void Initialise(ContentManager content)
        {
            //Fonts
            ButtonFont = content.Load<SpriteFont>("ButtonFont");
            HeadingFont = content.Load<SpriteFont>("HeadingFont");
        }

        #endregion
    }
}
