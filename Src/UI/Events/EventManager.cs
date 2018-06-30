using Manabind.Src.UI.Components.Complex;
using System.Collections.Generic;

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

        }

        #endregion
    }
}
