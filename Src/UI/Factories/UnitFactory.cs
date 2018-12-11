using Manabind.Src.Gameplay;
using Manabind.Src.Gameplay.Entities.Tiles;
using Manabind.Src.UI.Components.BaseInstanceResources;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Manabind.Src.UI.Factories
{
    public class UnitFactory : BaseInstance
    {
        public static Unit BuildUnit(int team, int maxHealth, int maxEnergy, int x, int y)
        {
            Vector2 canvas = GetCanvasCoords(x, y);
            int canvasX = (int)canvas.X;
            int canvasY = (int)canvas.Y;

            Texture2D texture = null;

            //TODO find a better way to assign textures here - though this might be right
            //Just refer to them as PlayerOne instead of ally
            switch (team)
            {
                case 1:
                    texture = Textures.AllyUnit;
                    break;

                case 2:
                    texture = Textures.EnemyUnit;
                    break;
            }

            Unit result = new Unit(team, maxHealth, maxEnergy, x, y, canvasX, canvasY, texture);

            return result;
        }

        private static Vector2 GetCanvasCoords(int x, int y)
        {
            bool oddRow = y % 2 == 1;

            int unitOffset = (BaseTile.Diameter / 2) - (Unit.Diameter / 2);

            int canvasX = x * BaseTile.Diameter + (oddRow ? BaseTile.Diameter / 2 : 0) + unitOffset;
            int canvasY = y * (int)(BaseTile.Diameter * 0.75) + unitOffset;

            return new Vector2(canvasX, canvasY);
        }
    }
}
