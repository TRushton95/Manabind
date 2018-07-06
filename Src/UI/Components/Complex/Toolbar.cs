﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Manabind.Src.Gameplay.Interfaces;
using System.Collections.Generic;
using Manabind.Src.UI.Components.Basic;
using Manabind.Src.UI.PositionProfiles;
using Manabind.Src.UI.Serialisation;

namespace Manabind.Src.UI.Components.Complex
{
    public class Toolbar : BaseComplexComponent
    {
        #region Fields

        private Frame frame;
        private List<IIconable> icons;

        #endregion

        #region Constructors

        public Toolbar()
        {
        }

        public Toolbar(
            int width,
            int height,
            BasePositionProfile positionProfile,
            int priority,
            Colour backgroundColour,
            List<IIconable> icons)
            : base(width, height, positionProfile, priority)
        {
            this.BackgroundColour = backgroundColour;
            this.icons = icons;
        }

        #endregion

        #region Properties

        public Colour BackgroundColour
        {
            get;
            set;
        }

        #endregion

        #region Methods

        public override void Draw(SpriteBatch spriteBatch)
        {
            frame.Draw(spriteBatch);

            foreach (IIconable iconable in icons)
            {
                iconable.Icon.Draw(spriteBatch);
            }
        }

        public override void Initialise(Rectangle parent)
        {
            this.InitialiseCoordinates(parent);

            frame = new Frame(Width, Height, PositionProfile, BackgroundColour);
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
