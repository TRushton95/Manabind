using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Xml.Serialization;
using Manabind.Src.UI.Serialisation;
using System.IO;
using System.Xml;
using Manabind.Src.UI.Components.BaseInstanceResources;
using Manabind.Src.UI.PositionProfiles;

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
                component.Draw(spriteBatch);
            }
        }

        public override void Initialise()
        {
            foreach (BaseComplexComponent component in Components)
            {
                component.Initialise();
            }
        }

        public override void OnHover()
        {
        }

        public override void OnHoverLeave()
        {
        }

        public override List<BaseComplexComponent> BuildTree()
        {
            List<BaseComplexComponent> result = new List<BaseComplexComponent> { this };

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

        #endregion
    }
}
