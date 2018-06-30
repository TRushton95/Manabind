using Manabind.Src.UI.Components.Basic;
using Manabind.Src.UI.Enums;
using Manabind.Src.UI.Events;
using Manabind.Src.UI.PositionProfiles;
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
        
        [XmlArrayItem(typeof(EventResponse))]
        public List<EventResponse> EventResponses
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

        public override void Click()
        {
            this.ClickDetail();
            EventManager.PushEvent(new UIEvent(this.Name, EventType.Click));
        }

        public override void Hover()
        {
            this.Hovered = true;
            this.HoverDetail();
            EventManager.PushEvent(new UIEvent(this.Name, EventType.Hover));
        }

        public override void HoverLeave()
        {
            this.Hovered = false;
            this.HoverLeaveDetail();
            EventManager.PushEvent(new UIEvent(this.Name, EventType.HoverLeave));
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

        //Extend as necessary
        public void RecieveEvent(UIEvent e)
        {
            foreach (EventResponse response in EventResponses)
            {
                if (EventManager.EventsAreEqual(response.UIEvent, e))
                {
                    this.ExecuteEventResponse(response.Action);
                }
            }
        }

        private void ExecuteEventResponse(string action)
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
