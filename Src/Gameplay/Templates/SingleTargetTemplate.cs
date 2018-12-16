using System.Collections.Generic;
using Manabind.Src.Gameplay.Entities.Tiles;
using Microsoft.Xna.Framework;

namespace Manabind.Src.Gameplay.Templates
{
    public class SingleTargetTemplate : ITemplate
    {
        public List<Vector2> GetAffectedTiles(BaseTile targetTile)
        {
            return new List<Vector2>()
            {
                new Vector2(targetTile.PosX, targetTile.PosY)
            };
        }
    }
}
