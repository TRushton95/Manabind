using Manabind.Src.UI.Components.Basic;
using Manabind.Src.UI.Enums;
using Manabind.Src.UI.Components.BaseInstanceResources;
using Manabind.Src.UI.Factories;
using Manabind.Src.UI.Serialisation;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Xml.Serialization;
using System.Text;
using Manabind.Src.Gameplay;
using Manabind.Src.Control;

namespace Manabind.Src.UI.Components.Complex
{
    public class Tooltip : BaseComplexComponent
    {
        #region Fields

        private Frame frame;
        private FontGraphics fontGraphics;

        #endregion

        #region Constructors

        public Tooltip()
        {
        }

        #endregion

        #region Properties

        public string Text
        {
            get;
            set;
        }

        public Colour TextColour
        {
            get;
            set;
        }

        public Colour BackgroundColour
        {
            get;
            set;
        }

        [XmlAttribute("gutter")]
        public int Gutter
        {
            get;
            set;
        }

        [XmlAttribute("stretchToChildren")]
        public bool StretchToChildren
        {
            get;
            set;
        }

        #endregion

        #region Method

        public override void Update()
        {
            Vector2 mousePos = MouseInfo.Position;

            this.posX = (int)mousePos.X;
            this.posY = (int)mousePos.Y - this.Height;

            this.Refresh();

            frame.Update();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            frame.Draw(spriteBatch);
        }

        public override void Initialise(Rectangle parent)
        {
            this.InitialiseCoordinates(parent);
            this.BuildComponents();
        }

        public override void Refresh()
        {
            this.BuildComponents();
        }

        protected override void HoverDetail()
        {
        }

        protected override void HoverLeaveDetail()
        {
        }

        protected override void LeftClickDetail()
        {
        }

        protected override void LeftMouseDownDetail()
        {
        }

        protected override void RightClickDetail()
        {
        }

        protected override void ExecuteEventResponse(string action, object content)
        {
            base.ExecuteEventResponse(action, content);

            switch (action)
            {
                case "load-content":
                    LoadContent((Unit)content);
                    break;
            }
        }

        private void LoadContent(Unit unit)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Team: {unit.Team}");
            sb.AppendLine($"Health: {unit.CurrentHealth}/{unit.MaxHealth}");
            sb.AppendLine($"Energy: {unit.CurrentEnergy}/{unit.MaxEnergy}");

            this.Text = sb.ToString();
            this.posX = unit.CanvasX + Unit.Diameter;
            this.posY = unit.CanvasY;

            this.Refresh();
        }

        private void BuildComponents()
        {
            frame = new Frame(Width, Height, PositionProfileFactory.BuildCenteredRelative(), BackgroundColour);
            fontGraphics = new FontGraphics(Text, Width, Gutter, PositionProfileFactory.BuildTopLeftRelative(),
                                    FontFlow.Wrap, TextColour, Textures.TooltipFont);

            frame.Components.Add(fontGraphics);
            frame.Initialise(this.GetBounds());
            
            //TO-DO Fix this fucking shit
            /*
             * Now that the dimensions are assigned for the fontGraphics,
             * assign the known height to Tooltip and rebuild the frame
             * using it.
             */
            int adjustedHeight = fontGraphics.Height + (Gutter * 2);
            this.Height = adjustedHeight;
            frame.Height = adjustedHeight;
            frame.Initialise(this.GetBounds());
        }

        #endregion
    }
}
