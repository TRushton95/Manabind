using Manabind.Src.UI.PositionProfiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Xml.Serialization;

namespace Manabind.Src.UI.Components
{
    public abstract class BaseComponent : BaseResourceInstance
    {
        #region Fields

        protected int posX, posY;

        #endregion

        #region Constructors

        public BaseComponent()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public BaseComponent(string parentId, BasePositionProfile positionProfile)
        {
            this.ParentId = parentId;
            this.PositionProfile = positionProfile;

            this.Id = Guid.NewGuid().ToString();
        }

        #endregion

        #region Properties

        [XmlIgnore]
        public string Id
        {
            get;
            set;
        }

        [XmlIgnore]
        public string ParentId
        {
            get;
            set;
        }

        public int Width
        {
            get;
            set;
        }

        public int Height
        {
            get;
            set;
        }

        [XmlElement(typeof(RelativePositionProfile))]
        public BasePositionProfile PositionProfile
        {
            get;
            set;
        }

        #endregion

        #region Methods

        public abstract void Draw(SpriteBatch spriteBatch);

        public abstract void Initialise();

        public Vector2 GetCoordinates()
        {
            return new Vector2(this.posX, this.posY);
        }

        public Vector2 GetSize()
        {
            return new Vector2(this.Width, this.Height);
        }

        public Rectangle GetBounds()
        {
            return new Rectangle(this.posX, this.posY, this.Width, this.Height);
        }

        protected void InitialiseCoordinates()
        {
            //TODO this.Position.GetCoordinates
        }

        #endregion
    }
}
