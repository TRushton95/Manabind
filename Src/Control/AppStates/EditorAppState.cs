using Manabind.Src.Gameplay.Entities;
using Manabind.Src.Gameplay.Entities.Tiles;
using Manabind.Src.UI.Enums;
using Manabind.Src.UI.Events;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Manabind.Src.UI.Components.BaseInstanceResources;
using Microsoft.Xna.Framework;
using Manabind.Src.Gameplay.Entities.Tile;

namespace Manabind.Src.Control.AppStates
{
    public class EditorAppState : AppState
    {
        #region Fields

        private Board board;
        private BaseTile highlightedTile;
        private BaseTile selectedTool;

        #endregion

        #region Constructors

        public EditorAppState()
        {
            this.board = new Board();

            this.EventResponses.Add(new EventResponse(new EventDetails("*", EventType.Click), "deselect-tool"));
            this.EventResponses.Add(new EventResponse(new EventDetails("toolbar", EventType.Select), "select-tool"));
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
                List<BaseTile> column = new List<BaseTile>();

                for (int y = 0; y < 6; y++)
                {
                    column.Add(new EmptyTile(x, y));
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

            if (selectedTool != null)
            {
                spriteBatch.Draw(selectedTool.Icon.DefaultTexture, new Vector2(0, 0), Color.White);
            }
        }

        protected override void ExecuteEventResponse(string action, object content)
        {
            switch (action)
            {
                case "deselect-tool":
                    selectedTool = null;
                    break;

                case "select-tool":
                    selectedTool = (BaseTile)content;
                    break;
            }
        }
    }
}
