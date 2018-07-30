using Manabind.Src.Gameplay.Entities;
using Manabind.Src.UI.Enums;
using Manabind.Src.UI.Events;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Manabind.Src.UI.Components.BaseInstanceResources;
using System;

namespace Manabind.Src.Control.AppStates
{
    public class EditorAppState : AppState
    {
        #region Fields

        private Board board;
        private Tile selectedTile;

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

            for (int y = 0; y < 6; y++)
            {
                List<Tile> row = new List<Tile>();

                for (int x = 0; x < 10; x++)
                {
                    row.Add(new Tile(x, y, TileType.Empty, Textures.EmptyTile, Tile.GetIcon(TileType.Empty)));
                }

                board.Tiles.Add(row);
            }
        }

        protected override void UpdateState()
        {
            if (uiInteracted)
            {
                return;
            }


        }

        protected override void DrawState(SpriteBatch spriteBatch)
        {
            board.Draw(spriteBatch);
        }

        protected override void ExecuteEventResponse(string action, object content)
        {
            switch (action)
            {
                case "select-tile":
                    this.selectedTile = (Tile)content;
                    break;
            }
        }
    }
}
