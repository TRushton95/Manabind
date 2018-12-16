using System.Collections.Generic;
using Manabind.Src.Gameplay.Entities.Tiles;

namespace Manabind.Src.Gameplay.Templates
{
    public class AreaAffectTemplate : ITemplate
    {
        #region Constructors

        public AreaAffectTemplate(int radius)
        {
            this.Radius = radius;
        }

        #endregion

        #region Properties

        public int Radius
        {
            get;
            set;
        }

        public int Diameter => Radius * 2;

        #endregion

        #region Methods

        public List<BaseTile> GetAffectedTiles(BaseTile targetTile)
        {
            int targetX = targetTile.PosX;
            int targetY = targetTile.PosY;

            int minX = targetX - Radius;
            int minY = targetY - Radius;

            List<BaseTile> result = new List<BaseTile>();

            //TO-DO Get tiles from the board somehow

            return result;
        }

        #endregion
    }
}
