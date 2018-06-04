using Manabind.Src.UI.PositionProfiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Manabind.Src.UI.Components
{
    public abstract class BaseComponent : BaseInstance
    {
        #region Fields

        protected int posX, posY, width, height;

        #endregion

        #region Constructors

        public BaseComponent()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public BaseComponent(string parentId, IPositionProfile positionProfile)
        {
            this.ParentId = parentId;
            this.PositionProfile = positionProfile;

            this.Id = Guid.NewGuid().ToString();
        }

        #endregion

        #region Properties

        public string Id
        {
            get;
            set;
        }

        public string ParentId
        {
            get;
            set;
        }

        public IPositionProfile PositionProfile
        {
            get;
            set;
        }

        #endregion

        #region Methods

        public abstract void Draw(SpriteBatch spriteBatch);

        public Vector2 GetCoordinates()
        {
            return new Vector2(this.posX, this.posY);
        }

        public Vector2 GetSize()
        {
            return new Vector2(this.width, this.height);
        }

        public Rectangle GetBounds()
        {
            return new Rectangle(this.posX, this.posY, this.width, this.height);
        }

        protected void InitialiseCoordinates()
        {
            //TODO this.Position.GetCoordinates
        }

        #endregion
    }
}
