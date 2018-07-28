using Manabind.Src.Gameplay.Entities;
using Manabind.Src.UI.Components.BaseInstanceResources;
using Manabind.Src.UI.Enums;
using Manabind.Src.UI.Factories;

namespace Manabind.Src.Gameplay.Factories
{
    public class TileFactory : BaseInstance
    {
        #region Methods

        public static Tile BuildGroundTile()
        {
            return new Tile(0, 0, TileType.Ground, Textures.GroundTile, IconFactory.BuildGroundTileIcon());
        }

        #endregion
    }
}
