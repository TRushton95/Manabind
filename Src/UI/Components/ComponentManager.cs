using Manabind.Src.UI.Components.Complex;
using Manabind.Src.UI.Events;
using Manabind.Src.UI.Serialisation;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

            RefreshTree(hardRefresh: true);
        }

        public void InitialiseResources(GraphicsDevice device, ContentManager content)
        {
            this.root.InitialiseResources(device, content);
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

        public List<BaseComplexComponent> GetDescendants(string id)
        {
            List<BaseComplexComponent> result = new List<BaseComplexComponent>();

            IEnumerable<BaseComplexComponent> children = components.Where(c => String.Equals(c.ParentId, id));

            foreach (BaseComplexComponent child in children)
            {
                result.AddRange(GetDescendants(child.Id));
            }

            result.AddRange(children);

            return result;
        }

        /// <summary>
        /// Hard refresh - Remove all subscribers except the game manager
        /// Soft refresh - Remove all subscribers that are NOT flagged as persistant listeners
        ///                (ie. appstate, board)
        /// After refresh, gather tree from root component and re-subscribe all components
        /// </summary>
        public void RefreshTree(bool hardRefresh)
        {
            if (hardRefresh)
            {
                EventManager.ClearListeners();
            }
            else
            {
                EventManager.ClearFlaggedListeners();
            }

            components = root.BuildTree();

            foreach (BaseComplexComponent component in components)
            {
                EventManager.Subscribe(component);
            }
        }

        #endregion
    }
}
