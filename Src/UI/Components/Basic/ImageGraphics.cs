using Manabind.Src.UI.PositionProfiles;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Manabind.Src.UI.Components.Basic
{
    public class ImageGraphics : BaseComponent
    {
        #region Fields

        private Texture2D image;

        #endregion

        #region Constructors

        public ImageGraphics()
        {
        }

        public ImageGraphics(Texture2D image, BasePositionProfile positionProfile)
            : base(positionProfile)
        {
            this.image = image;
        }

        #endregion

        #region Methods

        public override void Update()
        {
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.image, this.GetBounds(), Color.White);
        }

        public override void Initialise(Rectangle parent)
        {
            this.InitialiseDimensions();
            this.InitialiseCoordinates(parent);
        }

        private void InitialiseDimensions()
        {
            this.Width = this.image.Width;
            this.Height = this.image.Height;
        }

        #endregion
    }
}
