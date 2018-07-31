using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Manabind.Src.Gameplay.Entities
{
    public abstract class BaseEntity
    {
        #region Constructors

        public BaseEntity(int canvasX, int canvasY, Texture2D texture)
        {
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

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.Texture, new Vector2(CanvasX, CanvasY), Color.White);
        }

        #endregion
    }
}
