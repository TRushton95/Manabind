using Manabind.Src.Gameplay.Entities.Tile;
using Manabind.Src.Gameplay.Entities.Tiles;
using Manabind.Src.UI.Components.BaseInstanceResources;
using Manabind.Src.UI.Enums;
using Microsoft.Xna.Framework;

namespace Manabind.Src.UI.Factories
{
    public class TileFactory : BaseInstance
    {
        public static BaseTile BuildTile(int x, int y, TileType tileType)
        {
            BaseTile result = null;

            Vector2 canvas = GetCanvasCoords(x, y);
            int canvasX = (int)canvas.X;
            int canvasY = (int)canvas.Y;

            switch (tileType)
            {
                case TileType.Empty:
                    result = new EmptyTile(x, y, canvasX, canvasY);
                    break;

                case TileType.Ground:
                    result = new GroundTile(x, y, canvasX, canvasY);
                    break;
            }

            return result;
        }

        private static Vector2 GetCanvasCoords(int x, int y)
        {
            bool oddRow = y % 2 == 1;

            int canvasX = x * BaseTile.Diameter + (oddRow ? BaseTile.Diameter / 2 : 0);
            int canvasY = y * (int)(BaseTile.Diameter * 0.75);

            return new Vector2(canvasX, canvasY);
        }
    }
}
