using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Manabind.Src.Gameplay.Templates
{
    public interface ITemplate
    {
         List<Vector2> GetAffectedTiles(Vector2 targetTileCoords);
    }
}
