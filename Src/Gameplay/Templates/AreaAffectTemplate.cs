﻿using System.Collections.Generic;
using Microsoft.Xna.Framework;

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

        //TO-DO What if the board is suddenly squares? This should still have to work then too, this shouldn't be responsible for that logic
        public List<Vector2> GetAffectedTiles(Vector2 targetTileCoords)
        {
            List<Vector2> result = new List<Vector2>();

            result.Add(targetTileCoords);
            
            Vector2 currentTile = targetTileCoords;

            int distanceToCorner = 1;

            // -1 to exclude center tile
            for (int i = 0; i < Radius - 1; i++) // for each ring around the center tile
            {
                currentTile = TopRight(currentTile);

                for (int j = 0; j < distanceToCorner; j++) // for each path to the next corner
                {
                    result.Add(currentTile);
                    currentTile = BottomRight(currentTile);
                }

                for (int j = 0; j < distanceToCorner; j++) // for each path to the next corner
                {
                    result.Add(currentTile);
                    currentTile = BottomLeft(currentTile);
                }

                for (int j = 0; j < distanceToCorner; j++) // for each path to the next corner
                {
                    result.Add(currentTile);
                    currentTile = Left(currentTile);
                }

                for (int j = 0; j < distanceToCorner; j++) // for each path to the next corner
                {
                    result.Add(currentTile);
                    currentTile = TopLeft(currentTile);
                }

                for (int j = 0; j < distanceToCorner; j++) // for each path to the next corner
                {
                    result.Add(currentTile);
                    currentTile = TopRight(currentTile);
                }

                for (int j = 0; j < distanceToCorner; j++) // for each path to the next corner
                {
                    result.Add(currentTile);
                    currentTile = Right(currentTile);
                }

                distanceToCorner++;
            }

            return result;
        }

        private Vector2 TopRight(Vector2 tile)
        {
            if (IsOddRow((int)tile.Y))
            {
                return new Vector2(tile.X + 1, tile.Y - 1);
            }

            return new Vector2(tile.X, tile.Y - 1);
        }

        private Vector2 BottomRight(Vector2 tile)
        {
            if (IsOddRow((int)tile.Y))
            {
                return new Vector2(tile.X + 1, tile.Y + 1);
            }

            return new Vector2(tile.X, tile.Y + 1);
        }

        private Vector2 BottomLeft(Vector2 tile)
        {
            if (IsOddRow((int)tile.Y))
            {
                return new Vector2(tile.X, tile.Y + 1);
            }

            return new Vector2(tile.X - 1, tile.Y + 1);
        }

        private Vector2 Left(Vector2 tile)
        {
            return new Vector2(tile.X - 1, tile.Y);
        }

        private Vector2 TopLeft(Vector2 tile)
        {
            if (IsOddRow((int)tile.Y))
            {
                return new Vector2(tile.X, tile.Y - 1);
            }

            return new Vector2(tile.X - 1, tile.Y - 1);
        }

        private Vector2 Right(Vector2 tile)
        {
            return new Vector2(tile.X + 1, tile.Y);
        }

        private bool IsOddRow(int row)
        {
            if (row < 0)
            {
                row = -row;
            }

            return row % 2 == 1;
        }

        #endregion
    }
}
