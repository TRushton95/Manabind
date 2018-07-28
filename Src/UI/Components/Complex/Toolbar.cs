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
        private List<Tile> tiles;
        private List<Icon> icons;

        #endregion

        #region Constructors

        public Toolbar()
        {
            this.tiles = new List<Tile>();
            this.icons = new List<Icon>();
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

            foreach (Icon icon in icons)
            {
                icon.Draw(spriteBatch);
            }
        }

        public override void Initialise(Rectangle parent)
        {
            this.InitialiseDimensions();
            this.InitialiseCoordinates(parent);
            this.LoadTiles();

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
            //Create flyweight tiles
            this.tiles.Add(
                new Tile(0, 0, TileType.Empty, Textures.EmptyTile, Tile.GetIcon(TileType.Empty)));
            this.tiles.Add(
                new Tile(0, 0, TileType.Ground, Textures.GroundTile, Tile.GetIcon(TileType.Ground)));

            //Load icons from tiles
            icons = new List<Icon>();
            foreach (Tile tile in tiles)
            {
                int index = tiles.IndexOf(tile);

                tile.Icon.Name = "tool";
                tile.Icon.PositionProfile = new RelativePositionProfile(HorizontalAlign.Left, VerticalAlign.Bottom, (index * Icon.Diameter) + 20, 0);
                tile.Icon.Initialise(this.GetBounds());

                icons.Add(tile.Icon);
            }
        }

        protected override void ExecuteEventResponse(string action, object content)
        {
            switch (action)
            {
            }
        }

        #endregion
    }
}
