using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Manabind.Src.Gameplay.Entities.Tiles;

namespace Manabind.Src.Gameplay.Entities
{
    public class Board
    {
        #region Constructors

        public Board()
        {
            Tiles = new List<List<BaseTile>>();
        }

        #endregion

        #region Properties

        public List<List<BaseTile>> Tiles
        {
            get;
            set;
        }

        #endregion

        #region Methods

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (List<BaseTile> column in Tiles)
            {
                foreach (BaseTile tile in column)
                {
                    int canvasX = tile.PosX * BaseTile.Diameter + (IsOddRow(tile) ? 50 : 0);
                    int canvasY = tile.PosY * (int)(BaseTile.Diameter * 0.75);

                    tile.Draw(spriteBatch, canvasX, canvasY);
                }
            }
        }

        public BaseTile GetTileAtMouse(int mouseX, int mouseY)
        {
            BaseTile result = null;

            int gridHeight = (BaseTile.Diameter / 4) * 3;

            //get row and column hex is in
            int row = (int)(mouseY / gridHeight);

            bool rowIsOdd = row % 2 == 1;
            int offsetX = rowIsOdd ? BaseTile.Diameter / 2 : 0;

            int column = (int)((mouseX - offsetX) / BaseTile.Diameter); // Possible rounding error here with negative numbers

            if (rowIsOdd && mouseX < BaseTile.Diameter / 2) //hack to fix rounding error above
            {
                column--;
            }

            //calculate relative mousePosition. position in hex
            double relY = mouseY - (row * gridHeight);
            double relX;

            if (rowIsOdd)
            {
                relX = (mouseX - (column * BaseTile.Diameter)) - (BaseTile.Diameter / 2);
            }
            else
            {
                relX = mouseX - (column * BaseTile.Diameter);
            }

            //Console.WriteLine("(" + relX + "," + relY + ")");

            //use y = mx + c to determine which side of the line the mousePosition. position falls on
            double c = BaseTile.Diameter / 4;
            double m = c / (BaseTile.Diameter / 2);

            if (relY < (-m * relX) + c) //left edge
            {
                row--;

                if (!rowIsOdd)
                {
                    column--;
                }
            }
            else if (relY < (m * relX) - c) //right edge
            {
                row--;

                if (rowIsOdd)
                {
                    column++;
                }
            }

            if (IsValidTile(column, row))
            {
                result = Tiles[column][row];
            }

            return result;
        }

        public Vector2 GetTileCanvasPos(BaseTile tile)
        {
            bool oddRow = IsOddRow(tile);

            int canvasX = tile.PosX * BaseTile.Diameter + (oddRow ? 50 : 0);
            int canvasY = tile.PosY * (int)(BaseTile.Diameter * 0.75);

            return new Vector2(canvasX, canvasY);
        }

        private bool IsOddRow(BaseTile tile)
        {
            return tile.PosY % 2 == 1; ;
        }

        private bool IsValidTile(int x, int y)
        {
            List<BaseTile> column = (x >= 0 && x < Tiles.Count) ? Tiles[x] : null;

            if (column == null)
            {
                return false;
            }

            BaseTile tile = (y >= 0 && y < column.Count) ? column[y] : null;

            if (tile == null)
            {
                return false;
            }

            return true;
        }

        #endregion
    }
}
