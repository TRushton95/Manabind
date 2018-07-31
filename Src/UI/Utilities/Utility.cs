using Manabind.Src.UI.Events;
using System;

namespace Manabind.Src.UI.Utilities
{
    public static class Utility
    {
        public static bool EventDetailsMatch(EventDetails pushedEvent, EventDetails triggerEvent)
        {
            bool result = false;

            if (pushedEvent != null && triggerEvent != null &&
                SenderMatch(pushedEvent.Sender, triggerEvent.Sender) &&
                pushedEvent.EventType == triggerEvent.EventType)
            {
                result = true;
            }

            return result;
        }

        private static bool SenderMatch(string pushedSender, string triggerSender)
        {
            return String.Equals(pushedSender, triggerSender) || String.Equals(triggerSender, EventManager.Wildcard);
        }
    }
}
