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

using PixelVisionRunner.Chips.Sfxr;
using PixelVisionSDK;

namespace PixelVisionRunner.Data
{
    public class SfxrSoundData : ISoundData
    {
        private SfxrSynth _synth;

        public string name { get; set; }

        public SfxrSoundData(string name)
        {
            this.name = name;
            _synth = new SfxrSynth();
        }

        public void CacheSound()
        {
            _synth.CacheSound();
        }

        public void Mutate(float value = 0.05F)
        {
            throw new System.NotImplementedException();
        }

        public void Play(float frequency = 0.1266F)
        {
            _synth.parameters.startFrequency = frequency;
            _synth.Play();
        }

        public string ReadSettings()
        {
            throw new System.NotImplementedException();
        }

        public void Stop()
        {
            _synth.Stop();
        }

        public void UpdateSettings(string param)
        {
            _synth.parameters.SetSettingsString(param);
        }
    }
}