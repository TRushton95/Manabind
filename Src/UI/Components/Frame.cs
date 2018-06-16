using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Manabind.Src.UI.PositionProfiles;
using System.Xml.Serialization;

namespace Manabind.Src.UI.Components
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

        public Frame(string parentId, int width, int height, BasePositionProfile positionProfile, Color displayColour)
            : base(parentId, positionProfile)
        {
            this.Width = width;
            this.Height = height;
            this.PositionProfile = positionProfile;
            this.DisplayColour = displayColour;
            this.Components = new List<BaseComponent>();

            this.InitialiseCoordinates();
            this.InitialiseTexture();
        }

        #endregion

        #region Properties

        public Color DisplayColour
        {
            get;
            set;
        }
        
        [XmlArrayItem(typeof(Frame))]
        [XmlArrayItem(typeof(TextBox))]
        public List<BaseComponent> Components
        {
            get;
            set;
        }

        #endregion

        #region Methods

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.texture, this.GetCoordinates(), this.DisplayColour);

            foreach(BaseComponent component in Components)
            {
                component.Draw(spriteBatch);
            }
        }

        private void InitialiseTexture()
        {
            Texture2D newTexture = new Texture2D(this.GraphicsDevice, this.Width, this.Height);

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
