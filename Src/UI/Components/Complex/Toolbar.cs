using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Manabind.Src.Gameplay.Interfaces;
using System.Collections.Generic;
using Manabind.Src.UI.Components.Basic;
using Manabind.Src.UI.PositionProfiles;
using Manabind.Src.UI.Serialisation;
using Manabind.Src.Gameplay.Entities.Tiles;
using Manabind.Src.UI.Enums;
using Manabind.Src.UI.Events;
using Manabind.Src.Gameplay.Entities.Tile;

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
        private List<BaseTile> tiles;
        private List<Icon> icons;

        #endregion

        #region Constructors

        public Toolbar()
        {
            this.tiles = new List<BaseTile>();
            this.icons = new List<Icon>();

            this.LoadTiles();
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

            this.LoadTiles();
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

            frame = new Frame(Width, Height, PositionProfile, BackgroundColour);
            frame.Initialise(this.GetBounds());
            InitialiseIcons();
        }

        public override List<BaseComplexComponent> BuildTree()
        {
            List<BaseComplexComponent> result = new List<BaseComplexComponent> { this };

            result.AddRange(icons);

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

        protected override void ExecuteEventResponse(string action, object content)
        {
            switch (action)
            {
                case "select-tool":
                    int index = icons.IndexOf((Icon)content);
                    
                    if (index <= tiles.Count)
                    {
                        BaseTile tile = tiles[index];

                        EventManager.PushEvent(
                            new UIEvent(new EventDetails(this.Name, EventType.Select), tile));
                    }

                    break;
            }
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
                new EmptyTile(0, 0, 0, 0));
            this.tiles.Add(
                new GroundTile(0, 0, 0, 0));

            //Load icons from tiles
            icons = new List<Icon>();
            foreach (BaseTile tile in tiles)
            {
                icons.Add(tile.Icon);
            }
        }

        private void InitialiseIcons()
        {
            foreach (BaseTile tile in tiles)
            {
                int index = tiles.IndexOf(tile);

                tile.Icon.Name = "tool";
                tile.Icon.PositionProfile = new RelativePositionProfile(HorizontalAlign.Left, VerticalAlign.Bottom, (index * Icon.Diameter) + 20, 0);
                tile.Icon.Priority = this.Priority + 1;
                tile.Icon.Initialise(this.GetBounds());
            }
        }

        #endregion
    }
}
