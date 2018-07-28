using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.IO;

namespace Manabind.Src.UI.Components.BaseInstanceResources
{
    public class Textures
    {
        #region Constants

        private string FontsPathName = "Fonts";
        private string IconsPathName = "Icons";
        private string TilesPathName = "Tiles";

        #endregion

        #region Fields

        private static Textures _instance;

        //Fonts
        public static SpriteFont ButtonFont;
        public static SpriteFont HeadingFont;

        //Textures
        public static Texture2D EmptyTile;
        public static Texture2D GroundTile;

        //Icons
        public static Texture2D GroundTileIcon;

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
            this.LoadFonts(content);
            this.LoadTiles(content);
            this.LoadIcons(content);
        }

        private void LoadFonts(ContentManager content)
        {
            ButtonFont = content.Load<SpriteFont>(Path.Combine(FontsPathName, "ButtonFont"));
            HeadingFont = content.Load<SpriteFont>(Path.Combine(FontsPathName, "HeadingFont"));
        }

        private void LoadTiles(ContentManager content)
        {
            EmptyTile = content.Load<Texture2D>(Path.Combine(TilesPathName, "EmptyTile"));
        }

        private void LoadIcons(ContentManager content)
        {
            GroundTileIcon = content.Load<Texture2D>(Path.Combine(IconsPathName, "GroundTileIcon"));
        }

        #endregion
    }
}
