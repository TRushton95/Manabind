using Manabind.Src.UI.Enums;
using Manabind.Src.UI.PositionProfiles;

namespace Manabind.Src.UI.Factories
{
    public static class PositionProfileFactory
    {
        public static RelativePositionProfile BuildCenteredRelative()
        {
            return new RelativePositionProfile(HorizontalAlign.Middle, VerticalAlign.Middle, 0, 0);
        }

        public static RelativePositionProfile BuildLeftRelative()
        {
            return new RelativePositionProfile(HorizontalAlign.Left, VerticalAlign.Middle, 0, 0);
        }
    }
}
