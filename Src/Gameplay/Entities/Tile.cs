using Manabind.Src.Gameplay.Interfaces;
using Manabind.Src.UI.Components.Complex;
using Manabind.Src.UI.Enums;
using Microsoft.Xna.Framework.Graphics;
using Manabind.Src.UI.Factories;

namespace Manabind.Src.Gameplay.Entities
{
    public class Tile : BaseEntity, IIconable
    {
        #region Fields

        public static int Diameter = 100;

        #endregion

        #region Constructors

        public Tile(int posX, int posY, TileType tileType, Texture2D texture, Icon icon)
            : base(posX, posY, texture)
        {
            this.TileType = tileType;
            this.Icon = icon;
        }

        #endregion

        #region Properties

        public TileType TileType
        {
            get;
            set;
        }
        public Icon Icon
        {
            get;
            set;
        }

        #endregion

        #region Methods

        public static Icon GetIcon(TileType tileType)
        {
            Icon result = null;

            switch (tileType)
            {
                case TileType.Ground:
                    result = IconFactory.BuildGroundTileIcon();
                    break;
            }

            return result;
        }

        #endregion
    }
}
