using Manabind.Src.UI.PositionProfiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Xml.Serialization;
using Manabind.Src.UI.Components.BaseInstanceResources;

namespace Manabind.Src.UI.Components.Basic
{
    public abstract class BaseComponent : BaseInstance
    {
        #region Fields

        protected int posX, posY;

        #endregion

        #region Constructors

        public BaseComponent()
        {
        }

        public BaseComponent(BasePositionProfile positionProfile)
        {
            this.PositionProfile = positionProfile;
        }

        #endregion

        #region Properties

        [XmlAttribute("width")]
        public int Width
        {
            get;
            set;
        }

        [XmlAttribute("height")]
        public int Height
        {
            get;
            set;
        }
        
        [XmlElement(typeof(RelativePositionProfile))]
        [XmlElement(typeof(AbsolutePositionProfile))]
        public BasePositionProfile PositionProfile
        {
            get;
            set;
        }

        #endregion

        #region Methods

        public abstract void Update();

        public abstract void Draw(SpriteBatch spriteBatch);

        public abstract void Initialise(Rectangle parent);

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

        protected void InitialiseCoordinates(Rectangle parent)
        {
            Vector2 coords = this.PositionProfile.GetCoordinates(parent, this.GetBounds());

            this.posX = (int)coords.X;
            this.posY = (int)coords.Y;
        }

        #endregion
    }
}
