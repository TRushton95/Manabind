using Manabind.Src.UI.Components;
using System.Collections.Generic;
using System.IO;
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
            XmlSerializer serializer = new XmlSerializer(typeof(List<BaseComponent>));

            string path = Path.Combine(Appsettings.UIDefinitionPath, fileName);
            using (StreamReader reader = new StreamReader(path))
            {
                baseFrame.Components = (List<BaseComponent>)serializer.Deserialize(reader);
            }
        }

        #endregion
    }
}
