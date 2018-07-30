using Manabind.Src.Gameplay.Entities.Tiles;
using Manabind.Src.UI.Components.BaseInstanceResources;
using Manabind.Src.UI.Enums;

namespace Manabind.Src.Gameplay.Entities.Tile
{
    public class EmptyTile : BaseTile
    {
        #region Constructors

        public EmptyTile(int posX, int posY)
            : base(posX, posY, TileType.Empty, Textures.EmptyTile, GetIcon(TileType.Empty))
        {
        }

        public EmptyTile(BaseTile tile)
            : base(tile.PosX, tile.PosY, TileType.Empty, Textures.EmptyTile, GetIcon(TileType.Empty))
        {
        }

        #endregion
    }
}
