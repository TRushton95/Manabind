using System.Collections.Generic;
using Manabind.Src.Gameplay.Entities.Tiles;

namespace Manabind.Src.Gameplay.Templates
{
    public class SingleTargetTemplate : ITemplate
    {
        public List<BaseTile> GetAffectedTiles(BaseTile targetTile)
        {
            return new List<BaseTile>() { targetTile };
        }
    }
}
