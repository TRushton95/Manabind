﻿using Manabind.Src.Control.Services;
using Manabind.Src.Gameplay;
using Manabind.Src.Gameplay.Abilities;
using Manabind.Src.Gameplay.Entities;
using Manabind.Src.Gameplay.Entities.Tiles;
using Manabind.Src.Gameplay.PlayerStates;
using Manabind.Src.Gameplay.Templates;
using Manabind.Src.UI.Components.BaseInstanceResources;
using Manabind.Src.UI.Enums;
using Manabind.Src.UI.Events;
using Manabind.Src.UI.Factories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Manabind.Src.Control.AppStates
{
    partial class PlayAppState : AppState
    {
        #region Fields

        private Camera camera;
        private Board board;
        private BaseTile highlightedTile;
        private Unit selectedUnit, hoveredUnit;
        private Ability selectedAbility;
        private IPlayerState playerState;
        private const string MapName = "rogg";

        private int team = 1;

        public Unit p1, p2;

        #endregion

        #region Constructors

        public PlayAppState()
        {
            this.camera = new Camera(0, 0, AppSettings.WindowWidth, AppSettings.WindowHeight);
            this.board = MapIO.LoadMap(MapName);

            this.SetEventResponses();

            this.StartGame();
        }

        #endregion

        #region Properties

        protected override string UIDefinitionFilename => AppSettings.PlayUIFileName;

        #endregion

        #region Methods

        public void StartGame()
        {
            p1 = UnitFactory.BuildUnit(1, 100, 100, 0, 0);
            p1.Abilities.Add(new Ability()
            {
                Template = new AreaAffectTemplate(2),
                Icon = IconFactory.BuildFireballIcon()
            });

            p2 = UnitFactory.BuildUnit(2, 150, 50, 5, 5);

            board.SpawnUnit(p1);
            board.SpawnUnit(p2);

            playerState = new UnselectedPlayerState(team);
        }

        protected override void InitialiseState()
        {
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

            if (selectedAbility != null)
            {
                spriteBatch.Draw(Textures.IconHover, camera.GetAbsoluteEntityPosition(selectedAbility.Icon.GetCoordinates()), Color.White);
            }

            if (hoveredUnit != null)
            {

                spriteBatch.Draw(Textures.UnitHover, camera.GetAbsoluteEntityPosition(hoveredUnit.GetCoordinates()), Color.White);
            }

            if (selectedUnit != null)
            {
                spriteBatch.Draw(Textures.UnitSelect, camera.GetAbsoluteEntityPosition(selectedUnit.GetCoordinates()), Color.White);
            }
        }

        protected override void ExecuteEventResponse(string action, object content)
        {
            base.ExecuteEventResponse(action, content);

            switch (action)
            {
                case "tile-click":
                    BaseTile tile = (BaseTile)content;
                    TileClick(tile);
                    break;

                case "unit-selected":
                    selectedUnit = (Unit)content;
                    UnitSelected(selectedUnit);
                    break;

                case "ability-selected":
                    selectedAbility = (Ability)content;

                    EventManager.PushEvent(
                        new UIEvent(new EventDetails(this.Name, EventType.TemplateSelected), selectedAbility?.Template));
                    break;

                case "unit-hover":
                    hoveredUnit = (Unit)content;
                    break;

                case "unit-hover-leave":
                    hoveredUnit = null;
                    break;

                case "refresh-tree":
                    EventManager.Subscribe(board); //really dodgy way of handling this

                    break;
            }
        }

        private void SetEventResponses()
        {
            this.EventResponses.Add(new EventResponse(new EventDetails(EntityNames.Tile, EventType.LeftClick), "tile-click"));
            this.EventResponses.Add(new EventResponse(new EventDetails(EntityNames.Unit, EventType.Hover), "unit-hover"));
            this.EventResponses.Add(new EventResponse(new EventDetails(EntityNames.Unit, EventType.HoverLeave), "unit-hover-leave"));
            this.EventResponses.Add(new EventResponse(new EventDetails("player-state", EventType.UnitSelected), "unit-selected"));
            this.EventResponses.Add(new EventResponse(new EventDetails("toolbar", EventType.Select), "ability-selected"));
            this.EventResponses.Add(new EventResponse(new EventDetails("toolbar", EventType.Deselect), "ability-selected"));
        }

        #endregion
    }
}
