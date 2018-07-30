using Manabind.Src.Gameplay.Entities.Tiles;
using Manabind.Src.UI.Components.BaseInstanceResources;
using Manabind.Src.UI.Enums;

namespace Manabind.Src.Gameplay.Entities.Tile
{
    public class GroundTile : BaseTile
    {
        #region Constructors

        public GroundTile(int posX, int posY)
            : base(posX, posY, TileType.Ground, Textures.GroundTile, GetIcon(TileType.Ground))
        {
        }

        public GroundTile(BaseTile tile)
            : base(tile.PosX, tile.PosY, TileType.Ground, Textures.GroundTile, GetIcon(TileType.Ground))
        {
        }

        #endregion
    }
}
