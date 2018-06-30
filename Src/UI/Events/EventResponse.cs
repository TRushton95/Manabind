using System.Collections.Generic;

namespace Manabind.Src.UI.Events
{
    public class EventResponse
    {
        #region Constructors

        public EventResponse()
        {
        }

        public EventResponse(UIEvent uiEvent, string action)
        {
            this.UIEvent = uiEvent;
            this.Action = action;
        }

        #endregion

        #region Properties

        public UIEvent UIEvent
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
