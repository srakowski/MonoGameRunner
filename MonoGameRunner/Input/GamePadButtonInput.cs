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
using PixelVisionSDK.Chips;
using MG = Microsoft.Xna.Framework.Input;

namespace MonoGameRunner.Input
{
    /// <summary>
    ///     This class helps capture gamepad input and needs to be registered with the ControllerChip.
    /// </summary>
    /// <example>
    ///     controllerChip.UpdateControllerKey(0, new GamePadButtonInput(Button.A);
    /// </example>
    public class GamePadButtonInput : ButtonState
    {
        public GamePadButtonInput(Buttons buttons)
        {
            this.buttons = buttons;
        }

        public override void Update(float timeDelta)
        {
            switch (this.buttons)
            {
                case Buttons.Up: value = InputStates.CurrGamePadState.DPad.Up == MG.ButtonState.Pressed; break;
                case Buttons.Down: value = InputStates.CurrGamePadState.DPad.Down == MG.ButtonState.Pressed; break;
                case Buttons.Left: value = InputStates.CurrGamePadState.DPad.Left == MG.ButtonState.Pressed; break;
                case Buttons.Right: value = InputStates.CurrGamePadState.DPad.Right == MG.ButtonState.Pressed; break;
                case Buttons.A: value = InputStates.CurrGamePadState.Buttons.A == MG.ButtonState.Pressed; break;
                case Buttons.B: value = InputStates.CurrGamePadState.Buttons.B == MG.ButtonState.Pressed; break;
                case Buttons.Start: value = InputStates.CurrGamePadState.Buttons.Start == MG.ButtonState.Pressed; break;
                case Buttons.Select: value = InputStates.CurrGamePadState.Buttons.Back == MG.ButtonState.Pressed; break;
            }
            base.Update(timeDelta);
        }

    }
}