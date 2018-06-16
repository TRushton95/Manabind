using Manabind.Src.UI.Components;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Manabind.Src.UI.Serialisation
{
    public class ComponentList
    {
        [XmlArrayItem(typeof(Frame))]
        [XmlArrayItem(typeof(TextBox))]
        public List<BaseComponent> Components
        {
            get;
            set;
        }
    }
}
