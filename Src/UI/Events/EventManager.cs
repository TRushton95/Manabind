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

        public static void ClearSubscribers()
        {
            listeners.Clear();
        }

        public static void PushEvent(UIEvent e)
        {
            Console.WriteLine(String.Format("{0} pushing event: {1}", e.Sender, e.EventType));

            List<BaseComplexComponent> relevantSubscribers = new List<BaseComplexComponent>();

            foreach (BaseComplexComponent listener in listeners)
            {
                List<EventResponse> responses = listener.EventResponses;

                if (responses.Any(response => String.Equals(e.Sender, response.UIEvent.Sender)))
                {
                    relevantSubscribers.Add(listener);
                }
            }

            foreach (BaseComplexComponent listener in relevantSubscribers)
            {
                listener.RecieveEvent(e);
            }
        }

        public static bool EventsAreEqual(UIEvent e1, UIEvent e2)
        {
            bool result = false;

            if (e1 != null && e2 != null &&
                String.Equals(e1.Sender, e2.Sender) &&
                e1.EventType == e2.EventType)
            {
                result = true;
            }

            return result;
        }

        #endregion
    }
}
