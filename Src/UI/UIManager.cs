using Manabind.Src.UI.Components;
using System.Collections.Generic;
using System.Linq;

namespace Manabind.Src.UI
{
    public class UIManager
    {
        #region Fields

        private List<BaseComponent> components;

        #endregion

        #region Constructors

        public UIManager()
        {
            this.components = new List<BaseComponent>();
        }

        #endregion

        #region Methods

        public BaseComponent GetById(string id)
        {
            return this.components.SingleOrDefault(component => component.Id == id);
        }

        public List<BaseComponent> GetAll()
        {
            return this.components;
        }

        public void AddComponent(BaseComponent component)
        {
            this.components.Add(component);
        }

        public void RemoveComponent(BaseComponent component)
        {
            this.components.Remove(component);
        }

        public void LoadFromXml(string filePath)
        {
            //To be implemented
        }

        #endregion
    }
}
