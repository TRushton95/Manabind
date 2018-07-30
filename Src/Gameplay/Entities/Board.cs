using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Manabind.Src.Gameplay.Entities
{
    public class Board
    {
        #region Constructors

        public Board()
        {
            Tiles = new List<List<Tile>>();
        }

        #endregion

        #region Properties

        public List<List<Tile>> Tiles
        {
            get;
            set;
        }

        #endregion

        #region Methods

        public void Draw(SpriteBatch spriteBatch)
        {
            bool oddRow = false;

            foreach (List<Tile> row in Tiles)
            {
                foreach (Tile tile in row)
                {
                    int canvasY = tile.PosY * (int)(Tile.Diameter * 0.75);
                    int canvasX = tile.PosX * Tile.Diameter + (oddRow ? 50 : 0);

                    tile.Draw(spriteBatch, canvasX, canvasY);
                }

                oddRow = !oddRow;
            }
        }

        public Tile GetTileAtMouse(int mouseX, int mouseY)
        {
            Tile result = null;

            int gridHeight = (Tile.Diameter / 4) * 3;

            //get row and column hex is in
            int row = (int)(mouseY / gridHeight);

            bool rowIsOdd = row % 2 == 1;
            int offsetX = rowIsOdd ? Tile.Diameter / 2 : 0;

            int column = (int)((mouseX - offsetX) / Tile.Diameter); // Possible rounding error here with negative numbers

            if (rowIsOdd && mouseX < Tile.Diameter / 2) //hack to fix rounding error above
            {
                column--;
            }

            //calculate relative mousePosition. position in hex
            double relY = mouseY - (row * gridHeight);
            double relX;

            if (rowIsOdd)
            {
                relX = (mouseX - (column * Tile.Diameter)) - (Tile.Diameter / 2);
            }
            else
            {
                relX = mouseX - (column * Tile.Diameter);
            }

            //Console.WriteLine("(" + relX + "," + relY + ")");

            //use y = mx + c to determine which side of the line the mousePosition. position falls on
            double c = Tile.Diameter / 4;
            double m = c / (Tile.Diameter / 2);

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

        public Vector2 GetTileCanvasPos(Tile tile)
        {
            bool oddRow = IsOddRow(tile);

            int canvasX = tile.PosX * Tile.Diameter + (oddRow ? 50 : 0);
            int canvasY = tile.PosY * (int)(Tile.Diameter * 0.75);

            return new Vector2(canvasX, canvasY);
        }

        private bool IsOddRow(Tile tile)
        {
            return tile.PosY % 2 == 1; ;
        }

        private bool IsValidTile(int x, int y)
        {
            List<Tile> column = (x >= 0 && x <= Tiles.Count) ? Tiles[x] : null;

            if (column == null)
            {
                return false;
            }

            Tile tile = (y >= 0 && y <= column.Count) ? column[y] : null;

            if (tile == null)
            {
                return false;
            }

            return true;
        }

        #endregion
    }
}
