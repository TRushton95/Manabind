using Manabind.Src.UI.Components.Basic;
using Manabind.Src.UI.Enums;
using Manabind.Src.UI.Serialisation;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Manabind.Src.UI.Components.BaseInstanceResources;

namespace Manabind.Src.UI.Components.Complex
{
    public class Heading : BaseComplexComponent
    {
        #region Fields

        private FontGraphics fontGraphics, defaultFontGraphics, hoverFontGraphics;

        #endregion

        #region Constructors

        public Heading()
        {
        }

        #endregion
        
        #region Properies

        public string Text
        {
            get;
            set;
        }

        public Colour TextColour
        {
            get;
            set;
        }

        public Colour HoverTextColour
        {
            get;
            set;
        }

        #endregion

        #region Methods

        public override void Draw(SpriteBatch spriteBatch)
        {
            fontGraphics.Draw(spriteBatch);
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
            this.fontGraphics = this.hoverFontGraphics;
        }

        protected override void HoverLeaveDetail()
        {
            this.fontGraphics = this.defaultFontGraphics;
        }

        private void BuildComponents()
        {
            defaultFontGraphics = new FontGraphics(Text, Width, 0, PositionProfile, FontFlow.Shrink, TextColour, Textures.HeadingFont);
            defaultFontGraphics.Initialise(this.GetBounds());

            hoverFontGraphics = new FontGraphics(Text, Width, 0, PositionProfile, FontFlow.Shrink, HoverTextColour, Textures.HeadingFont);
            hoverFontGraphics.Initialise(this.GetBounds());

            this.fontGraphics = this.defaultFontGraphics;
        }

        #endregion
    }
}
