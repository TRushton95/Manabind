using Manabind.Src.UI.PositionProfiles;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Xml.Serialization;
using Manabind.Src.UI.Serialisation;
using System.IO;

namespace Manabind.Src.UI.Components.Complex
{
    public class RootContainer : BaseComplexComponent
    {
        #region Constructors

        public RootContainer()
            : base()
        {
        }

        public RootContainer(int width, int height, BasePositionProfile positionProfile)
            : base(width, height, positionProfile)
        {
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
