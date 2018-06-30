using System;
using Manabind.Src.UI.Enums;
using Manabind.Src.UI.PositionProfiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Text;
using Manabind.Src.UI.Serialisation;

namespace Manabind.Src.UI.Components.Basic
{
    public class TextBox : BaseComponent
    {
        #region Fields
        
        private string text, displayText;
        private SpriteFont font;
        private Colour colour, defaultColour, hoverColour;
        private float scale;
        private int maxWidth;
        private FontFlow fontFlow;

        #endregion

        #region Constructors

        public TextBox()
        {
        }

        public TextBox(string text, int maxWidth, int gutter, BasePositionProfile positionProfile, 
                        FontFlow fontFlow, Colour defaultColour, Colour hoverColour, SpriteFont font)
            : base(positionProfile)
        {
            this.text = text;
            this.displayText = text;
            this.maxWidth = maxWidth;
            this.fontFlow = fontFlow;
            this.defaultColour = defaultColour;
            this.hoverColour = hoverColour;
            this.font = font;
            this.scale = 1;

            this.colour = defaultColour;
        }

        #endregion

        #region Methods

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(this.font, this.displayText, this.GetCoordinates(), this.colour.GetValue(), 0,
                                    default(Vector2), this.scale, SpriteEffects.None, 0);
        }

        public override void Initialise(Rectangle parent)
        {
            this.InitialiseDisplay();
            this.InitialiseDimensions();
            this.InitialiseCoordinates(parent);
        }

        public override void Click()
        {
        }

        public override void Hover()
        {
            this.colour = this.hoverColour;
        }

        public override void HoverLeave()
        {
            this.colour = this.defaultColour;
        }

        private void InitialiseDisplay()
        {
            switch (this.fontFlow)
            {
                case FontFlow.Wrap:
                    break;

                case FontFlow.Shrink:
                    break;
            }
        }

        private void InitialiseDimensions()
        {
            Vector2 dimensions = this.font.MeasureString(this.displayText);

            this.Width = (int)(dimensions.X * this.scale);
            this.Height = (int)(dimensions.Y * this.scale);
        }

        private void WrapText()
        {
            string[] words = this.text.Split(' ');

            StringBuilder result = new StringBuilder();
            StringBuilder line = new StringBuilder();

            foreach (string word in words)
            {
                if (this.font.MeasureString(line).X + this.font.MeasureString(word).X > this.maxWidth)
                {
                    result.Append(line);
                    result.Append("\n");

                    line.Clear();
                    line.Append(word);

                    continue;
                }

                if (!String.IsNullOrEmpty(line.ToString()))
                {
                    line.Append(" ");
                }

                line.Append(word);
            }

            if (!String.IsNullOrEmpty(line.ToString()))
            {
                result.Append(line);
            }

            this.displayText = result.ToString();
        }

        private void ScaleText()
        {
            Vector2 dimensions = this.font.MeasureString(this.displayText);

            if (dimensions.X > this.maxWidth)
            {
                this.scale = this.maxWidth / dimensions.X;
            }
            else
            {
                this.scale = 1;
            }
        }

        #endregion
    }
}
