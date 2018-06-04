using System;
using Manabind.Src.UI.Enums;
using Manabind.Src.UI.PositionProfiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Text;

namespace Manabind.Src.UI.Components
{
    public class TextBox : BaseComponent
    {
        #region Fields

        private int maxWidth;
        private string text, displayText;
        private float scale;
        private Color displayColour;
        private SpriteFont font;
        private FontFlow fontFlow;

        #endregion

        #region Constructors

        public TextBox()
        {
        }

        public TextBox(string parentId, string text, int maxWidth, int gutter, IPositionProfile positionProfile, FontFlow fontFlow, Color displayColour, SpriteFont font)
            : base(parentId, positionProfile)
        {
            this.text = text;
            this.displayText = text;
            this.maxWidth = maxWidth;
            this.fontFlow = fontFlow;
            this.displayColour = displayColour;
            this.font = font;
            this.scale = 1;

            this.InitialiseDisplay();
            this.InitialiseDimensions();
            this.InitialiseCoordinates();
        }

        #endregion

        #region Methods

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(this.font, this.displayText, this.GetCoordinates(), this.displayColour, 0, default(Vector2), this.scale, SpriteEffects.None, 0);
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

            this.width = (int)(dimensions.X * this.scale);
            this.height = (int)(dimensions.Y * this.scale);
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
