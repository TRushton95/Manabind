using Manabind.Src.UI.PositionProfiles;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Manabind.Src.UI.Components.Basic
{
    public class ImageGraphics : BaseComponent
    {
        #region Fields

        private Texture2D image, defaultImage, hoverImage;

        #endregion

        #region Constructors

        public ImageGraphics()
        {
        }

        public ImageGraphics(Texture2D defaultImage, Texture2D hoverImage, BasePositionProfile positionProfile)
            : base(positionProfile)
        {
            this.defaultImage = defaultImage;
            this.hoverImage = hoverImage;

            this.image = defaultImage;
        }

        #endregion

        #region Methods

        public override void Click()
        {
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.image, this.GetBounds(), Color.White);
        }

        public override void Hover()
        {
            this.image = this.hoverImage;
        }

        public override void HoverLeave()
        {
            this.image = this.defaultImage;
        }

        public override void Initialise(Rectangle parent)
        {
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
