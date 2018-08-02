using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
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

        public static bool IsKeyPressed(Keys key) => currentKeyboardState.IsKeyDown(key) && !prevKeyboardState.IsKeyDown(key);

        public static Keys[] GetDownkeys() => currentKeyboardState.GetPressedKeys();

        public static bool IsShifted() => currentKeyboardState.CapsLock || currentKeyboardState.IsKeyDown(Keys.LeftShift) || currentKeyboardState.IsKeyDown(Keys.RightShift);


        public static char KeyToChar(Keys key)
        {
            char result = Char.MinValue;

            string s = IsShifted() ? key.ToString().ToUpper() : key.ToString().ToLower();

            if (s.Length == 1)
            {
                char c = Char.Parse(s);

                if (c >= 'a' && c <= 'z' ||
                    c >= 'A' && c <= 'Z')
                {
                    result = c;
                }
            }

            return result;
        }

        public static char[] KeysToChars(Keys[] keys)
        {
            List<char> result = new List<char>();

            foreach (Keys c in keys)
            {
                char newChar = KeyToChar(c);

                if (newChar != Char.MinValue)
                {
                    result.Add(newChar);
                }
            }

            return result.ToArray();
        }

        // Xna defines pressed as currently down
        // This defines pressed as is currently down but was not previously down
        public static Keys[] GetPressedKeys() => currentKeyboardState.GetPressedKeys().Where(key => IsKeyPressed(key)).ToArray();

        public static bool CapsLock => currentKeyboardState.CapsLock;

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
