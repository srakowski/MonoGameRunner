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

using PixelVisionSDK;

namespace PixelVisionRunner.Data
{

    public class SfxrSoundData : ISoundData
    {
        public string name { get; set; }

        public SfxrSoundData(string name = "Untitled")
        {
            this.name = name;
            //synth = new SfxrSynth();
        }

        public void CacheSound()
        {
        }

        public void Mutate(float value = 0.05F)
        {
        }

        public void Play(float frequency = 0.1266F)
        {
        }

        public string ReadSettings()
        {
            return string.Empty;
        }

        public void Stop()
        {
        }

        public void UpdateSettings(string param)
        {
        }

        //protected SfxrSynth synth;

        //public SfxrSoundData(string name = "Untitled")
        //{
        //    this.name = name;
        //    synth = new SfxrSynth();
        //}

        //public SfxrParams parameters
        //{
        //    get { return synth.parameters; }
        //}

        //public bool ignore { get; private set; }

        //public string name { get; set; }

        ///// <summary>
        /////     Plays the sound at a specific frequency.
        ///// </summary>
        ///// <param name="frequency"></param>
        //public void Play(float frequency = 0.1266f)
        //{
        //    synth.parameters.startFrequency = frequency;
        //    synth.Play();
        //}

        ///// <summary>
        /////     Stops the current sound from playing
        ///// </summary>
        //public void Stop()
        //{
        //    synth.Stop();
        //}

        ///// <summary>
        /////     Caches the sound file to improve performance
        ///// </summary>
        //public void CacheSound()
        //{
        //    synth.CacheSound();
        //}

        //public void UpdateSettings(string param)
        //{

        //    synth.parameters.SetSettingsString(param);
        //    CacheSound();
        //}

        //public string ReadSettings()
        //{
        //    return synth.parameters.GetSettingsString();
        //}

        //public void Mutate(float value = 0.05f)
        //{
        //    synth.parameters.Mutate(value);
        //}

    }

}