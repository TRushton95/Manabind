using Microsoft.Xna.Framework;

namespace Manabind.Src.UI.PositionProfiles
{
    public interface IPositionProfile
    {
        Vector2 GetCoordinates(Rectangle parent, Rectangle element);
    }
}
