using Manabind.Src.Gameplay.Entities.Tile;
using Manabind.Src.Gameplay.Entities.Tiles;
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
            if (Height < 1)
            {
                return;
            }

            foreach (List<BaseTile> column in Tiles)
            {
                BaseTile lastTile = column.Last();
                column.Remove(lastTile);
            }

            Height--;
        }

        public void AddColumn()
        {
            List<BaseTile> column = new List<BaseTile>();

            for (int i = 0; i < Height; i++)
            {
                bool oddRow = i % 2 == 1;

                int posX = Width;
                int posY = i;
                int canvasX = posX * BaseTile.Diameter + (oddRow ? BaseTile.Diameter / 2 : 0);
                int canvasY = posY * (int)(BaseTile.Diameter * 0.75);

                column.Add(new EmptyTile(posX, posY, canvasX, canvasY));
            }

            Tiles.Add(column);

            Width++;
        }

        public void RemoveColumn()
        {
            if (Width < 1)
            {
                return;
            }

            Tiles.RemoveAt(Tiles.Count - 1);

            Width--;
        }

        #endregion
    }
}
