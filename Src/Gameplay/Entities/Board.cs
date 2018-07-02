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
            foreach (List<Tile> row in Tiles)
            {
                foreach (Tile tile in row)
                {
                    tile.Draw(spriteBatch, tile.PosX * Tile.Diameter, tile.PosY * Tile.Diameter);
                }
            }
        }

        #endregion
    }
}
