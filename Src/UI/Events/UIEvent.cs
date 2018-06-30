﻿using Manabind.Src.UI.Enums;
using System.Xml.Serialization;

namespace Manabind.Src.UI.Events
{
    public class UIEvent
    {
        #region Constructors

        public UIEvent()
        {
        }

        public UIEvent(string sender, EventType eventType)
        {
            this.Sender = sender;
            this.EventType = eventType;
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
