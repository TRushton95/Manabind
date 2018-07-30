using Manabind.Src.Gameplay.Entities;
using Manabind.Src.UI.Enums;
using Manabind.Src.UI.Events;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Manabind.Src.UI.Components.BaseInstanceResources;
using System;
using Microsoft.Xna.Framework;

namespace Manabind.Src.Control.AppStates
{
    public class EditorAppState : AppState
    {
        #region Fields

        private Board board;
        private Tile highlightedTile;

        #endregion

        #region Constructors

        public EditorAppState()
        {
            this.board = new Board();

            this.EventResponses.Add(new EventResponse(new EventDetails("tool", EventType.Click), "select-tile"));
        }

        #endregion

        #region Properties

        protected override string UIDefinitionFilename => AppSettings.EditorUIFileName;

        #endregion

        protected override void InitialiseState()
        {
            //TODO Proper load in logic here

            for (int x = 0; x < 10; x++)
            {
                List<Tile> column = new List<Tile>();

                for (int y = 0; y < 6; y++)
                {
                    column.Add(new Tile(x, y, TileType.Empty, Textures.EmptyTile, Tile.GetIcon(TileType.Empty)));
                }

                board.Tiles.Add(column);
            }
        }

        protected override void UpdateState()
        {
            if (uiInteracted)
            {
                return;
            }

            highlightedTile = board.GetTileAtMouse(currentMouseState.X, currentMouseState.Y);
        }

        protected override void DrawState(SpriteBatch spriteBatch)
        {
            board.Draw(spriteBatch);

            if (highlightedTile != null)
            {
                spriteBatch.Draw(Textures.TileHover, board.GetTileCanvasPos(highlightedTile), Color.White);
            }
        }

        protected override void ExecuteEventResponse(string action, object content)
        {
            switch (action)
            {
                case "select-tile":
                    break;
            }
        }
    }
}
