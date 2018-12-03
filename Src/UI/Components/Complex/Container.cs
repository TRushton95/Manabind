using Microsoft.Xna.Framework.Graphics;
using Manabind.Src.UI.PositionProfiles;
using Manabind.Src.UI.Components.Basic;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Manabind.Src.UI.Factories;
using Manabind.Src.UI.Serialisation;
using System.Xml.Serialization;
using Manabind.Src.UI.Components.Complex.ListItems;

namespace Manabind.Src.UI.Components.Complex
{
    public class Container : BaseComplexComponent
    {
        #region Field

        private Frame frame, defaultFrame, hoverFrame;

        #endregion

        #region Constructors

        public Container()
            : base()
        {
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
        [XmlArrayItem(typeof(Heading))]
        [XmlArrayItem(typeof(Toolbar))]
        [XmlArrayItem(typeof(Textbox))]
        [XmlArrayItem(typeof(TextboxListItem))]
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
            this.BuildComponents();
        }

        public override void Refresh()
        {
            this.BuildComponents();
        }

        protected override void LeftClickDetail()
        {
        }

        protected override void RightClickDetail()
        {
        }

        protected override void LeftMouseDownDetail()
        {
        }

        protected override void HoverDetail()
        {
            this.frame = this.hoverFrame;
        }

        protected override void HoverLeaveDetail()
        {
            this.frame = this.defaultFrame;
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

        private void BuildComponents()
        {
            defaultFrame = new Frame(Width, Height, PositionProfileFactory.BuildCenteredRelative(), BackgroundColour);
            defaultFrame.Initialise(this.GetBounds());

            hoverFrame = new Frame(Width, Height, PositionProfileFactory.BuildCenteredRelative(), HoverBackgroundColour);
            hoverFrame.Initialise(this.GetBounds());

            this.frame = this.defaultFrame;

            foreach (BaseComplexComponent component in Components)
            {
                component.Initialise(this.GetBounds(), this.Id, this.Priority);
            }
        }

        #endregion
    }
}
