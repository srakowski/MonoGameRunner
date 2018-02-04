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
using Microsoft.Xna.Framework;
using Keys = Microsoft.Xna.Framework.Input.Keys;

namespace MonoGameRunner.Input
{
    public class KeyInput : IKeyInput
    {
        public bool GetKey(int key)
        {
            return InputStates.CurrKeyboardState.IsKeyDown((Keys)key) &&
                InputStates.PrevKeyboardState.IsKeyUp((Keys)key);
        }

        public bool GetKeyDown(int key)
        {
            return InputStates.CurrKeyboardState.IsKeyDown((Keys)key);
        }

        public bool GetKeyUp(int key)
        {
            return InputStates.CurrKeyboardState.IsKeyUp((Keys)key);
        }

        public string ReadInputString()
        {
            return InputStates.TextInput;
        }
    }
}