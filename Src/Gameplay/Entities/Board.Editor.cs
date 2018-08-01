using Manabind.Src.Gameplay.Entities.Tile;
using Manabind.Src.Gameplay.Entities.Tiles;
using Manabind.Src.UI.Enums;
using System.Collections.Generic;
using System.Linq;

namespace Manabind.Src.Gameplay.Entities
{
    public partial class Board
    {
        #region Methods

        public void AddRow()
        {
            foreach (List<BaseTile> column in Tiles)
            {
                int x = Tiles.IndexOf(column);
                int y = Height;

                bool oddRow = y % 2 == 1;

                int canvasX = x * BaseTile.Diameter + (oddRow ? BaseTile.Diameter / 2 : 0);
                int canvasY = y * (int)(BaseTile.Diameter * 0.75);

                column.Add(new EmptyTile(x, y, canvasX, canvasY));
            }

            Height++;
        }

        public void RemoveRow()
        {
            foreach (List<BaseTile> column in Tiles)
            {
                BaseTile lastTile = column.Last();
                column.Remove(lastTile);
            }

            Height--;
        }

        #endregion
    }
}
