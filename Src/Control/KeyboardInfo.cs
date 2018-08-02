using Microsoft.Xna.Framework.Input;
using System.Linq;

namespace Manabind.Src.Control
{
    public static class KeyboardInfo
    {
        #region Fields

        private static KeyboardState prevKeyboardState, currentKeyboardState;

        #endregion

        #region Properties

        public static bool IsKeyDown(Keys key) => currentKeyboardState.IsKeyDown(key);

        public static bool WasKeyDown(Keys key) => prevKeyboardState.IsKeyDown(key) && !IsKeyDown(key);

        public static bool IsKeyPressed(Keys key) => IsKeyDown(key) && !WasKeyDown(key);

        public static Keys[] GetDownkeys() => currentKeyboardState.GetPressedKeys();

        // Xna defines pressed as currently down
        // This defines pressed as is currently down but was not previously down
        public static Keys[] GetPressedKeys() => currentKeyboardState.GetPressedKeys().Where(key => IsKeyPressed(key)).ToArray();

        #endregion

        #region Methods

        public static void Update()
        {
            prevKeyboardState = currentKeyboardState;
            currentKeyboardState = Keyboard.GetState();
        }

        #endregion
    }
}
