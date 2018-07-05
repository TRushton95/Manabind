using Manabind.Src.UI.Enums;
using System.Xml.Serialization;

namespace Manabind.Src.UI.Events
{
    public class EventDetails
    {
        #region Constructors

        public EventDetails()
        {
        }

        public EventDetails(string sender, EventType eventType)
        {
            this.Sender = sender;
            this.EventType = EventType;
        }

        #endregion

        #region Properties

        [XmlAttribute("sender")]
        public string Sender
        {
            get;
            set;
        }


        [XmlAttribute("eventtype")]
        public EventType EventType
        {
            get;
            set;
        }

        #endregion
    }
}
