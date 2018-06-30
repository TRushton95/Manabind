using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Manabind.Src.UI.PositionProfiles;
using System.Collections.Generic;

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
            this.Components = new List<BaseComponent>();
        }

        public Frame(int width, int height, BasePositionProfile positionProfile, Color displayColour, Color hoverColour)
            : base(positionProfile)
        {
            this.Width = width;
            this.Height = height;
            this.PositionProfile = positionProfile;
            this.displayColour = displayColour;
            this.hoverColour = hoverColour;

            this.Components = new List<BaseComponent>();
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
            spriteBatch.Draw(this.texture, this.GetCoordinates(), Color.White);

            foreach (BaseComponent component in Components)
            {
                component.Draw(spriteBatch);
            }
        }

        public override void Initialise(Rectangle parent)
        {
            this.InitialiseCoordinates(parent);
            this.defaultTexture = this.BuildTexture(this.displayColour);
            this.hoverTexture = this.BuildTexture(this.hoverColour);

            this.texture = this.defaultTexture;

            foreach(BaseComponent component in Components)
            {
                component.Initialise(this.GetBounds());
            }
        }

        public override void OnHover()
        {
            this.texture = this.hoverTexture;

            foreach (BaseComponent component in Components)
            {
                component.OnHover();
            }
        }

        public override void OnHoverLeave()
        {
            this.texture = this.defaultTexture;

            foreach (BaseComponent component in Components)
            {
                component.OnHoverLeave();
            }
        }

        private Texture2D BuildTexture(Color colour)
        {
            Texture2D result = new Texture2D(GraphicsDevice, this.Width, this.Height);

            Color[] data = new Color[this.Width * this.Height];
            for (int pixel = 0; pixel < data.Length; pixel++)
            {
                data[pixel] = colour;
            }

            result.SetData(data);


            return result;
        }

        #endregion
    }
}
