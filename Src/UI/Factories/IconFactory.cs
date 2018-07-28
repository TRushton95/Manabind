using Manabind.Src.UI.Components.Complex;
using Microsoft.Xna.Framework.Graphics;
using Manabind.Src.UI.Components.BaseInstanceResources;

namespace Manabind.Src.UI.Factories
{
    public class IconFactory : BaseInstance
    {
        public static Icon BuildIcon(Texture2D texture)
        {
            return new Icon(Icon.Diameter, Icon.Diameter, PositionProfileFactory.BuildCenteredRelative(), 0, texture, texture);
        }

        public static Icon BuildGroundTileIcon()
        {
            return BuildIcon(Textures.GroundTileIcon);
        }

        public static Icon BuildEmptyTileIcon()
        {
            return BuildIcon(Textures.EmptyTileIcon);
        }
    }
}
