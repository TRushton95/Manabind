using Manabind.Src.UI.Serialisation;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System;

namespace Manabind.Src.UI.Components.Basic
{
    public class RootComponent : BaseComponent
    {
        #region Fields

        private List<BaseComponent> components;

        #endregion

        #region Constructors

        public RootComponent()
        {
            this.components = new List<BaseComponent>();
        }

        #endregion

        #region Methods

        public override void Draw(SpriteBatch spriteBatch)
        {
            foreach (BaseComponent component in components)
            {
                component.Draw(spriteBatch);
            }
        }

        public override void Initialise()
        {
            foreach (BaseComponent component in components)
            {
                component.Initialise();
            }
        }

        public void LoadUI(string fileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ComponentList));

            //TODO this should use architecture agnostic pathing
            string path = string.Join("/", AppSettings.UIDefinitionPath, fileName);
            using (StreamReader reader = new StreamReader(path))
            {
                ComponentList cl = (ComponentList)serializer.Deserialize(reader);
                components = cl.Components;
            }

            if (components.Count == 0)
            {
                throw new XmlException("Failed to deserialise ui definition.");
            }
        }

        #endregion
    }
}
