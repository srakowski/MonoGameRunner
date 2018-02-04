﻿//   
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

using System;
using PixelVisionSDK;

/// <summary>
///     This class helps capture mouse input and needs to be registered with the ControllerChip.
/// </summary>
/// <example>
///     controllerChip.RegisterMouseInput(new MouseInput(displayTarget.rectTransform));
/// </example>
public class MouseInput : IMouseInput
{
    public bool GetMouseButtonDown(int button)
    {
        throw new NotImplementedException();
    }

    public bool GetMouseButtonUp(int button)
    {
        throw new NotImplementedException();
    }

    public Vector ReadMousePosition()
    {
        throw new NotImplementedException();
    }
}