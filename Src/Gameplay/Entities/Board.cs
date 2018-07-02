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

        #endregion
    }
}
