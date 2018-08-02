using Manabind.Src.UI.Components.Basic;
using Manabind.Src.UI.Enums;
using Manabind.Src.UI.Factories;
using Manabind.Src.UI.PositionProfiles;
using Manabind.Src.UI.Serialisation;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Manabind.Src.UI.Components.BaseInstanceResources;
using Manabind.Src.UI.Events;

namespace Manabind.Src.UI.Components.Complex
{
    public class Textbox : BaseComplexComponent
    {
        #region Fields

        private bool focus;
        private Frame frame, defaultFrame, hoverFrame, focusFrame;
        private FontGraphics defaultFontGraphics, hoverFontGraphics, focusFontGraphics;

        #endregion

        #region Constructors

        public Textbox()
            : base()
        {
            this.EventResponses.Add(
                new EventResponse(new EventDetails(EventManager.Wildcard, EventType.LeftClick), "unfocus"));

            this.EventResponses.Add(
                new EventResponse(new EventDetails("keyboard", EventType.KeyPress), "edit-text"));
        }

        public Textbox(
            int width,
            int height,
            string text,
            BasePositionProfile positionProfile,
            int priority,
            Colour textColour,
            Colour hoverTextColour,
            Colour focusTextColour,
            Colour backgroundColour,
            Colour hoverBackgroundColour,
            Colour focusBackgroundColour)
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

        public Colour FocusTextColour
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

        public Colour FocusBackgroundColour
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
            this.BuildComponents();
        }

        public override void Refresh()
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

        protected override void LeftClickDetail()
        {
            this.focus = true;
            this.frame = this.focusFrame;
        }

        protected override void LeftMouseDownDetail()
        {
        }

        protected override void RightClickDetail()
        {
        }

        protected override void ExecuteEventResponse(string action, object content)
        {
            switch (action)
            {
                case "unfocus":
                    this.focus = false;
                    this.frame = this.defaultFrame;
                    break;

                case "edit-text":
                    if (focus)
                    {
                        this.Text = content.ToString();
                        this.Refresh();
                    }
                    break;
            }
        }

        private void BuildComponents()
        {
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

            //focus textures
            focusFrame = new Frame(Width, Height, PositionProfileFactory.BuildCenteredRelative(), FocusBackgroundColour);
            focusFontGraphics = new FontGraphics(Text, Width, 20, PositionProfileFactory.BuildCenteredRelative(),
                                            FontFlow.Shrink, FocusTextColour, Textures.ButtonFont);
            focusFrame.Components.Add(focusFontGraphics);
            focusFrame.Initialise(this.GetBounds());

            this.frame = this.defaultFrame;
        }

        #endregion
    }
}
