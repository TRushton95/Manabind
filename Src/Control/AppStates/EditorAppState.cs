using Manabind.Src.Gameplay.Entities;
using Manabind.Src.Gameplay.Entities.Tiles;
using Manabind.Src.UI.Enums;
using Manabind.Src.UI.Events;
using Microsoft.Xna.Framework.Graphics;
using Manabind.Src.UI.Components.BaseInstanceResources;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Manabind.Src.Control.AppStates
{
    public class EditorAppState : AppState
    {
        #region Fields

        private Camera camera;
        private Board board;
        private BaseTile highlightedTile;
        private BaseTile selectedTool;

        #endregion

        #region Constructors

        public EditorAppState()
        {
            this.camera = new Camera(0, 0, AppSettings.WindowWidth, AppSettings.WindowHeight);
            this.board = new Board(10, 6);
            this.SetEventResponses();
        }

        public EditorAppState(MouseState currentMouseState, MouseState prevMouseState)
            : base(currentMouseState, prevMouseState)
        {
            this.camera = new Camera(0, 0, AppSettings.WindowWidth, AppSettings.WindowHeight);
            this.board = new Board(10, 6);
            this.SetEventResponses();
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
            camera.Update();

            Vector2 absoluteMousePosition = camera.GetAbsoluteMousePosition(new Vector2(currentMouseState.X, currentMouseState.Y));
            
            board.Update(absoluteMousePosition, !uiInteracted);
        }

        protected override void DrawState(SpriteBatch spriteBatch)
        {
            camera.Draw(board, spriteBatch);

            if (highlightedTile != null)
            {
                spriteBatch.Draw(Textures.TileHover, board.GetTileCanvasPos(highlightedTile), Color.White);
            }

            if (selectedTool != null)
            {
                spriteBatch.Draw(Textures.TileIconHover, selectedTool.Icon.GetBounds(), Color.White);
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
                    SetTile((BaseTile)content);
                    break;
            }
        }

        private void SetTile(BaseTile clickedTile)
        {
            if (selectedTool == null)
            {
                return;
            }

            if (clickedTile.TileType != selectedTool.TileType)
            {
                board.SetTileAtCoords(clickedTile.PosX, clickedTile.PosY, selectedTool.TileType);
            }
        }

        private void SetEventResponses()
        {
            this.EventResponses.Add(new EventResponse(new EventDetails(EventManager.Wildcard, EventType.RightClick), "deselect-tool"));
            this.EventResponses.Add(new EventResponse(new EventDetails("toolbar", EventType.Select), "select-tool"));
            this.EventResponses.Add(new EventResponse(new EventDetails(EntityNames.Tile, EventType.LeftMouseDown), "set-tile"));
        }
    }
}
