using System;
using Manabind.Src.UI.Components.Basic;
using Manabind.Src.UI.PositionProfiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Manabind.Src.UI.Enums;
using Manabind.Src.UI.Components.BaseInstanceResources;
using Manabind.Src.UI.Factories;

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
        }

        public Button(
            int width,
            int height, 
            string text, 
            BasePositionProfile positionProfile,
            int priority,
            Color textColour,
            Color hoverTextColour,
            Color backgroundColour,
            Color hoverBackgroundColour)
            : base(width, height, positionProfile, priority)
        {
        }

        #endregion

        public string Text
        {
            get;
            set;
        }

        public Color TextColour
        {
            get;
            set;
        }

        public Color HoverTextColour
        {
            get;
            set;
        }

        public Color BackgroundColour
        {
            get;
            set;
        }

        public Color HoverBackgroundColour
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

        public override void OnHover()
        {
            frame.OnHover();
        }
        public override void OnHoverLeave()
        {
            frame.OnHoverLeave();
        }

        #endregion
    }
}
