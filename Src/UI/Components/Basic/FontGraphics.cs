using System;
using Manabind.Src.UI.Enums;
using Manabind.Src.UI.PositionProfiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Text;
using Manabind.Src.UI.Serialisation;

namespace Manabind.Src.UI.Components.Basic
{
    public class FontGraphics : BaseComponent
    {
        #region Fields
        
        private string text, displayText;
        private SpriteFont font;
        private Colour colour;
        private float scale;
        private int maxWidth;
        private int gutter;
        private FontFlow fontFlow;

        #endregion

        #region Constructors

        public FontGraphics()
        {
        }

        public FontGraphics(string text, int maxWidth, int gutter, BasePositionProfile positionProfile, 
                        FontFlow fontFlow, Colour colour, SpriteFont font)
            : base(positionProfile)
        {
            this.text = text;
            this.displayText = text;
            this.maxWidth = maxWidth;
            this.gutter = gutter;
            this.fontFlow = fontFlow;
            this.colour = colour;
            this.font = font;
            this.scale = 1;
        }

        #endregion

        #region Methods

        public override void Update()
        {
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(this.font, this.displayText, this.GetCoordinates(), this.colour.GetValue(), 0,
                                    default(Vector2), this.scale, SpriteEffects.None, 0);
        }

        public override void Initialise(Rectangle parent)
        {
            this.InitialiseDisplay();
            this.InitialiseDimensions();

            Rectangle gutterAdjustedParent = new Rectangle(
                parent.X + gutter,
                parent.Y + gutter,
                parent.Width - (gutter * 2),
                parent.Height - (gutter * 2));

            this.InitialiseCoordinates(gutterAdjustedParent);
        }

        private void InitialiseDisplay()
        {
            switch (this.fontFlow)
            {
                case FontFlow.Wrap:
                    WrapText();
                    break;

                case FontFlow.Shrink:
                    ScaleText();
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
                if (this.font.MeasureString(line).X + this.font.MeasureString(word).X > this.maxWidth - (this.gutter * 2))
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

            if (dimensions.X > this.maxWidth - (this.gutter * 2))
            {
                this.scale = this.maxWidth / (dimensions.X - (this.gutter * 2));
            }
            else
            {
                this.scale = 1;
            }
        }

        #endregion
    }
}
