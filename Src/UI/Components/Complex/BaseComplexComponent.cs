using Manabind.Src.UI.Components.Basic;
using Manabind.Src.UI.Enums;
using Manabind.Src.UI.Events;
using Manabind.Src.UI.PositionProfiles;
using Manabind.Src.UI.Utilities;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Manabind.Src.UI.Components.Complex
{
    public abstract class BaseComplexComponent : BaseComponent
    {
        #region Constructors

        public BaseComplexComponent()
        {
            this.Priority = 0;
            this.Interactive = true;
            this.Visible = true;
            this.EventResponses = new List<EventResponse>();
            this.Hovered = false;
        }

        public BaseComplexComponent(int width, int height, BasePositionProfile positionProfile, int priority)
            : base(positionProfile)
        {
            this.Priority = priority;
            this.Interactive = true;
            this.Visible = true;
            this.EventResponses = new List<EventResponse>();
            this.Hovered = false;
        }

        #endregion

        #region Properties

        [XmlAttribute("name")]
        public string Name
        {
            get;
            set;
        }

        [XmlIgnore]
        public int Priority
        {
            get;
            set;
        }
        
        [XmlIgnore]
        public bool Hovered
        {
            get;
            set;
        }

        [XmlAttribute("interactive")]
        public bool Interactive
        {
            get;
            set;
        }

        [XmlAttribute("visible")]
        public bool Visible
        {
            get;
            set;
        }

        #endregion

        #region Methods

        public void Initialise(Rectangle parent, int parentPriority)
        {
            this.Priority = parentPriority + 1;

            this.Initialise(parent);
        }

        public void Click()
        {
            this.ClickDetail();
            EventManager.PushEvent(
                new UIEvent(new EventDetails(this.Name, EventType.Click), this));
        }

        public void Hover()
        {
            this.Hovered = true;
            this.HoverDetail();
            EventManager.PushEvent(
                new UIEvent(new EventDetails(this.Name, EventType.Hover), this));
        }

        public void HoverLeave()
        {
            this.Hovered = false;
            this.HoverLeaveDetail();
            EventManager.PushEvent(
                new UIEvent(new EventDetails(this.Name, EventType.HoverLeave), this));
        }

        public virtual List<BaseComplexComponent> BuildTree()
        {
            return new List<BaseComplexComponent> { this };
        }

        public void Hide()
        {
            this.Visible = false;
        }

        public void Show()
        {
            this.Visible = true;
        }

        protected override void ExecuteEventResponse(string action, object content)
        {
            switch (action)
            {
                case "hide": this.Hide();
                    break;

                case "show": this.Show();
                    break;
            }
        }

        protected abstract void ClickDetail();

        protected abstract void HoverDetail();

        protected abstract void HoverLeaveDetail();

        #endregion
    }
}
