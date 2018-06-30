using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using System;
using Manabind.Src.UI.Components.BaseInstanceResources;
using Manabind.Src.UI.PositionProfiles;
using Microsoft.Xna.Framework;

namespace Manabind.Src.UI.Components.Complex
{
    public class RootContainer : BaseComplexComponent
    {
        #region Constructors

        public RootContainer()
            : base()
        {
            this.Width = Settings.WindowWidth;
            this.Height = Settings.WindowHeight;
            this.PositionProfile = new AbsolutePositionProfile(0, 0);
            this.Priority = 0;
        }

        #endregion

        #region Properties

        public List<BaseComplexComponent> Components
        {
            get;
            set;
        }

        #endregion

        #region Methods

        public override void Draw(SpriteBatch spriteBatch)
        {
            foreach (BaseComplexComponent component in Components)
            {
                if (component.Visible)
                {
                    component.Draw(spriteBatch);
                }
            }
        }

        public override void Initialise(Rectangle parent)
        {
            this.InitialiseCoordinates(parent);
            this.Width = Settings.WindowWidth;
            this.Height = Settings.WindowHeight;

            foreach (BaseComplexComponent component in Components)
            {
                component.Initialise(this.GetBounds(), this.Priority);
            }
        }

        public override List<BaseComplexComponent> BuildTree()
        {
            List<BaseComplexComponent> result = new List<BaseComplexComponent>();

            List<BaseComplexComponent> total = new List<BaseComplexComponent>();
            foreach (BaseComplexComponent child in Components)
            {
                total = child.BuildTree();

                if (total.Count > 0)
                {
                    result.AddRange(total);
                }
            }

            return result;
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
