using Manabind.Src.Gameplay.Entities;
using Manabind.Src.Gameplay.Entities.Tiles;
using Manabind.Src.UI.Enums;
using Manabind.Src.UI.Events;
using Microsoft.Xna.Framework.Graphics;
using Manabind.Src.UI.Components.BaseInstanceResources;
using Microsoft.Xna.Framework;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Manabind.Src.UI.Components.Complex.ListItems;
using Manabind.Src.Control.Services;

namespace Manabind.Src.Control.AppStates
{
    public class EditorAppState : AppState
    {
        #region Fields

        private Camera camera;
        private Board board;
        private BaseTile highlightedTile;
        private BaseTile selectedTool;
        private int mapIndex, availableMapSlots, occupiedMapSlots;
        private string mapName;
        private string selectedMap;
        private List<string> savedMaps;

        #endregion

        #region Constructors

        public EditorAppState()
        {
            this.camera = new Camera(0, 0, AppSettings.WindowWidth, AppSettings.WindowHeight);
            this.board = new Board(10, 6);
            this.SetEventResponses();

            this.mapIndex = 0;
            this.availableMapSlots = 4;
            this.mapName = string.Empty;
            this.selectedMap = string.Empty;
            this.savedMaps = Directory.EnumerateFiles(AppSettings.MapDirectoryPath)
                                .Select(file => Path.GetFileNameWithoutExtension(file))
                                .ToList();
            this.occupiedMapSlots = savedMaps.Count() > availableMapSlots ? availableMapSlots : savedMaps.Count();

            this.InitialiseLoadList();
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
        }

        protected override void ExecuteEventResponse(string action, object content)
        {
            base.ExecuteEventResponse(action, content);

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
                    MapIO.SaveMap(board, mapName);
                    EventManager.PushEvent(
                        new UIEvent(new EventDetails(this.Name, EventType.MapSaved), null));
                    break;

                case "load-board":
                    Board result = MapIO.LoadMap(this.selectedMap);

                    this.board = result;
                    this.mapName = board.Name;

                    this.camera.Reset();
                    EventManager.PushEvent(
                        new UIEvent(new EventDetails(this.Name, EventType.MapLoaded), null));
                    break;

                case "change-map-name":
                    this.mapName = (string)content;
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

                case "scroll-up-file":
                    ScrollUpMap();
                    break;

                case "scroll-down-file":
                    ScrollDownMap();

                    break;

                case "select-file":
                    this.selectedMap = ((TextboxListItem)content).Text;

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

        private void InitialiseLoadList()
        {
            int currentIndex = 0;

            List<string> mapsToDisplay = new List<string>();

            for (int i = 0; i < occupiedMapSlots; i++)
            {
                mapsToDisplay.Add(savedMaps[currentIndex]);

                if (currentIndex > savedMaps.Count - 1)
                {
                    currentIndex = 0;
                }
                else
                {
                    currentIndex++;
                }
            }

            EventManager.PushEvent(
                new UIEvent(new EventDetails(this.Name, EventType.ScrollLoadFiles), mapsToDisplay));
        }
        
        private void ScrollUpMap()
        {
            if (occupiedMapSlots < availableMapSlots)
            {
                return;
            }

            mapIndex--;
            if (mapIndex < 0)
            {
                mapIndex = 0;
            }

            int currentIndex = mapIndex;

            List<string> mapsToDisplay = new List<string>();

            for (int i = 0; i < availableMapSlots; i++)
            {
                mapsToDisplay.Add(savedMaps[currentIndex]);
                currentIndex = WrapIndex(currentIndex + 1);
            }

            EventManager.PushEvent(
                new UIEvent(new EventDetails(this.Name, EventType.ScrollLoadFiles), mapsToDisplay));
        }

        private void ScrollDownMap()
        {
            if (occupiedMapSlots < availableMapSlots)
            {
                return;
            }

            mapIndex++;
            if (mapIndex + availableMapSlots > savedMaps.Count())
            {
                mapIndex = savedMaps.Count() - availableMapSlots;
            }

            int currentIndex = mapIndex;

            List<string> mapsToDisplay = new List<string>();

            for (int i = 0; i < availableMapSlots; i++)
            {
                mapsToDisplay.Add(savedMaps[currentIndex]);
                currentIndex = WrapIndex(currentIndex + 1);
            }

            EventManager.PushEvent(
                new UIEvent(new EventDetails(this.Name, EventType.ScrollLoadFiles), mapsToDisplay));
        }

        private int WrapIndex(int i)
        {
            if (i < 0)
            {
                i = savedMaps.Count - 1;
            }
            else if (i > savedMaps.Count - 1)
            {
                i = 0;
            }

            return i;
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

            this.EventResponses.Add(new EventResponse(new EventDetails("reset-button", EventType.LeftClick), "reset-board"));
            
            this.EventResponses.Add(new EventResponse(new EventDetails("save-button-yes", EventType.LeftClick), "save-board"));
            this.EventResponses.Add(new EventResponse(new EventDetails("load-button-yes", EventType.LeftClick), "load-board"));

            this.EventResponses.Add(new EventResponse(new EventDetails("map-name-textbox", EventType.ChangeText), "change-map-name"));
            
            this.EventResponses.Add(new EventResponse(new EventDetails("page-up-button", EventType.LeftClick), "scroll-up-file"));
            this.EventResponses.Add(new EventResponse(new EventDetails("page-down-button", EventType.LeftClick), "scroll-down-file"));

            this.EventResponses.Add(new EventResponse(new EventDetails("load-file-1", EventType.LeftClick), "select-file"));
            this.EventResponses.Add(new EventResponse(new EventDetails("load-file-2", EventType.LeftClick), "select-file"));
            this.EventResponses.Add(new EventResponse(new EventDetails("load-file-3", EventType.LeftClick), "select-file"));
            this.EventResponses.Add(new EventResponse(new EventDetails("load-file-4", EventType.LeftClick), "select-file"));
        }
    }
}
