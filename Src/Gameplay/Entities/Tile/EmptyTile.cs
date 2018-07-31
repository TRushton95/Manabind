using Manabind.Src.Gameplay.Entities.Tiles;
using Manabind.Src.UI.Components.BaseInstanceResources;
using Manabind.Src.UI.Enums;

namespace Manabind.Src.Gameplay.Entities.Tile
{
    public class EmptyTile : BaseTile
    {
        #region Constructors

        public EmptyTile()
            : base(TileType.Empty, Textures.EmptyTile, GetIcon(TileType.Empty))
        {
        }

        public EmptyTile(int posX, int posY, int canvasX, int canvasY)
            : base(posX, posY, canvasX, canvasY, TileType.Empty, Textures.EmptyTile, GetIcon(TileType.Empty))
        {
        }

        public EmptyTile(BaseTile tile)
            : base(tile.PosX, tile.PosY, tile.CanvasX, tile.CanvasY, TileType.Empty, Textures.EmptyTile, GetIcon(TileType.Empty))
        {
        }

        #endregion
    }
}
