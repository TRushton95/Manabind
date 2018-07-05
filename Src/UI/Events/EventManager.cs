using Manabind.Src.UI.Components.BaseInstanceResources;
using Manabind.Src.UI.Components.Complex;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Manabind.Src.UI.Events
{
    public static class EventManager
    {
        #region Fields

        private static List<Listener> listeners;

        #endregion

        #region Static Constructors

        static EventManager()
        {
            listeners = new List<Listener>();
        }

        #endregion

        #region Methods

        public static void Subscribe(Listener subscriber)
        {
            if (!listeners.Contains(subscriber))
            {
                listeners.Add(subscriber);
            }
        }

        public static void Unsubscribe(BaseComplexComponent unsubscriber)
        {
            if (listeners.Contains(unsubscriber))
            {
                listeners.Remove(unsubscriber);
            }
        }

        public static void ClearListeners()
        {
            listeners.Clear();
        }

        public static void PushEvent(EventDetails e)
        {
            List<Listener> relevantListeners = new List<Listener>();

            foreach (Listener listener in listeners)
            {
                List<EventResponse> responses = listener.EventResponses;

                if (responses.Any(response => String.Equals(e.Sender, response.Trigger.Sender)))
                {
                    relevantListeners.Add(listener);
                }
            }

            foreach (Listener listener in relevantListeners)
            {
                listener.PushEvent(e);
            }
        }

        #endregion
    }
}
