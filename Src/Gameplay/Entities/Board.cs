﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Manabind.Src.Gameplay.Entities.Tiles;
using Manabind.Src.Gameplay.Entities.Tile;
using Manabind.Src.UI.Enums;
using Manabind.Src.UI.Components.BaseInstanceResources;
using Manabind.Src.UI.Events;
using Microsoft.Xna.Framework.Input;
using Manabind.Src.Control;

namespace Manabind.Src.Gameplay.Entities
{
    public partial class Board : Listener
    {
        #region Constructors

        public Board()
        {
            this.Name = "board";
            this.Tiles = new List<List<BaseTile>>();
        }

        public Board(int width, int height)
        {
            this.Name = "board";
            this.Width = width;
            this.Height = height;
            this.Tiles = new List<List<BaseTile>>();
        }

        #endregion

        #region Properties

        public int Width
        {
            get;
            private set;
        }

        public int Height
        {
            get;
            private set;
        }

        public List<List<BaseTile>> Tiles
        {
            get;
            set;
        }

        public BaseTile HighlightedTile
        {
            get;
            set;
        }

        #endregion

        #region Methods

        public void Generate()
        {
            for (int x = 0; x < this.Width; x++)
            {
                List<BaseTile> column = new List<BaseTile>();

                for (int y = 0; y < this.Height; y++)
                {
                    bool oddRow = y % 2 == 1;

                    int canvasX = x * BaseTile.Diameter + (oddRow ? BaseTile.Diameter / 2 : 0);
                    int canvasY = y * (int)(BaseTile.Diameter * 0.75);

                    column.Add(new EmptyTile(x, y, canvasX, canvasY));
                }

                Tiles.Add(column);
            }
        }

        public void Update(Vector2 absoluteMousePosition, bool interact) //TO-DO Tidy this up
        {
            UpdateHighlightedTile(absoluteMousePosition, interact);

            if (HighlightedTile != null && MouseInfo.LeftMouseDown)
            {
                HighlightedTile.LeftMouseDown();
            }

            if (HighlightedTile != null && MouseInfo.LeftMouseClicked)
            {
                HighlightedTile.Click();
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 offset = default(Vector2))
        {
            foreach (List<BaseTile> column in Tiles)
            {
                foreach (BaseTile tile in column)
                {
                    tile.Draw(spriteBatch, offset);
                }
            }

            if (this.HighlightedTile != null)
            {
                spriteBatch.Draw(Textures.TileHover, new Vector2(HighlightedTile.CanvasX, HighlightedTile.CanvasY) + offset, Color.White);
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

        public BaseTile GetTileAtCoords(int x, int y)
        {
            BaseTile result = null;

            if (x >= 0 && x < Width &&
                y >= 0 && y < Height)
            {
                result = Tiles[x][y];
            }

            return result;
        }

        public void SetTileAtCoords(int x, int y, TileType tileType)
        {
            BaseTile tile = GetTileAtCoords(x, y);

            if (tile == null)
            {
                return;
            }

            switch (tileType)
            {
                case TileType.Empty:
                    this.Tiles[x][y] = new EmptyTile(tile);
                    break;

                case TileType.Ground:
                    this.Tiles[x][y] = new GroundTile(tile);
                    break;
            }
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

        private void UpdateHighlightedTile(Vector2 absoluteMousePosition, bool interact)
        {
            BaseTile highlightedTile = null;

            if (interact)
            {
                highlightedTile = GetTileAtMouse((int)absoluteMousePosition.X, (int)absoluteMousePosition.Y);
            }

            this.HighlightedTile = highlightedTile;
        }

        #endregion
    }
}
