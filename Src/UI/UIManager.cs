using Manabind.Src.UI.Components;
using Manabind.Src.UI.Serialisation;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Manabind.Src.UI
{
    public class UIManager
    {
        #region Fields

        private Frame baseFrame;

        #endregion

        #region Constructors

        public UIManager()
        {
            this.baseFrame = new Frame();
        }

        #endregion

        #region Properties



        #endregion

        #region Methods

        public void LoadUI(string fileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ComponentList));

            //TODO this should use architecture agnostic pathing
            string path = string.Join("/", AppSettings.UIDefinitionPath, fileName);
            using (StreamReader reader = new StreamReader(path))
            {
                ComponentList cl = (ComponentList)serializer.Deserialize(reader);
                baseFrame.Components = cl.Components;
            }

            if (baseFrame.Components.Count == 0)
            {
                throw new XmlException("Failed to deserialise ui definition.");
            }
        }

        #endregion
    }
}
