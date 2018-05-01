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

using Microsoft.Xna.Framework.Audio;
using PixelVisionRunner.Chips.Sfxr;
using System.IO;

namespace MonoGameRunner.Audio
{
    class AudioPlayer : IAudioPlayer
    {
        private SoundEffect _soundEffect;

        private SoundEffectInstance _soundEffectInstance;

        private bool _isDisposed = false;

        public AudioPlayer(ISfxrSynth synth)
        {
            var wavData = synth.GenerateWav();

            using (var stream = new MemoryStream(wavData))
            {
                _soundEffect = SoundEffect.FromStream(stream);
            }

            // may make these on a per-play instance at some point
            _soundEffectInstance = _soundEffect.CreateInstance();
        }

        public void Dispose()
        {
            if (_isDisposed) return;
            _soundEffectInstance.Stop();
            _soundEffectInstance.Dispose();
            _soundEffect.Dispose();
            _isDisposed = true;
        }

        public void Play()
        {
            _soundEffectInstance.Play();
        }

        public void Stop()
        {
            _soundEffectInstance.Stop();
        }
    }
}
