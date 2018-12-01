using Manabind.Src.UI.Enums;

namespace Manabind.Src.UI.Serialisation
{
    public class Tile
    {
        #region Constructors

        public Tile(int posX, int posY, TileType tileType)
        {
            this.PosX = posX;
            this.PosY = posY;
            this.TileType = tileType;
        }

        #endregion

        #region Properties

        public int PosX
        {
            get;
            set;
        }

        public int PosY
        {
            get;
            set;
        }
        
        public TileType TileType
        {
            get;
            set;
        }

        #endregion
    }
}
