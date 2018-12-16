using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Manabind.Src.Gameplay.Entities.Tiles;
using Manabind.Src.Gameplay.Entities.Tile;
using Manabind.Src.UI.Enums;
using Manabind.Src.UI.Components.BaseInstanceResources;
using Manabind.Src.UI.Events;
using Manabind.Src.Control;
using Manabind.Src.UI.Serialisation;
using Manabind.Src.UI.Factories;
using Manabind.Src.Gameplay.Templates;

namespace Manabind.Src.Gameplay.Entities
{
    public partial class Board : Listener
    {
        #region Constructors

        public Board()
        {
            this.Tiles = new List<List<BaseTile>>();

            this.Initialise();
        }

        public Board(int width, int height)
        {
            this.Width = width;
            this.Height = height;

            this.Initialise();
        }

        #endregion

        #region Properties

        public int Width
        {
            get;
            set;
        }

        public int Height
        {
            get;
            set;
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

        public List<Unit> Units
        {
            get;
            set;
        }

        public Unit HighlightedUnit
        {
            get;
            set;
        }

        public Unit PrevHighlightedUnit
        {
            get;
            set;
        }

        public ITemplate SelectedTemplate
        {
            get;
            set;
        }

        #endregion

        #region Methods

        public void Generate()
        {
            List<List<BaseTile>> newTiles = new List<List<BaseTile>>();

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

                newTiles.Add(column);
            }

            this.Tiles = newTiles;
        }

        public void Generate(Map map)
        {
            List<List<BaseTile>> newTiles = new List<List<BaseTile>>();

            for (int x = 0; x < map.Width; x++)
            {
                List<BaseTile> column = new List<BaseTile>();

                for (int y = 0; y < map.Height; y++)
                {
                    column.Add(
                        TileFactory.BuildTile(x, y, map.Tiles[x][y].TileType));
                }

                newTiles.Add(column);
            }

            this.Tiles = newTiles;
        }

        public void Update(Vector2 absoluteMousePosition, bool interact) //TO-DO Tidy this up
        {
            UpdateHighlightedTile(absoluteMousePosition, interact);
            UpdateHighlightedUnit(absoluteMousePosition, interact);

            //TO-DO The tiles use events but this is calculated in the board?
            if (HighlightedUnit != PrevHighlightedUnit)
            {
                if (HighlightedUnit != null)
                {
                    HighlightedUnit.Hover();
                }
                else
                {
                    PrevHighlightedUnit.HoverLeave();
                }
            }

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

            if (this.SelectedTemplate != null && this.HighlightedTile != null)
            {
                List<Vector2> affectedTilesCoords = this.SelectedTemplate.GetAffectedTiles(new Vector2(this.HighlightedTile.PosX, this.HighlightedTile.PosY));

                foreach (Vector2 tileCoords in affectedTilesCoords)
                {
                    BaseTile tile = GetTileAtCoords((int)tileCoords.X, (int)tileCoords.Y);

                    if (tile != null)
                    {
                        Vector2 canvasPos = new Vector2(tile.CanvasX, tile.CanvasY);
                        spriteBatch.Draw(Textures.RedFilter, canvasPos + offset, Color.White);
                    }
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

        public void SpawnUnit(Unit unit)
        {
            int x = unit.PosX;
            int y = unit.PosY;

            if (IsValidTile(x, y) && Tiles[x][y].Occupant == null)
            {
                GetTileAtCoords(x, y).Occupant = unit;
            }
        }

        public void MoveUnit(Unit unit, int x, int y)
        {
            if (IsValidTile(x, y) && GetTileAtCoords(x, y).Occupant == null)
            {
                GetTileAtCoords(unit.PosX, unit.PosY).Occupant = null;
                unit.PosX = x;
                unit.PosY = y;
                GetTileAtCoords(x, y).Occupant = unit;
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

        private void UpdateHighlightedUnit(Vector2 absoluteMousePosition, bool interact)
        {
            Unit highlightedUnit = null;

            if (interact)
            {
                highlightedUnit = GetTileAtMouse((int)absoluteMousePosition.X, (int)absoluteMousePosition.Y)?.Occupant;
            }

            PrevHighlightedUnit = this.HighlightedUnit;
            this.HighlightedUnit = highlightedUnit;
        }

        private void Initialise()
        {
            this.Name = "board";
            this.Tiles = new List<List<BaseTile>>();

            this.InitialiseListen(string.Empty);
            this.PersistantListener = true;

            this.EventResponses.Add(new EventResponse(
                new EventDetails("appstate", EventType.TemplateSelected), "select-ability"));
        }

        protected override void ExecuteEventResponse(string action, object content)
        {
            base.ExecuteEventResponse(action, content);

            switch (action)
            {
                case "select-ability":
                    this.SelectedTemplate = (ITemplate)content;

                    break;
            }
        }

        #endregion
    }
}
