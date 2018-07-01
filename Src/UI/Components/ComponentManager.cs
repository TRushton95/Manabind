using Manabind.Src.UI.Components.Complex;
using Manabind.Src.UI.Events;
using Manabind.Src.UI.Serialisation;
using Microsoft.Xna.Framework;
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

            foreach (BaseComplexComponent component in components)
            {
                EventManager.Subscribe(component);
            }
        }

        public void InitialiseResources(GraphicsDevice device, ContentManager content)
        {
            this.root.InitialiseResources(device, content, AppSettings.WindowWidth, AppSettings.WindowHeight);
        }

        public void Initialise(Rectangle window)
        {
            this.root.Initialise(window);
        }

        public RootContainer GetRoot()
        {
            return this.root;
        }

        public List<BaseComplexComponent> GetAll()
        {
            return this.components;
        }

        #endregion
    }
}
