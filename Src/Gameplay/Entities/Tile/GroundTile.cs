using Manabind.Src.Gameplay.Entities.Tiles;
using Manabind.Src.UI.Components.BaseInstanceResources;
using Manabind.Src.UI.Enums;

namespace Manabind.Src.Gameplay.Entities.Tile
{
    public class GroundTile : BaseTile
    {
        #region Constructors

        public GroundTile()
            : base(TileType.Ground, Textures.GroundTile, GetIcon(TileType.Ground))
        {
        }

        public GroundTile(int posX, int posY, int canvasX, int canvasY)
            : base(posX, posY, canvasX, canvasY, TileType.Ground, Textures.GroundTile, GetIcon(TileType.Ground))
        {
        }

        public GroundTile(BaseTile tile)
            : base(tile.PosX, tile.PosY, tile.CanvasX, tile.CanvasY, TileType.Ground, Textures.GroundTile, GetIcon(TileType.Ground))
        {
        }

        #endregion
    }
}
