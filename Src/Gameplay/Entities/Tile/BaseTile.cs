using Manabind.Src.Gameplay.Interfaces;
using Manabind.Src.UI.Components.Complex;
using Manabind.Src.UI.Enums;
using Microsoft.Xna.Framework.Graphics;
using Manabind.Src.UI.Factories;
using Microsoft.Xna.Framework;

namespace Manabind.Src.Gameplay.Entities.Tiles
{
    public abstract class BaseTile : BaseEntity, IIconable
    {
        #region Fields

        public static int Diameter = 100;


        #endregion

        #region Constructors

        public BaseTile(TileType tileType, Texture2D texture, Icon icon)
            : base(EntityNames.Tile, 0, 0, 0, 0, texture)
        {
            this.TileType = tileType;
            this.Texture = texture;
            this.Icon = icon;
        }

        public BaseTile(int posX, int posY, int canvasX, int canvasY, TileType tileType, Texture2D texture, Icon icon)
            : base(EntityNames.Tile, posX, posY, canvasX, canvasY, texture)
        {
            this.PosX = posX;
            this.PosY = posY;
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

        public Unit Occupant
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
                case TileType.Empty:
                    result = IconFactory.BuildEmptyTileIcon();
                    break;

                case TileType.Ground:
                    result = IconFactory.BuildGroundTileIcon();
                    break;
            }

            return result;
        }

        public override void Draw(SpriteBatch spriteBatch, Vector2 offset = default(Vector2))
        {
            base.Draw(spriteBatch, offset);

            if (this.Occupant != null)
            {
                Occupant.Draw(spriteBatch, offset);
            }
        }

        #endregion
    }
}
