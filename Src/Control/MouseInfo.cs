using Microsoft.Xna.Framework.Input;

namespace Manabind.Src.Control
{
    public class MouseInfo
    {
        #region Fields

        private MouseState prevMouseState, currentMouseState;

        #endregion

        #region Properties

        public int X => currentMouseState.X;

        public int Y => currentMouseState.Y;

        public int PrevX => prevMouseState.X;

        public int PrevY => prevMouseState.Y;

        public bool LeftMouseDown => currentMouseState.LeftButton == ButtonState.Pressed;

        public bool RightMouseDown => currentMouseState.RightButton == ButtonState.Pressed;

        public bool PrevLeftMouseDown => prevMouseState.LeftButton == ButtonState.Pressed;

        public bool PrevRightMouseDown => prevMouseState.LeftButton == ButtonState.Pressed;

        public bool LeftMouseClick => LeftMouseDown && !PrevLeftMouseDown;

        public bool RightMouseClick => RightMouseDown && !PrevRightMouseDown;

        #endregion

        #region Methods

        public void Update()
        {
            prevMouseState = currentMouseState;
            currentMouseState = Mouse.GetState();
        }

        #endregion
    }
}
