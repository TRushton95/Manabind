using Manabind.Src.UI.Components.Complex;
using Manabind.Src.UI.Serialisation;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Manabind.Src.UI.Components
{
    public class ComponentManager
    {
        #region Fields

        private RootContainer root;
        private List<BaseComplexComponent> components;

        #endregion

        #region Constructor

        public ComponentManager()
        {
            this.root = new RootContainer();
            this.components = new List<BaseComplexComponent>();
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
                root.Components = componentList.Components;
            }

            if (root.Components.Count == 0)
            {
                throw new XmlException("Failed to deserialise ui definition.");
            }

            components.AddRange(root.BuildTree());
        }

        public void InitialiseResources(GraphicsDevice device, ContentManager content, int windowWidth, int windowHeight)
        {
            this.root.InitialiseResources(device, content, windowWidth, windowHeight);
        }

        public void Initialise()
        {
            this.root.Initialise();
        }

        public RootContainer GetRoot()
        {
            return this.root;
        }

        #endregion
    }
}
