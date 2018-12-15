using Manabind.Src.UI.Components.Basic;
using Manabind.Src.UI.Enums;
using Manabind.Src.UI.Components.BaseInstanceResources;
using Manabind.Src.UI.Factories;
using Manabind.Src.UI.Serialisation;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Manabind.Src.UI.Components.Complex
{
    public class Tooltip : BaseComplexComponent
    {
        #region Fields

        private Frame frame;
        private FontGraphics fontGraphics;

        #endregion

        #region Constructors

        public Tooltip()
        {
        }

        #endregion

        #region Properties

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

        public Colour BackgroundColour
        {
            get;
            set;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            frame.Draw(spriteBatch);
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

        protected override void HoverDetail()
        {
        }

        protected override void HoverLeaveDetail()
        {
        }

        protected override void LeftClickDetail()
        {
        }

        protected override void LeftMouseDownDetail()
        {
        }

        protected override void RightClickDetail()
        {
        }

        private void BuildComponents()
        {
            frame = new Frame(Width, Height, PositionProfileFactory.BuildCenteredRelative(), BackgroundColour);
            fontGraphics = new FontGraphics(Text, Width, 20, PositionProfileFactory.BuildTopLeftRelative(),
                                    FontFlow.Wrap, TextColour, Textures.TooltipFont);

            frame.Components.Add(fontGraphics);
            frame.Initialise(this.GetBounds());
        }

        #endregion
    }
}
