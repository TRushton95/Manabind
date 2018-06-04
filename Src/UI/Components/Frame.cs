using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Manabind.Src.UI.PositionProfiles;

namespace Manabind.Src.UI.Components
{
    public class Frame : BaseComponent
    {
        #region Fields

        private Color displayColour;
        private Texture2D texture;

        #endregion

        #region Constructors

        public Frame()
        {
        }

        public Frame(string parentId, int width, int height, IPositionProfile positionProfile, Color displayColour)
            : base(parentId, positionProfile)
        {
            this.width = width;
            this.height = height;
            this.PositionProfile = positionProfile;
            this.displayColour = displayColour;
            this.Components = new List<BaseComponent>();

            this.InitialiseCoordinates();
            this.InitialiseTexture();
        }

        #endregion

        #region Properties

        public List<BaseComponent> Components
        {
            get;
            set;
        }

        #endregion

        #region Methods

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.texture, this.GetCoordinates(), this.displayColour);

            foreach(BaseComponent component in Components)
            {
                component.Draw(spriteBatch);
            }
        }

        private void InitialiseTexture()
        {
            Texture2D newTexture = new Texture2D(this.GraphicsDevice, this.width, this.height);

            Color[] data = new Color[this.width * this.height];
            for (int pixel = 0; pixel < data.Length; pixel++)
            {
                data[pixel] = displayColour;
            }

            newTexture.SetData(data);

            this.texture = newTexture;
        }

        #endregion
    }
}
