using System;
using Manabind.Src.UI.Components.Basic;
using Manabind.Src.UI.PositionProfiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Manabind.Src.UI.Enums;
using Manabind.Src.UI.Components.BaseInstanceResources;

namespace Manabind.Src.UI.Components.Complex
{
    public class Button : BaseComplexComponent
    {
        #region Fields

        private Frame frame;
        private TextBox textBox;

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
            Color textColour,
            Color hoverTextColour,
            Color backgroundColour,
            Color hoverBackgroundColour)
            : base(width, height, positionProfile)
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
            textBox.Draw(spriteBatch);
        }

        public override void Initialise()
        {
            frame = new Frame(Width, Height, PositionProfile, BackgroundColour, HoverBackgroundColour);
            frame.Initialise();

            textBox = new TextBox(Text, Width, 20, PositionProfile, FontFlow.Shrink, TextColour, HoverTextColour, Textures.ButtonFont);
            textBox.Initialise();
        }

        public override void OnHover()
        {
            frame.OnHover();
            textBox.OnHover();
        }
        public override void OnHoverLeave()
        {
            frame.OnHoverLeave();
            textBox.OnHoverLeave();
        }

        #endregion
    }
}
