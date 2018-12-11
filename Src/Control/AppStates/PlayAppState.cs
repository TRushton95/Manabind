using Manabind.Src.Control.Services;
using Manabind.Src.Gameplay;
using Manabind.Src.Gameplay.Abilities;
using Manabind.Src.Gameplay.Entities;
using Manabind.Src.Gameplay.Entities.Tiles;
using Manabind.Src.UI.Components.BaseInstanceResources;
using Manabind.Src.UI.Factories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Manabind.Src.Control.AppStates
{
    public class PlayAppState : AppState
    {
        #region Fields

        private Camera camera;
        private Board board;
        private BaseTile highlightedTile;
        private Ability selectedTool;
        private const string MapName = "rogg";

        public Unit p1, p2;

        #endregion

        #region Constructors

        public PlayAppState()
        {
            this.camera = new Camera(0, 0, AppSettings.WindowWidth, AppSettings.WindowHeight);
            this.board = MapIO.LoadMap(MapName);
            
            p1 = UnitFactory.BuildUnit(1, 100, 100, 0, 0);
            p2 = UnitFactory.BuildUnit(2, 150, 50, 5, 5);

            board.SpawnUnit(p1);
            board.SpawnUnit(p2);

            componentManager.LoadUI(AppSettings.PlayUIFileName);
        }

        #endregion

        #region Properties

        protected override string UIDefinitionFilename => AppSettings.PlayUIFileName;

        #endregion

        #region Methods

        public void StartGame(string map, int players)
        {
            
        }

        protected override void InitialiseState()
        {
            board.Generate();
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

        #endregion
    }
}
