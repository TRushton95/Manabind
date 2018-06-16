using Microsoft.Xna.Framework;

namespace Manabind.Src.UI.PositionProfiles
{
    public abstract class BasePositionProfile : IPositionProfile
    {
        public abstract Vector2 GetCoordinates(Rectangle parent, Rectangle element);
    }
}
