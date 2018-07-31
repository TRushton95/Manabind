using Manabind.Src.UI.Components.BaseInstanceResources;
using Manabind.Src.UI.Enums;
using Manabind.Src.UI.Events;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Manabind.Src.Gameplay.Entities
{
    public abstract class BaseEntity : Listener
    {
        #region Constructors

        public BaseEntity(string name, int canvasX, int canvasY, Texture2D texture)
        {
            this.Name = name;
            this.CanvasX = canvasX;
            this.CanvasY = canvasY;
            this.Texture = texture;
        }

        #endregion

        #region Properties

        public int CanvasX
        {
            get;
            set;
        }

        public int CanvasY
        {
            get;
            set;
        }

        public Texture2D Texture
        {
            get;
            set;
        }

        #endregion

        #region Methods

        public void Draw(SpriteBatch spriteBatch, Vector2 offset = default(Vector2))
        {
            spriteBatch.Draw(this.Texture, new Vector2(CanvasX, CanvasY) + offset, Color.White);
        }

        public void Click()
        {
            EventManager.PushEvent(
                new UIEvent(new EventDetails(this.Name, EventType.LeftClick), this));
        }

        public void LeftMouseDown()
        {
            EventManager.PushEvent(
                new UIEvent(new EventDetails(this.Name, EventType.LeftMouseDown), this));
        }

        #endregion
    }
}
