using Manabind.Src.UI.Components.Complex;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Manabind.Src.UI.Events
{
    public static class EventManager
    {
        #region Fields

        private static List<BaseComplexComponent> listeners;

        #endregion

        #region Static Constructors

        static EventManager()
        {
            listeners = new List<BaseComplexComponent>();
        }

        #endregion

        #region Methods

        public static void Subscribe(BaseComplexComponent subscriber)
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

        public static void PushEvent(UIEvent e)
        {
            List<BaseComplexComponent> relevantListeners = new List<BaseComplexComponent>();

            foreach (BaseComplexComponent listener in listeners)
            {
                List<EventResponse> responses = listener.EventResponses;

                if (responses.Any(response => String.Equals(e.Sender, response.UIEvent.Sender)))
                {
                    relevantListeners.Add(listener);
                }
            }

            foreach (BaseComplexComponent listener in relevantListeners)
            {
                listener.RecieveEvent(e);
            }
        }

        #endregion
    }
}
