using Manabind.Src.UI.Events;
using System;

namespace Manabind.Src.UI.Utilities
{
    public static class Utility
    {
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
    }
}
