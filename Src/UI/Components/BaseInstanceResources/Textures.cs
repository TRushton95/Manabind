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
        private string UnitsPathName = "Units";

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
        public static Texture2D EmptyTileIcon, EmptyTileIconHover;
        public static Texture2D GroundTileIcon, GroundTileIconHover;
        public static Texture2D TileIconHover;

        //Units
        public static Texture2D AllyUnit, EnemyUnit;

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
            this.LoadUnits(content);
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
            EmptyTileIconHover = LoadIcon(content, "EmptyTileIconHover");
            GroundTileIcon = LoadIcon(content, "GroundTileIcon");
            GroundTileIconHover = LoadIcon(content, "GroundTileIconHover");
            TileIconHover = LoadIcon(content, "TileIconHover");
        }

        private void LoadUnits(ContentManager content)
        {
            AllyUnit = LoadUnit(content, "BlueUnit");
            EnemyUnit = LoadUnit(content, "RedUnit");
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

        private Texture2D LoadUnit(ContentManager content, string unitName)
        {
            return content.Load<Texture2D>(Path.Combine(UnitsPathName, unitName));
        }

        #endregion
    }
}
