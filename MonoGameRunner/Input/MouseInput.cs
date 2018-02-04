//   
// Copyright (c) Jesse Freeman. All rights reserved.  
//  
// Licensed under the Microsoft Public License (MS-PL) License. 
// See LICENSE file in the project root for full license information. 
// 
// Contributors
// --------------------------------------------------------
// This is the official list of Pixel Vision 8 contributors:
//  
// Jesse Freeman - @JesseFreeman
// Christer Kaitila - @McFunkypants
// Pedro Medeiros - @saint11
// Shawn Rakowski - @shwany

using PixelVisionSDK;
using Microsoft.Xna.Framework.Input;
using ButtonState = Microsoft.Xna.Framework.Input.ButtonState;
using MonoGameRunner.Input;

namespace MonoGameRunner.Input
{
    /// <summary>
    ///     This class helps capture mouse input and needs to be registered with the ControllerChip.
    /// </summary>
    /// <example>
    ///     controllerChip.RegisterMouseInput(new MouseInput(displayTarget.rectTransform));
    /// </example>
    class MouseInput : IMouseInput
    {
        protected DisplayTarget displayTarget;

        public MouseInput(DisplayTarget displayTarget)
        {
            this.displayTarget = displayTarget;
        }

        public Vector ReadMousePosition()
        {
            var state = InputStates.CurrMouseState;
            var pos = displayTarget.ViewportAdapter.PointToScreen(state.Position);
            return new Vector(pos.X, pos.Y);
        }

        public bool GetMouseButton(int button)
        {
            return GetMouseButtonInState(InputStates.CurrMouseState, button, ButtonState.Released) &&
                GetMouseButtonInState(InputStates.PrevMouseState, button, ButtonState.Pressed);
        }

        public bool GetMouseButtonDown(int button)
        {
            var isDown = GetMouseButtonInState(InputStates.CurrMouseState, button, ButtonState.Pressed);
            return isDown;
        }

        public bool GetMouseButtonUp(int button)
        {
            var isUp = GetMouseButtonInState(InputStates.CurrMouseState, button, ButtonState.Released);
            return isUp;
        }

        // NOTE: this interface seems somewhat coupled to Unity's way of doing things....
        private enum MouseButton
        {
            Left = 0,
            Right,
            Middle
        }

        private static bool GetMouseButtonInState(MouseState state, int button, ButtonState buttonState)
        {
            var inState = false;
            switch ((MouseButton)button)
            {
                case MouseButton.Left:
                    inState = state.LeftButton == buttonState;
                    break;
                case MouseButton.Right:
                    inState = state.RightButton == buttonState;
                    break;
                case MouseButton.Middle:
                    inState = state.MiddleButton == buttonState;
                    break;
            }
            return inState;
        }
    }
}