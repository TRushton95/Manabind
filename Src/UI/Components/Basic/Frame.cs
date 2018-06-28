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
            this.defaultTexture = this.BuildTexture(this.displayColour);
            this.hoverTexture = this.BuildTexture(this.hoverColour);

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

        private Texture2D BuildTexture(Color colour)
        {
            Texture2D newTexture = new Texture2D(GraphicsDevice, this.Width, this.Height);

            Color[] data = new Color[this.Width * this.Height];
            for (int pixel = 0; pixel < data.Length; pixel++)
            {
                data[pixel] = colour;
            }

            newTexture.SetData(data);

            return newTexture;
        }

        #endregion
    }
}
