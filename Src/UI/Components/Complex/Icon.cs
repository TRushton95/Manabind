using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Manabind.Src.UI.Components.BaseInstanceResources;
using Manabind.Src.UI.Components.Basic;
using Manabind.Src.UI.PositionProfiles;
using Manabind.Src.UI.Factories;

namespace Manabind.Src.UI.Components.Complex
{
    public class Icon : BaseComplexComponent
    {
        #region Fields

        public static int Diameter = 100;

        private ImageGraphics image;
        private bool hovered;

        #endregion

        #region Constructors

        public Icon()
            : base()
        {
        }

        public Icon(int width, int height, BasePositionProfile positionProfile, int priority, Texture2D texture)
            : base(width, height, positionProfile, priority)
        {
            this.Texture = texture;
        }

        #endregion

        #region Properties

        public Texture2D Texture
        {
            get;
            set;
        }

        #endregion

        #region Methods

        public override void Draw(SpriteBatch spriteBatch)
        {
            this.image.Draw(spriteBatch);

            if (this.hovered)
            {
                spriteBatch.Draw(Textures.IconHover, this.GetBounds(), Color.White);
            }
        }

        public override void Initialise(Rectangle parent)
        {
            this.InitialiseCoordinates(parent);
            this.BuildComponents();
        }

        public override void Refresh()
        {
            this.BuildComponents();
        }

        protected override void LeftClickDetail()
        {
        }

        protected override void RightClickDetail()
        {
        }

        protected override void LeftMouseDownDetail()
        {
        }

        protected override void HoverDetail()
        {
            this.hovered = true;
        }

        protected override void HoverLeaveDetail()
        {
            this.hovered = false;
        }

        private void BuildComponents()
        {
            this.image = new ImageGraphics(this.Texture, PositionProfileFactory.BuildCenteredRelative());
            this.image.Initialise(this.GetBounds());
        }

        #endregion
    }
}
