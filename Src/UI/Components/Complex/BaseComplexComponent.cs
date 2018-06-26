using Manabind.Src.UI.Components.Basic;
using Manabind.Src.UI.PositionProfiles;
using System.Collections.Generic;

namespace Manabind.Src.UI.Components.Complex
{
    public abstract class BaseComplexComponent : BaseComponent
    {
        #region Constructors

        public BaseComplexComponent()
            : base()
        {
        }

        public BaseComplexComponent(BasePositionProfile positionProfile)
            : base(positionProfile)
        {
        }

        #endregion

        #region Methods

        public abstract void OnClick();

        #endregion
    }
}
