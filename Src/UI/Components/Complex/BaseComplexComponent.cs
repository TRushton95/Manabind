using Manabind.Src.UI.Components.Basic;
using Manabind.Src.UI.PositionProfiles;

namespace Manabind.Src.UI.Components.Complex
{
    public abstract class BaseComplexComponent : BaseComponent
    {
        #region Constructors

        public BaseComplexComponent()
        {
        }

        public BaseComplexComponent(int width, int height, BasePositionProfile positionProfile)
            : base(positionProfile)
        {
        }

        #endregion

        #region Methods

        public abstract void OnHover();

        public abstract void OnHoverLeave();

        #endregion
    }
}
