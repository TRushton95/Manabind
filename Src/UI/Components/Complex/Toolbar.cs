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
using Manabind.Src.UI.Components.BaseInstanceResources;
using System.Linq;
using Manabind.Src.UI.Factories;
using System.Xml.Serialization;

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
        private Icon highlightedIcon;

        #endregion

        #region Constructors

        public Toolbar()
        {
            this.Tools = new List<IIconable>();
            this.Icons = new List<Icon>();
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
            this.Icons = new List<Icon>();
            this.Tools = new List<IIconable>();
        }

        #endregion

        #region Properties

        public Colour BackgroundColour
        {
            get;
            set;
        }

        [XmlAttribute("tool")]
        public Tool Tool
        {
            get;
            set;
        }

        [XmlIgnore]
        public List<IIconable> Tools
        {
            get;
            set;
        }

        [XmlIgnore]
        public List<Icon> Icons
        {
            get;
            set;
        }

        #endregion

        #region Methods

        public override void Draw(SpriteBatch spriteBatch)
        {
            frame.Draw(spriteBatch);

            foreach (Icon icon in Icons)
            {
                icon.Draw(spriteBatch);
            }

            if (highlightedIcon != null)
            {
                spriteBatch.Draw(Textures.TileIconHover, highlightedIcon.GetCoordinates(), Color.White);
            }
        }

        public override void Initialise(Rectangle parent)
        {
            this.InitialiseDimensions();
            this.InitialiseCoordinates(parent);

            if (Tool == Tool.Tile)
            {
                LoadFlyweightTiles();
            }

            this.InitialiseIcons();

            this.BuildComponents();
        }

        public override void Refresh()
        {
            this.BuildComponents();
        }

        public override List<BaseComplexComponent> BuildTree()
        {
            List<BaseComplexComponent> result = new List<BaseComplexComponent> { this };

            result.AddRange(Icons);

            return result;
        }

        public void LoadTools(List<IIconable> tools)
        {
            this.Tools = tools;
            this.Icons = tools.Select(tool => tool.Icon).ToList();

            EventManager.PushEvent(
                new UIEvent(new EventDetails(this.Name, EventType.RefreshTree), null));
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
                    SelectTool((Icon)content);
                    break;

                case "deselect-tool":
                    this.highlightedIcon = null;
                    break;
            }
        }

        private void InitialiseDimensions()
        {
            int totalIconWidth = (MaxToolCount * Icon.Diameter) + (Gutter * 2);
            this.Width = totalIconWidth + (Gutter * 2);

            this.Height = Icon.Diameter + (Gutter * 2);
        }

        private void InitialiseIcons()
        {
            foreach (IIconable tool in Tools)
            {
                int index = Tools.IndexOf(tool);

                tool.Icon.Name = "tool";
                tool.Icon.PositionProfile = new RelativePositionProfile(HorizontalAlign.Left, VerticalAlign.Bottom, (index * Icon.Diameter) + 20, 0);
                tool.Icon.Priority = this.Priority + 1;
                tool.Icon.Initialise(this.GetBounds());
            }
        }

        private void SelectTool(Icon icon)
        {
            int index = Icons.IndexOf(icon);

            if (index <= Tools.Count)
            {
                this.highlightedIcon = icon;
                IIconable tool = Tools[index];

                EventManager.PushEvent(
                    new UIEvent(new EventDetails(this.Name, EventType.Select), tool));
            }
        }

        private void LoadFlyweightTiles()
        {
            if (this.Tool == Tool.Tile)
            {
                List<BaseTile> flyweightTiles = TileFactory.GetFlyweightTiles();
                List<IIconable> tools = new List<IIconable>();

                foreach (IIconable flyweightTile in flyweightTiles)
                {
                    tools.Add(flyweightTile);
                }

                LoadTools(tools);
            }
        }

        private void BuildComponents()
        {
            frame = new Frame(Width, Height, PositionProfile, BackgroundColour);
            frame.Initialise(this.GetBounds());
        }

        #endregion
    }
}
