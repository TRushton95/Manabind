using Manabind.Src.Gameplay.Entities;
using Manabind.Src.Gameplay.Entities.Tiles;
using Manabind.Src.UI.Enums;
using Manabind.Src.UI.Events;
using Microsoft.Xna.Framework.Graphics;
using Manabind.Src.UI.Components.BaseInstanceResources;
using Microsoft.Xna.Framework;
using System;
using Newtonsoft.Json;
using System.IO;

namespace Manabind.Src.Control.AppStates
{
    public class EditorAppState : AppState
    {
        #region Fields

        private Camera camera;
        private Board board;
        private BaseTile highlightedTile;
        private BaseTile selectedTool;
        private string mapName;
        private string mapFileLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, AppSettings.MapFileLocation);

        #endregion

        #region Constructors

        public EditorAppState()
        {
            this.camera = new Camera(0, 0, AppSettings.WindowWidth, AppSettings.WindowHeight);
            this.board = new Board(10, 6);
            this.SetEventResponses();

            this.mapName = string.Empty;
        }

        #endregion

        #region Properties

        protected override string UIDefinitionFilename => AppSettings.EditorUIFileName;

        #endregion

        protected override void InitialiseState()
        {
            board.Generate();

            EventManager.PushEvent(
                new UIEvent(new EventDetails(this.Name, EventType.ChangeWidth), board.Width));

            EventManager.PushEvent(
                new UIEvent(new EventDetails(this.Name, EventType.ChangeHeight), board.Height));
        }

        protected override void UpdateState()
        {
            camera.Enable();

            if (this.Blocked)
            {
                camera.Disable();
            }

            camera.Update();

            Vector2 absoluteMousePosition = camera.GetAbsoluteMousePosition(new Vector2(MouseInfo.X, MouseInfo.Y));
            
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

                case "add-column":
                    board.AddColumn();
                    EventManager.PushEvent(
                        new UIEvent(new EventDetails(this.Name, EventType.ChangeWidth), board.Width));
                    break;

                case "remove-column":
                    board.RemoveColumn();
                    EventManager.PushEvent(
                        new UIEvent(new EventDetails(this.Name, EventType.ChangeWidth), board.Width));
                    break;

                case "add-row":
                    board.AddRow();
                    EventManager.PushEvent(
                        new UIEvent(new EventDetails(this.Name, EventType.ChangeHeight), board.Height));
                    break;

                case "remove-row":
                    board.RemoveRow();
                    EventManager.PushEvent(
                        new UIEvent(new EventDetails(this.Name, EventType.ChangeHeight), board.Height));
                    break;

                case "save-board":
                    this.SaveMap();

                    break;

                case "load-board":
                    break;

                case "reset-board":
                    int width = Int32.Parse(AppSettings.DefaultBoardWidth);
                    int height = Int32.Parse(AppSettings.DefaultBoardHeight);

                    board = new Board(width, height);
                    board.Generate();

                    EventManager.PushEvent(
                        new UIEvent(new EventDetails(this.Name, EventType.ChangeHeight), board.Height));
                    EventManager.PushEvent(
                        new UIEvent(new EventDetails(this.Name, EventType.ChangeWidth), board.Width));

                    break;

                case "change-map-name":
                    this.mapName = (string)content;

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
        
        private void SaveMap()
        {
            string json = JsonConvert.SerializeObject(board);

            using (StreamWriter file = new StreamWriter(Path.Combine(mapFileLocation, this.mapName)))
            {
                file.Write(json);
            }
        }

        private void SetEventResponses()
        {
            this.EventResponses.Add(new EventResponse(new EventDetails(EventManager.Wildcard, EventType.RightClick), "deselect-tool"));
            this.EventResponses.Add(new EventResponse(new EventDetails("toolbar", EventType.Select), "select-tool"));
            this.EventResponses.Add(new EventResponse(new EventDetails(EntityNames.Tile, EventType.LeftMouseDown), "set-tile"));

            this.EventResponses.Add(new EventResponse(new EventDetails("add-column-button", EventType.LeftClick), "add-column"));
            this.EventResponses.Add(new EventResponse(new EventDetails("remove-column-button", EventType.LeftClick), "remove-column"));
            this.EventResponses.Add(new EventResponse(new EventDetails("add-row-button", EventType.LeftClick), "add-row"));
            this.EventResponses.Add(new EventResponse(new EventDetails("remove-row-button", EventType.LeftClick), "remove-row"));

            this.EventResponses.Add(new EventResponse(new EventDetails("save-button-yes", EventType.LeftClick), "save-board"));
            this.EventResponses.Add(new EventResponse(new EventDetails("load-button", EventType.LeftClick), "load-board"));
            this.EventResponses.Add(new EventResponse(new EventDetails("reset-button", EventType.LeftClick), "reset-board"));
            

            this.EventResponses.Add(new EventResponse(new EventDetails("map-name-textbox", EventType.ChangeText), "change-map-name"));
        }
    }
}
