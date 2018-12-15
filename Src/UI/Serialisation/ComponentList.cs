using Manabind.Src.UI.Components.Complex;
using Manabind.Src.UI.Components.Complex.ListItems;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Manabind.Src.UI.Serialisation
{
    public class ComponentList
    {
        [XmlArrayItem(typeof(Container))]
        [XmlArrayItem(typeof(Button))]
        [XmlArrayItem(typeof(Heading))]
        [XmlArrayItem(typeof(Toolbar))]
        [XmlArrayItem(typeof(Tooltip))]
        [XmlArrayItem(typeof(Textbox))]
        [XmlArrayItem(typeof(TextboxListItem))]
        public List<BaseComplexComponent> Components
        {
            get;
            set;
        }
    }
}
