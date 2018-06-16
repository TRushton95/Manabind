using Manabind.Src.UI.Enums;
using Microsoft.Xna.Framework;

namespace Manabind.Src.UI.PositionProfiles
{
    public class RelativePositionProfile : BasePositionProfile
    {
        #region Constructors

        public RelativePositionProfile()
        {
        }

        public RelativePositionProfile(HorizontalAlign horizontalAlign, VerticalAlign verticalAlign, int offsetX, int offsetY)
        {
            this.HorizontalAlign = horizontalAlign;
            this.VerticalAlign = verticalAlign;
            this.OffsetX = offsetX;
            this.OffsetY = offsetY;
        }

        #endregion

        #region Properties

        public HorizontalAlign HorizontalAlign
        {
            get;
            set;
        }

        public VerticalAlign VerticalAlign
        {
            get;
            set;
        }

        public int OffsetX
        {
            get;
            set;
        }

        public int OffsetY
        {
            get;
            set;
        }

        #endregion

        #region Methods

        public override Vector2 GetCoordinates(Rectangle parent, Rectangle element)
        {
            int resultX = parent.X + OffsetX;

            switch (HorizontalAlign)
            {
                case HorizontalAlign.Left:
                    break;

                case HorizontalAlign.Middle:
                    resultX += (parent.Width / 2) - (element.Width / 2);
                    break;

                case HorizontalAlign.Right:
                    resultX += parent.Width - element.Width;
                    break;
            }

            int resultY = parent.Y + OffsetY;

            switch (VerticalAlign)
            {
                case VerticalAlign.Top:
                    break;

                case VerticalAlign.Middle:
                    resultY += (parent.Height / 2) - (element.Height / 2);
                    break;

                case VerticalAlign.Bottom:
                    resultY += parent.Height - element.Height;
                    break;
            }

            return new Vector2(resultX, resultY);
        }

        #endregion
    }
}
