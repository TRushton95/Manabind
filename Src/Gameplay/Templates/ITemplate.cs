using Manabind.Src.Gameplay.Entities.Tiles;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Manabind.Src.Gameplay.Templates
{
    public interface ITemplate
    {
         List<Vector2> GetAffectedTiles(BaseTile targetTile);
    }
}
