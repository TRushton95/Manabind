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
        public static Texture2D TileHover;

        //Icons
        public static Texture2D GroundTileIcon;
        public static Texture2D EmptyTileIcon;

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
            ButtonFont = LoadFont(content, "ButtonFont");
            HeadingFont = LoadFont(content, "HeadingFont");
        }

        private void LoadTiles(ContentManager content)
        {
            EmptyTile = LoadTile(content, "EmptyTile");
            GroundTile = LoadTile(content, "GroundTile");
            TileHover = LoadTile(content, "TileHover");
        }

        private void LoadIcons(ContentManager content)
        {
            EmptyTileIcon = LoadIcon(content, "EmptyTileIcon");
            GroundTileIcon = LoadIcon(content, "GroundTileIcon");
        }

        private SpriteFont LoadFont(ContentManager content, string fontName)
        {
            return content.Load<SpriteFont>(Path.Combine(FontsPathName, fontName));
        }

        private Texture2D LoadTile(ContentManager content, string tileName)
        {
            return content.Load<Texture2D>(Path.Combine(TilesPathName, tileName));
        }
        private Texture2D LoadIcon(ContentManager content, string iconName)
        {
            return content.Load<Texture2D>(Path.Combine(IconsPathName, iconName));
        }

        #endregion
    }
}
