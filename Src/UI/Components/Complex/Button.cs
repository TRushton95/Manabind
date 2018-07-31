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

        private Frame frame, defaultFrame, hoverFrame;
        private FontGraphics defaultFontGraphics, hoverFontGraphics;

        #endregion

        #region Constructors

        public Button()
            : base()
        {
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

        #region Properties

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

        #endregion

        #region Methods

        public override void Draw(SpriteBatch spriteBatch)
        {
            frame.Draw(spriteBatch);
        }

        public override void Initialise(Rectangle parent)
        {
            this.InitialiseCoordinates(parent);

            // default textures
            defaultFrame = new Frame(Width, Height, PositionProfileFactory.BuildCenteredRelative(), BackgroundColour);
            defaultFontGraphics = new FontGraphics(Text, Width, 20, PositionProfileFactory.BuildCenteredRelative(),
                                            FontFlow.Shrink, TextColour, Textures.ButtonFont);
            defaultFrame.Components.Add(defaultFontGraphics);
            defaultFrame.Initialise(this.GetBounds());

            // hover textures
            hoverFrame = new Frame(Width, Height, PositionProfileFactory.BuildCenteredRelative(), HoverBackgroundColour);
            hoverFontGraphics = new FontGraphics(Text, Width, 20, PositionProfileFactory.BuildCenteredRelative(),
                                            FontFlow.Shrink, HoverTextColour, Textures.ButtonFont);
            hoverFrame.Components.Add(hoverFontGraphics);
            hoverFrame.Initialise(this.GetBounds());
            
            this.frame = this.defaultFrame;
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

        #endregion
    }
}
