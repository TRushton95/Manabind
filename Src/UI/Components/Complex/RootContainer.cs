using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Xml.Serialization;
using Manabind.Src.UI.Serialisation;
using System.IO;
using System.Xml;
using Manabind.Src.UI.Components.BaseInstanceResources;
using Manabind.Src.UI.PositionProfiles;

namespace Manabind.Src.UI.Components.Complex
{
    public class RootContainer : BaseComplexComponent
    {
        #region Constructors

        public RootContainer()
            : base()
        {
            this.Width = Settings.WindowWidth;
            this.Height = Settings.WindowHeight;
            this.PositionProfile = new AbsolutePositionProfile(0, 0);
        }

        #endregion

        #region Properties

        public List<BaseComplexComponent> Components
        {
            get;
            set;
        }

        #endregion

        #region Methods

        public void LoadUI(string fileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ComponentList));

            string path = String.Concat(AppSettings.UIDefinitionPath, "/", fileName);
            using (StreamReader reader = new StreamReader(path))
            {
                ComponentList componentList = (ComponentList)serializer.Deserialize(reader);
                Components = componentList.Components;
            }

            if (Components.Count == 0)
            {
                throw new XmlException("Failed to deserialise ui definition.");
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            foreach (BaseComplexComponent component in Components)
            {
                component.Draw(spriteBatch);
            }
        }

        public override void Initialise()
        {
            foreach (BaseComplexComponent component in Components)
            {
                component.Initialise();
            }
        }

        public override void OnHover()
        {
        }

        public override void OnHoverLeave()
        {
        }

        #endregion
    }
}
