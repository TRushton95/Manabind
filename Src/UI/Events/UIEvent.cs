namespace Manabind.Src.UI.Events
{
    public class UIEvent
    {
        #region Constructors

        public UIEvent()
        {
        }

        public UIEvent(EventDetails eventDetails, object content)
        {
            this.EventDetails = eventDetails;
            this.Content = content;
        }

        #endregion

        #region Properties

        public EventDetails EventDetails
        {
            get;
            set;
        }

        public object Content
        {
            get;
            set;
        }

        #endregion
    }
}
