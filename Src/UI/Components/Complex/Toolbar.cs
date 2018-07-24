using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Manabind.Src.Gameplay.Interfaces;
using System.Collections.Generic;
using Manabind.Src.UI.Components.Basic;
using Manabind.Src.UI.PositionProfiles;
using Manabind.Src.UI.Serialisation;
using Manabind.Src.Gameplay.Entities;
using Manabind.Src.UI.Enums;
using Manabind.Src.UI.Components.BaseInstanceResources;

namespace Manabind.Src.UI.Components.Complex
{
    public class Toolbar : BaseComplexComponent
    {
        #region Constants

        private const int Gutter = 10;
        private const int MaxToolCount = 8;

        #endregion

        #region Fields

        private Frame frame;
        private List<Icon> icons;

        private List<IIconable> iconables;

        #endregion

        #region Constructors

        public Toolbar()
        {
            this.icons = new List<Icon>();
            this.iconables = new List<IIconable>();
        }

        public Toolbar(
            int width,
            int height,
            BasePositionProfile positionProfile,
            int priority,
            Colour backgroundColour,
            List<IIconable> iconables)
            : base(width, height, positionProfile, priority)
        {
            this.BackgroundColour = backgroundColour;
            this.icons = new List<Icon>();
            this.iconables = iconables;
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
            icons = new List<Icon>();
            foreach (IIconable iconable in iconables)
            {
                iconable.Icon.Name = "tool";
                icons.Add(iconable.Icon);
            }

            this.InitialiseDimensions();
            this.InitialiseCoordinates(parent);

            frame = new Frame(Width, Height, PositionProfile, BackgroundColour);
            frame.Initialise(this.GetBounds());
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

        private void InitialiseDimensions()
        {
            int totalIconWidth = (MaxToolCount * Icon.Diameter) + (Gutter * 2);
            this.Width = totalIconWidth + (Gutter * 2);

            this.Height = Icon.Diameter + (Gutter * 2);
        }

        private void LoadTiles()
        {
            this.iconables.Add(
                new Tile(0, 0, TileType.Ground, Textures.GroundTile, Tile.GetIcon(TileType.Ground)));
        }

        protected override void ExecuteEventResponse(string action, object content)
        {
            switch (action)
            {
                case "load-tiles":
                    this.LoadTiles();
                    break;
            }
        }

        #endregion
    }
}
