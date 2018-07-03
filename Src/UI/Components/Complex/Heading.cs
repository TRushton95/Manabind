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

        private FontGraphics fontGraphics;

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

            fontGraphics = new FontGraphics(Text, Width, 0, PositionProfile, FontFlow.Shrink, TextColour, Textures.HeadingFont);
            fontGraphics.Initialise(this.GetBounds());
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
