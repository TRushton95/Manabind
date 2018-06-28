using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Manabind.Src.UI.PositionProfiles;
using System;

namespace Manabind.Src.UI.Components.Basic
{
    public class Frame : BaseComponent
    {
        #region Fields
        
        private Texture2D texture, defaultTexture, hoverTexture;
        private Color displayColour, hoverColour;

        #endregion

        #region Constructors

        public Frame()
        {
        }

        public Frame(int width, int height, BasePositionProfile positionProfile, Color displayColour, Color hoverColour)
            : base(positionProfile)
        {
            this.Width = width;
            this.Height = height;
            this.PositionProfile = positionProfile;
            this.displayColour = displayColour;
            this.hoverColour = hoverColour;

            this.Initialise();
        }

        #endregion

        #region Methods

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.texture, this.GetCoordinates(), this.displayColour);
        }

        public override void Initialise()
        {
            this.InitialiseCoordinates();
            this.InitialiseTexture(this.defaultTexture, this.displayColour);
            this.InitialiseTexture(this.hoverTexture, this.hoverColour);

            this.texture = this.defaultTexture;
        }

        public override void OnHover()
        {
            this.texture = this.hoverTexture;
        }

        public override void OnHoverLeave()
        {
            this.texture = this.defaultTexture;
        }

        private void InitialiseTexture(Texture2D texture, Color colour)
        {
            Texture2D newTexture = new Texture2D(GraphicsDevice, this.Width, this.Height);

            Color[] data = new Color[this.Width * this.Height];
            for (int pixel = 0; pixel < data.Length; pixel++)
            {
                data[pixel] = colour;
            }

            newTexture.SetData(data);

            texture = newTexture;
        }

        #endregion
    }
}
