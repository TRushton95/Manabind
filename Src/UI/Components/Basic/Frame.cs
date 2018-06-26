using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Manabind.Src.UI.PositionProfiles;
using System.Xml.Serialization;

namespace Manabind.Src.UI.Components.Basic
{
    public class Frame : BaseComponent
    {
        #region Fields
        
        private Texture2D texture;

        #endregion

        #region Constructors

        public Frame()
        {
        }

        public Frame(int width, int height, BasePositionProfile positionProfile, Color displayColour)
            : base(positionProfile)
        {
            this.Width = width;
            this.Height = height;
            this.PositionProfile = positionProfile;
            this.DisplayColour = displayColour;

            this.Initialise();
        }

        #endregion

        #region Properties

        public Color DisplayColour
        {
            get;
            set;
        }

        #endregion

        #region Methods

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.texture, this.GetCoordinates(), this.DisplayColour);
        }

        public override void Initialise()
        {
            this.InitialiseCoordinates();
            this.InitialiseTexture();
        }

        private void InitialiseTexture()
        {
            Texture2D newTexture = new Texture2D(GraphicsDevice, this.Width, this.Height);

            Color[] data = new Color[this.Width * this.Height];
            for (int pixel = 0; pixel < data.Length; pixel++)
            {
                data[pixel] = DisplayColour;
            }

            newTexture.SetData(data);

            this.texture = newTexture;
        }

        #endregion
    }
}
