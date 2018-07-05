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

        /// <summary>
        /// The event details that trigger an action from the listener
        /// </summary>
        public EventDetails Trigger
        {
            get;
            set;
        }

        /// <summary>
        /// The name of the action that will be executed when triggered by the corresponding event details
        /// </summary>
        public string Action
        {
            get;
            set;
        }

        #endregion
    }
}
