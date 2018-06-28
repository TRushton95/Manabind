using Manabind.Src.UI.Components.Basic;
using Manabind.Src.UI.Components.Complex;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Manabind.Src.UI.Serialisation
{
    public class ComponentList
    {
        [XmlArrayItem(typeof(Container))]
        [XmlArrayItem(typeof(Button))]
        public List<ComplexBaseComponent> Components
        {
            get;
            set;
        }
    }
}
