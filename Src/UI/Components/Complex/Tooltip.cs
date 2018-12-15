using Manabind.Src.UI.Components.Basic;
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

        public decimal Transparency
        {
            get;
            set;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            throw new System.NotImplementedException();
        }

        public override void Initialise(Rectangle parent)
        {
            throw new System.NotImplementedException();
        }

        public override void Refresh()
        {
            throw new System.NotImplementedException();
        }

        protected override void HoverDetail()
        {
            throw new System.NotImplementedException();
        }

        protected override void HoverLeaveDetail()
        {
            throw new System.NotImplementedException();
        }

        protected override void LeftClickDetail()
        {
            throw new System.NotImplementedException();
        }

        protected override void LeftMouseDownDetail()
        {
            throw new System.NotImplementedException();
        }

        protected override void RightClickDetail()
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
}
