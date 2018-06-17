using Manabind.Src.UI.Components;
using Manabind.Src.UI.Serialisation;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace Manabind.Src.UI.Components
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

        public void Initialise(GraphicsDevice device)
        {
            this.InitialiseResources(device);

            foreach (BaseComponent component in components)
            {
                //initialise components
            }
        }

        #endregion
    }
}
