using Manabind.Src.Gameplay.Entities.Tiles;
using System.Collections.Generic;

namespace Manabind.Src.Gameplay.Templates
{
    public interface ITemplate
    {
         List<BaseTile> GetAffectedTiles(BaseTile targetTile);
    }
}
