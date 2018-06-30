namespace Manabind.Src.UI.Events
{
    public class EventResponse
    {
        #region Constructors

        public EventResponse(string action, UIEvent uiEvent)
        {
            this.Action = action;
            this.UIEvent = uiEvent;
        }

        #endregion

        #region Properties

        public string Action { get; }

        public UIEvent UIEvent { get; }

        #endregion
    }
}
