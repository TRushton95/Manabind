using Manabind.Src.UI.Components.Complex;
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
        public List<BaseComplexComponent> Components
        {
            get;
            set;
        }
    }
}
