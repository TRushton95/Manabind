using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Manabind.Src.Gameplay.Templates
{
    public class SingleTargetTemplate : ITemplate
    {
        public List<Vector2> GetAffectedTiles(Vector2 targetTileCoords)
        {
            return new List<Vector2>()
            {
                targetTileCoords
            };
        }
    }
}
