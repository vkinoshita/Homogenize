using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace WindowsGame1
{
    class ClickWatcher
    {
        bool wasDown = false;
        Action<int, int> callback;

        public ClickWatcher(Action<int, int> callback)
        {
            this.callback = callback;
        }

        internal void Check(MouseState mouseState)
        {
            bool isDown = mouseState.LeftButton == ButtonState.Pressed;

            if (wasDown && !isDown)
            {
                callback(mouseState.X, mouseState.Y);
            }

            wasDown = isDown;
        }

    }
}
