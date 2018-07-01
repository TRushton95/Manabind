using Manabind.Src.UI.Enums;
using Microsoft.Xna.Framework.Graphics;

namespace Manabind.Src.Gameplay.Entities
{
    public class Tile : BaseActor
    {
        #region Constructors

        public Tile(int posX, int posY, TileType tileType, Texture2D texture)
            : base(posX, posY, texture)
        {
            this.TileType = tileType;
        }

        #endregion

        #region Properties

        public TileType TileType
        {
            get;
            set;
        }

        #endregion
    }
}
