using Microsoft.Xna.Framework.Graphics;
using Manabind.Src.UI.PositionProfiles;
using Manabind.Src.UI.Components.Basic;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System.Xml.Serialization;
using Manabind.Src.UI.Factories;
using Manabind.Src.UI.Serialisation;

namespace Manabind.Src.UI.Components.Complex
{
    public class Container : BaseComplexComponent
    {
        #region Field

        private Frame frame;

        #endregion

        #region Constructors

        public Container()
            : base()
        {
            this.PositionProfile = new AbsolutePositionProfile();
            this.BackgroundColour = new Colour(0, 0, 0, 0);
            this.HoverBackgroundColour = new Colour(0, 0, 0, 0);
        }

        public Container(
            int width,
            int height,
            BasePositionProfile positionProfile,
            int priority,
            Colour backgroundColour,
            Colour hoverBackgroundColor)
            : base(width, height, positionProfile, priority)
        {
        }

        #endregion

        #region Properties

        public Colour BackgroundColour
        {
            get;
            set;
        }

        public Colour HoverBackgroundColour
        {
            get;
            set;
        }

        [XmlArrayItem(typeof(Container))]
        [XmlArrayItem(typeof(Button))]
        public List<BaseComplexComponent> Components
        {
            get;
            set;
        }

        #endregion

        #region Methods

        public override void Draw(SpriteBatch spriteBatch)
        {
            frame.Draw(spriteBatch);

            foreach (BaseComplexComponent component in Components)
            {
                if (component.Visible)
                {
                    component.Draw(spriteBatch);
                }
            }
        }

        public override void Initialise(Rectangle parent)
        {
            this.InitialiseCoordinates(parent);

            frame = new Frame(Width, Height, PositionProfileFactory.BuildCenteredRelative(), BackgroundColour, HoverBackgroundColour);
            frame.Initialise(this.GetBounds());

            foreach (BaseComplexComponent component in Components)
            {
                component.Initialise(this.GetBounds(), this.Priority);
            }
        }

        protected override void ClickDetail()
        {
            frame.Click();
        }

        protected override void HoverDetail()
        {
            frame.Hover();
        }

        protected override void HoverLeaveDetail()
        {
            frame.HoverLeave();
        }

        public override List<BaseComplexComponent> BuildTree()
        {
            List<BaseComplexComponent> result = new List<BaseComplexComponent> { this };

            List<BaseComplexComponent> total = new List<BaseComplexComponent>();
            foreach (BaseComplexComponent child in Components)
            {
                total = child.BuildTree();

                if (total.Count > 0)
                {
                    result.AddRange(total);
                }
            }

            return result;
        }

        #endregion
    }
}
