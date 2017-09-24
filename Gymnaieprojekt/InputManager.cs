using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

// ReSharper disable InconsistentNaming

namespace Gymnaieprojekt
{
    public static class InputManager
    {
        private static KeyboardState keyState;
        private static KeyboardState priorKeyState;

        private static MouseState mouseState;
        private static MouseState priorMouseState;

        private static readonly Dictionary<MouseButtons, Func<MouseState, ButtonState>> mouseButtonMaps;

        static InputManager()
        {
            mouseButtonMaps = new Dictionary<MouseButtons, Func<MouseState, ButtonState>>
            {
                { MouseButtons.Left, s => s.LeftButton },
                { MouseButtons.Right, s => s.RightButton },
                { MouseButtons.Middle, s => s.MiddleButton },
                { MouseButtons.X1, s => s.XButton1 },
                { MouseButtons.X2, s => s.XButton2 }
            };
        }

        public static void Update(GameTime gameTime)
        {
            priorKeyState = keyState;
            keyState = Keyboard.GetState();

            priorMouseState = mouseState;
            mouseState = Mouse.GetState();
        }

        public static bool IsKeyPressed(Keys key)
        {
            return keyState.IsKeyDown(key) && priorKeyState.IsKeyUp(key);
        }

        public static bool IsKeyDown(Keys key)
        {
            return keyState.IsKeyDown(key);
        }

        public static bool IsScrollingDown()
        {
            return mouseState.ScrollWheelValue < priorMouseState.ScrollWheelValue;
        }

        public static bool IsScrollingUp()
        {
            return mouseState.ScrollWheelValue > priorMouseState.ScrollWheelValue;
        }

        public static bool IsMouseKeyClicked(MouseButtons key)
        {
            return mouseButtonMaps[key](mouseState) == ButtonState.Pressed &&
                   mouseButtonMaps[key](priorMouseState) == ButtonState.Released;
        }

        public static bool IsMouseKeyDown(MouseButtons key)
        {
            return mouseButtonMaps[key](mouseState) == ButtonState.Pressed;
        }
    }

    public enum MouseButtons
    {
        Left,
        Right,
        Middle,
        X1,
        X2
    }
}
