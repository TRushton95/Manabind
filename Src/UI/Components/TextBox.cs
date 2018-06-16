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
        
        private string displayText;
        private SpriteFont font;

        #endregion

        #region Constructors

        public TextBox()
        {
        }

        public TextBox(string parentId, string text, int maxWidth, int gutter, IPositionProfile positionProfile, FontFlow fontFlow, Color displayColour, SpriteFont font)
            : base(parentId, positionProfile)
        {
            this.Text = text;
            this.displayText = text;
            this.MaxWidth = maxWidth;
            this.FontFlow = fontFlow;
            this.DisplayColour = displayColour;
            this.font = font;
            this.Scale = 1;

            this.InitialiseDisplay();
            this.InitialiseDimensions();
            this.InitialiseCoordinates();
        }

        #endregion

        #region Fields

        public string Text
        {
            get;
            set;
        }

        public Color DisplayColour
        {
            get;
            set;
        }

        public float Scale
        {
            get;
            set;
        }

        public FontFlow FontFlow
        {
            get;
            set;
        }

        public int MaxWidth
        {
            get;
            set;
        }

        #endregion

        #region Methods

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(this.font, this.displayText, this.GetCoordinates(), this.DisplayColour, 0, default(Vector2), this.Scale, SpriteEffects.None, 0);
        }

        private void InitialiseDisplay()
        {
            switch (this.FontFlow)
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

            this.width = (int)(dimensions.X * this.Scale);
            this.height = (int)(dimensions.Y * this.Scale);
        }

        private void WrapText()
        {
            string[] words = this.Text.Split(' ');

            StringBuilder result = new StringBuilder();
            StringBuilder line = new StringBuilder();

            foreach (string word in words)
            {
                if (this.font.MeasureString(line).X + this.font.MeasureString(word).X > this.MaxWidth)
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

            if (dimensions.X > this.MaxWidth)
            {
                this.Scale = this.MaxWidth / dimensions.X;
            }
            else
            {
                this.Scale = 1;
            }
        }

        #endregion
    }
}
