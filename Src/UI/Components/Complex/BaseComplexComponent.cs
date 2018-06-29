using Manabind.Src.UI.Components.Basic;
using Manabind.Src.UI.PositionProfiles;
using System.Collections.Generic;

namespace Manabind.Src.UI.Components.Complex
{
    public abstract class BaseComplexComponent : BaseComponent
    {
        #region Constructors

        public BaseComplexComponent()
        {
        }

        public BaseComplexComponent(int width, int height, BasePositionProfile positionProfile, int priority)
            : base(positionProfile)
        {
            this.Priority = priority;
        }

        #endregion

        #region Properties

        public int Priority
        {
            get;
            set;
        }

        #endregion

        #region Methods

        public virtual List<BaseComplexComponent> BuildTree()
        {
            return new List<BaseComplexComponent> { this };
        }

        #endregion
    }
}
