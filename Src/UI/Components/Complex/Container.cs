using System;
using Microsoft.Xna.Framework.Graphics;
using Manabind.Src.UI.PositionProfiles;
using Manabind.Src.UI.Components.Basic;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Manabind.Src.UI.Components.Complex
{
    public class Container : BaseComplexComponent
    {
        #region Field

        private Frame frame;

        #endregion

        #region Constructors

        public Container()
            : base()
        {
        }

        public Container(int width, int height, BasePositionProfile positionProfile, Color backgroundColour)
            : base(width, height, positionProfile)
        {
            frame = new Frame(width, height, positionProfile, backgroundColour);
        }

        #endregion

        public List<BaseComplexComponent> Components
        {
            get;
            set;
        }

        #region Methods

        public override void Draw(SpriteBatch spriteBatch)
        {
            frame.Draw(spriteBatch);

            foreach (BaseComponent component in Components)
            {
                component.Draw(spriteBatch);
            }
        }

        public override void Initialise()
        {
            frame.Initialise();

            foreach (BaseComplexComponent component in Components)
            {
                component.Initialise();
            }
        }

        public override void OnHover()
        {
            throw new NotImplementedException();
        }

        public override void OnHoverLeave()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
