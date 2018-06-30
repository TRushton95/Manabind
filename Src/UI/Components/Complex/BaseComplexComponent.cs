using Manabind.Src.UI.Components.Basic;
using Manabind.Src.UI.PositionProfiles;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Manabind.Src.UI.Components.Complex
{
    public abstract class BaseComplexComponent : BaseComponent
    {
        #region Constructors

        public BaseComplexComponent()
        {
            this.Priority = 0;
            this.Interactive = true;
        }

        public BaseComplexComponent(int width, int height, BasePositionProfile positionProfile, int priority)
            : base(positionProfile)
        {
            this.Priority = priority;
            this.Interactive = true;
        }

        #endregion

        #region Properties

        public int Priority
        {
            get;
            set;
        }

        public bool Interactive
        {
            get;
            set;
        }

        #endregion

        #region Methods

        public void Initialise(Rectangle parent, int parentPriority)
        {
            this.Priority = parentPriority + 1;

            this.Initialise(parent);
        }

        public virtual List<BaseComplexComponent> BuildTree()
        {
            return new List<BaseComplexComponent> { this };
        }

        #endregion
    }
}
