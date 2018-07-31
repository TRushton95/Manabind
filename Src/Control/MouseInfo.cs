using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Manabind.Src.Control
{
    public static class MouseInfo
    {
        #region Fields

        private static MouseState prevMouseState, currentMouseState;

        #endregion

        #region Constructors

        static MouseInfo()
        {
            prevMouseState = Mouse.GetState();
            currentMouseState = Mouse.GetState();
        }

        #endregion

        #region Properties

        public static int X => currentMouseState.X;

        public static int Y => currentMouseState.Y;

        public static Vector2 Position => new Vector2(X, Y);

        public static int PrevX => prevMouseState.X;

        public static int PrevY => prevMouseState.Y;

        public static Vector2 PrevPosition => new Vector2(PrevX, PrevY);

        public static bool LeftMouseDown => currentMouseState.LeftButton == ButtonState.Pressed;

        public static bool RightMouseDown => currentMouseState.RightButton == ButtonState.Pressed;

        public static bool PrevLeftMouseDown => prevMouseState.LeftButton == ButtonState.Pressed;

        public static bool PrevRightMouseDown => prevMouseState.LeftButton == ButtonState.Pressed;

        public static bool LeftMouseClicked => LeftMouseDown && !PrevLeftMouseDown;

        public static bool RightMouseClicked => RightMouseDown && !PrevRightMouseDown;

        #endregion

        #region Methods

        public static void Update()
        {
            prevMouseState = currentMouseState;
            currentMouseState = Mouse.GetState();
        }

        #endregion
    }
}
