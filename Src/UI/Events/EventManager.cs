using Manabind.Src.UI.Components.BaseInstanceResources;
using Manabind.Src.UI.Components.Complex;
using Manabind.Src.UI.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Manabind.Src.UI.Events
{
    public static class EventManager
    {
        #region Constants

        public const string Wildcard = "*";

        #endregion

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

        public static void Unsubscribe(Listener unsubscriber)
        {
            IEnumerable<Listener> children = listeners.Where(listener => listener.ParentId == unsubscriber.Id);

            if (children.Count() > 0)
            {
                foreach (Listener child in children)
                {
                    Unsubscribe(child);
                }
            }
            
            if (listeners.Contains(unsubscriber))
            {
                listeners.Remove(unsubscriber);
            }
        }

        public static void ClearListeners()
        {
            if (listeners.Count == 0)
            {
                return;
            }

            Listener root = listeners[0];

            listeners.Clear();
            listeners.Add(root);
        }

        public static void PushEvent(UIEvent e)
        {
            List<Listener> relevantListeners = new List<Listener>();

            foreach (Listener listener in listeners)
            {
                List<EventResponse> listenerResponses = listener.EventResponses;

                if (listenerResponses.Any(listenerResponse => 
                    Utility.EventDetailsMatch(e.EventDetails, listenerResponse.Trigger)))
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
