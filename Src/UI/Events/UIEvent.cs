using Manabind.Src.UI.Enums;

namespace Manabind.Src.UI.Events
{
    public class UIEvent
    {
        #region Constructors

        public UIEvent(string sender, EventType eventType)
        {
            this.Sender = sender;
            this.EventType = eventType;
        }

        #endregion

        #region Properties

        public string Sender { get; }

        public EventType EventType { get; }

        #endregion
    }
}
