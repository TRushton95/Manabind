namespace Manabind.Src.UI.Events
{
    public class EventResponse
    {
        #region Constructors

        public EventResponse()
        {
        }

        public EventResponse(EventDetails trigger, string action)
        {
            this.Trigger = trigger;
            this.Action = action;
        }

        #endregion

        #region Properties

        public EventDetails Trigger
        {
            get;
            set;
        }

        public string Action
        {
            get;
            set;
        }

        #endregion
    }
}
