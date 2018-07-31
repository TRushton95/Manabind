using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Manabind.Src.UI.PositionProfiles;
using Microsoft.Xna.Framework;
using System.Xml.Serialization;

namespace Manabind.Src.UI.Components.Complex
{
    public class RootContainer : BaseComplexComponent
    {
        #region Constructors

        public RootContainer()
            : base()
        {
            this.Width = AppSettings.WindowWidth;
            this.Height = AppSettings.WindowHeight;
            this.PositionProfile = new AbsolutePositionProfile(0, 0);
            this.Priority = 0;
        }

        #endregion

        #region Properties

        [XmlArrayItem(typeof(Container))]
        [XmlArrayItem(typeof(Button))]
        [XmlArrayItem(typeof(Heading))]
        [XmlArrayItem(typeof(Toolbar))]
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
            this.Width = AppSettings.WindowWidth;
            this.Height = AppSettings.WindowHeight;

            foreach (BaseComplexComponent component in Components)
            {
                component.Initialise(this.GetBounds(), this.Priority);
            }
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
