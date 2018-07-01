using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Manabind.Src.Gameplay.Entities
{
    public class Board
    {
        #region Constructors

        public Board()
        {

        }

        #endregion

        #region Properties

        public List<Tile> Tiles
        {
            get;
            set;
        }

        #endregion

        #region Methods

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Tile tile in Tiles)
            {
                tile.Draw(spriteBatch, tile.PosX * Tile.Diameter, tile.PosY * Tile.Diameter);
            }
        }

        #endregion
    }
}
