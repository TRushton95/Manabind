using Manabind.Src.UI.Utilities;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Manabind.Src.UI.Events
{
    public abstract class Listener
    {
        #region Constructor

        public Listener()
        {
            this.PersistantListener = false;
            this.EventResponses = new List<EventResponse>();
        }

        #endregion

        #region Properties

        [XmlIgnore]
        public string Id
        {
            get;
            set;
        }

        [XmlIgnore]
        public string ParentId
        {
            get;
            set;
        }

        [XmlAttribute("name")]
        public string Name
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

        public bool PersistantListener
        {
            get;
            set;
        }

        #endregion

        #region Methods

        public void InitialiseListen(string parentId)
        {
            this.Id = Guid.NewGuid().ToString();
            this.ParentId = parentId;

            EventManager.Subscribe(this);
        }

        public void PushEvent(UIEvent e)
        {
            foreach (EventResponse response in EventResponses)
            {
                if (Utility.EventDetailsMatch(e.EventDetails, response.Trigger))
                {
                    this.ExecuteEventResponse(response.Action, e.Content);
                }
            }
        }

        protected virtual void ExecuteEventResponse(string action, object content)
        {
        }

        #endregion
    }
}
