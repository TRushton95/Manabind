﻿using Manabind.Src.UI.Events;
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

        public void PushEvent(UIEvent e)
        {
            foreach (EventResponse response in EventResponses)
            {
                if (Utility.EventsDetailsAreEqual(response.Trigger, e.EventDetails))
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
