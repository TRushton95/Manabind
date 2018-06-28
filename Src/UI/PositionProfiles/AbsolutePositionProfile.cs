using System;
using Microsoft.Xna.Framework;

namespace Manabind.Src.UI.PositionProfiles
{
    public class AbsolutePositionProfile : BasePositionProfile
    {
        #region Constructors

        public AbsolutePositionProfile()
        {
        }

        public AbsolutePositionProfile(int posX, int posY)
        {
            this.PosX = posX;
            this.PosY = posY;
        }

        #endregion

        #region Properties

        public int PosX
        {
            get;
            set;
        }

        public int PosY
        {
            get;
            set;
        }

        #endregion

        #region Methods

        // Parent and element aren't used here - shouldn't be in the method signature
        public override Vector2 GetCoordinates(Rectangle parent, Rectangle element)
        {
            return new Vector2(this.PosX, this.PosY);
        }

        #endregion
    }
}
