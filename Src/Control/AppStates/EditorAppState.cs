using Manabind.Src.Gameplay.Entities;
using Manabind.Src.Gameplay.Entities.Tiles;
using Manabind.Src.UI.Enums;
using Manabind.Src.UI.Events;
using Microsoft.Xna.Framework.Graphics;
using Manabind.Src.UI.Components.BaseInstanceResources;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
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
            this.board = new Board(10, 6);

            this.EventResponses.Add(new EventResponse(new EventDetails("*", EventType.RightClick), "deselect-tool"));
            this.EventResponses.Add(new EventResponse(new EventDetails("toolbar", EventType.Select), "select-tool"));
            this.EventResponses.Add(new EventResponse(new EventDetails(EntityNames.Tile, EventType.LeftClick), "set-tile"));
        }

        public EditorAppState(MouseState currentMouseState, MouseState prevMouseState)
            : base(currentMouseState, prevMouseState)
        {
            this.board = new Board(10, 6);

            this.EventResponses.Add(new EventResponse(new EventDetails("*", EventType.RightClick), "deselect-tool"));
            this.EventResponses.Add(new EventResponse(new EventDetails("toolbar", EventType.Select), "select-tool"));
            this.EventResponses.Add(new EventResponse(new EventDetails(EntityNames.Tile, EventType.LeftClick), "set-tile"));
        }

        #endregion

        #region Properties

        protected override string UIDefinitionFilename => AppSettings.EditorUIFileName;

        #endregion

        protected override void InitialiseState()
        {
            board.Generate();
        }

        protected override void UpdateState()
        {
            if (uiInteracted)
            {
                return;
            }

            highlightedTile = board.GetTileAtMouse(currentMouseState.X, currentMouseState.Y);

            if (highlightedTile != null && this.LeftMouseClicked)
            {
                highlightedTile.Click();
            }
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

                case "set-tile":

                    if (selectedTool == null)
                    {
                        return;
                    }

                    Vector2 tileCoords = new Vector2(((BaseTile)content).PosX, ((BaseTile)content).PosY);

                    board.SetTileAtCoords((int)tileCoords.X, (int)tileCoords.Y, selectedTool.TileType);
                    break;
            }
        }
    }
}
