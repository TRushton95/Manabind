using Manabind.Src.UI.Events;
using Manabind.Src.UI.Utilities;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Manabind.Src.UI.Components.BaseInstanceResources
{
    public abstract class Listener
    {
        #region Constructor

        public Listener()
        {
            this.EventResponses = new List<EventResponse>();
            EventManager.Subscribe(this);
        }

        #endregion

        #region Properties

        [XmlArrayItem(typeof(EventResponse))]
        public List<EventResponse> EventResponses
        {
            get;
            set;
        }

        #endregion

        #region Methods

        public void PushEvent(EventDetails e)
        {
            foreach (EventResponse response in EventResponses)
            {
                if (Utility.EventsDetailsAreEqual(response.Trigger, e))
                {
                    this.ExecuteEventResponse(response.Action);
                }
            }
        }

        protected virtual void ExecuteEventResponse(string action)
        {
        }

        #endregion
    }
}
