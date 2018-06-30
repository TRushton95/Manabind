using Manabind.Src.UI.Components.Basic;
using Manabind.Src.UI.PositionProfiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Manabind.Src.UI.Enums;
using Manabind.Src.UI.Components.BaseInstanceResources;
using Manabind.Src.UI.Factories;
using Manabind.Src.UI.Serialisation;

namespace Manabind.Src.UI.Components.Complex
{
    public class Button : BaseComplexComponent
    {
        #region Fields

        private Frame frame;

        #endregion

        #region Constructors

        public Button()
            : base()
        {
            this.PositionProfile = new AbsolutePositionProfile();
            this.TextColour = new Colour(0, 0, 0, 0);
            this.HoverTextColour = new Colour(0, 0, 0, 0);
            this.BackgroundColour = new Colour(0, 0, 0, 0);
            this.HoverBackgroundColour = new Colour(0, 0, 0, 0);
        }

        public Button(
            int width,
            int height, 
            string text, 
            BasePositionProfile positionProfile,
            int priority,
            Colour textColour,
            Colour hoverTextColour,
            Colour backgroundColour,
            Colour hoverBackgroundColour)
            : base(width, height, positionProfile, priority)
        {
        }

        #endregion

        public string Text
        {
            get;
            set;
        }

        public Colour TextColour
        {
            get;
            set;
        }

        public Colour HoverTextColour
        {
            get;
            set;
        }

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

        #region Methods

        public override void Draw(SpriteBatch spriteBatch)
        {
            frame.Draw(spriteBatch);
        }

        public override void Initialise(Rectangle parent)
        {
            this.InitialiseCoordinates(parent);

            TextBox textBox = new TextBox(Text, Width, 20, PositionProfileFactory.BuildCenteredRelative(),
                                            FontFlow.Shrink, TextColour, HoverTextColour, Textures.ButtonFont);

            frame = new Frame(Width, Height, PositionProfileFactory.BuildCenteredRelative(), BackgroundColour, HoverBackgroundColour);
            frame.Components.Add(textBox);

            frame.Initialise(this.GetBounds());
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

        #endregion
    }
}
