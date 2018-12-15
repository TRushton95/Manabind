using Manabind.Src.UI.Enums;
using Manabind.Src.UI.Events;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Manabind.Src.Gameplay.Entities
{
    public abstract class BaseEntity : Listener
    {
        #region Constructors

        public BaseEntity(string name, int posX, int posY, int canvasX, int canvasY, Texture2D texture)
        {
            this.Name = name;
            this.PosX = posX;
            this.PosY = posY;
            this.CanvasX = canvasX;
            this.CanvasY = canvasY;
            this.Texture = texture;
        }

        #endregion

        #region Properties

        public int PosX
        {
            get;
            set;
        }

        public int PosY
        {
            get;
            set;
        }

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

        public virtual void Draw(SpriteBatch spriteBatch, Vector2 offset = default(Vector2))
        {
            spriteBatch.Draw(this.Texture, new Vector2(CanvasX, CanvasY) + offset, Color.White);
        }

        public void Hover()
        {
            EventManager.PushEvent(
                new UIEvent(new EventDetails(this.Name, EventType.Hover), this));
        }

        public void HoverLeave()
        {
            EventManager.PushEvent(
                new UIEvent(new EventDetails(this.Name, EventType.HoverLeave), this));
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
