using Manabind.Src.Gameplay.Entities;
using Manabind.Src.UI.Enums;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Manabind.Src.Control.AppStates
{
    public class EditorAppState : AppState
    {
        #region Fields

        private Board board;
        private Texture2D tileTexture;

        #endregion

        #region Constructors

        public EditorAppState()
        {
            board = new Board();
        }

        #endregion

        #region Properties

        protected override string UIDefinitionFilename => AppSettings.EditorUIFileName;

        #endregion

        protected override void InitialiseState()
        {
            tileTexture = Content.Load<Texture2D>("GroundTile");

            for (int y = 0; y < 5; y++)
            {
                List<Tile> row = new List<Tile>();

                for (int x = 0; x < 10; x++)
                {
                    row.Add(new Tile(x, y, TileType.Ground, tileTexture));
                }

                board.Tiles.Add(row);
            }
        }

        protected override void UpdateState()
        {

        }

        protected override void DrawState(SpriteBatch spriteBatch)
        {
            board.Draw(spriteBatch);
        }
    }
}
