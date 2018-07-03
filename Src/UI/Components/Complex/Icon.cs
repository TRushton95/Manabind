using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Manabind.Src.UI.Components.Basic;
using Manabind.Src.UI.PositionProfiles;
using Manabind.Src.UI.Factories;

namespace Manabind.Src.UI.Components.Complex
{
    public class Icon : BaseComplexComponent
    {
        #region Fields

        private ImageGraphics image;

        #endregion

        #region Constructors

        public Icon()
            : base()
        {
        }

        public Icon(int width, int height, BasePositionProfile positionProfile, int priority, Texture2D defaultTexture, Texture2D hoverTexture)
            : base(width, height, positionProfile, priority)
        {
            this.DefaultTexture = defaultTexture;
            this.HoverTexture = hoverTexture;
        }

        #endregion

        #region Properties

        public Texture2D DefaultTexture
        {
            get;
            set;
        }

        public Texture2D HoverTexture
        {
            get;
            set;
        }

        #endregion

        #region Methods

        public override void Draw(SpriteBatch spriteBatch)
        {
            this.image.Draw(spriteBatch);
        }

        public override void Initialise(Rectangle parent)
        {
            this.InitialiseCoordinates(parent);

            this.image = new ImageGraphics(this.DefaultTexture, PositionProfileFactory.BuildCenteredRelative());
        }

        protected override void ClickDetail()
        {
        }

        protected override void HoverDetail()
        {
        }

        protected override void HoverLeaveDetail()
        {
        }

        #endregion
    }
}
