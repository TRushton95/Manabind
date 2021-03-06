﻿using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Manabind.Src.UI.PositionProfiles;
using Microsoft.Xna.Framework;
using System.Xml.Serialization;
using Manabind.Src.UI.Components.Complex.ListItems;

namespace Manabind.Src.UI.Components.Complex
{
    public class RootContainer : BaseComplexComponent
    {
        #region Constructors

        public RootContainer()
            : base()
        {
            this.Name = "root";
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
        [XmlArrayItem(typeof(Tooltip))]
        [XmlArrayItem(typeof(Textbox))]
        [XmlArrayItem(typeof(TextboxListItem))]
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
            this.InitialiseListen(string.Empty);
            this.InitialiseCoordinates(parent);
            this.Width = AppSettings.WindowWidth;
            this.Height = AppSettings.WindowHeight;

            foreach (BaseComplexComponent component in Components)
            {
                component.Initialise(this.GetBounds(), this.Id, this.Priority, this.Visible);
            }
        }

        public override void Refresh()
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
        }

        protected override void HoverLeaveDetail()
        {
        }

        #endregion
    }
}
