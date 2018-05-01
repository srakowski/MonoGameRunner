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
// 

using PixelVisionRunner.Chips.Sfxr;

namespace MonoGameRunner.Audio
{
    class AudioPlayerFactory : IAudioPlayerFactory
    {
        public IAudioPlayer Create(ISfxrSynth synth)
        {
            return new AudioPlayer(synth);
        }
    }
}
