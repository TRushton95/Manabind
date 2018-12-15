using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Manabind.Src.Gameplay.Entities
{
    public class Camera
    {
        #region Fields

        private int CameraVelocity = 10;

        #endregion

        #region Constructors

        public Camera(int canvasX, int canvasY, int width, int height)
        {
            this.CanvasX = canvasX;
            this.CanvasY = canvasY;
            this.Width = width;
            this.Height = height;
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

        private bool Enabled
        {
            get;
            set;
        }

        #endregion

        #region Methods

        public void Draw(Board board, SpriteBatch spritebatch)
        {
            Vector2 offset = new Vector2(-CanvasX, -CanvasY);

            board.Draw(spritebatch, offset);
        }

        public void Update()
        {
            if (!this.Enabled)
            {
                return;
            }

            KeyboardState keyboard = Keyboard.GetState();

            if (keyboard.IsKeyDown(Keys.W))
            {
                CanvasY -= CameraVelocity;
            }
            if (keyboard.IsKeyDown(Keys.A))
            {
                CanvasX -= CameraVelocity;
            }
            if (keyboard.IsKeyDown(Keys.S))
            {
                CanvasY += CameraVelocity;
            }
            if (keyboard.IsKeyDown(Keys.D))
            {
                CanvasX += CameraVelocity;
            }
        }

        public Vector2 GetAbsoluteMousePosition(Vector2 mousePosition)
        {
            return new Vector2(mousePosition.X + CanvasX, mousePosition.Y + CanvasY);
        }

        public Vector2 GetAbsoluteEntityPosition(Vector2 position)
        {
            return new Vector2(position.X - CanvasX, position.Y - CanvasY);
        }

        public void Reset()
        {
            this.CanvasX = 0;
            this.CanvasY = 0;
        }

        public void Enable()
        {
            this.Enabled = true;
        }

        public void Disable()
        {
            this.Enabled = false;
        }

        #endregion
    }
}
