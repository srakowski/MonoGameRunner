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

using PixelVisionRunner;
using PixelVisionRunner.Chips;
using PixelVisionRunner.Services;
using PixelVisionSDK;
using PixelVisionSDK.Chips;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;

namespace MonoGameRunner.Runners
{
    public class RunnerWrapper
    {
        private string filePath;

        private EngineReference engineRef;

        private IDisplayTarget displayTarget;

        private IInputFactory inputFactory;

        private Runner runner;

        public RunnerWrapper(
            string filePath,
            EngineReference engineRef,
            IDisplayTarget displayTarget,
            ITextureFactory textureFactory,
            IInputFactory inputFactory)
        {
            this.filePath = filePath;
            this.engineRef = engineRef;
            this.displayTarget = displayTarget;
            this.inputFactory = inputFactory;
            this.runner = new Runner(textureFactory);
        }

        public void Initialize(IEnumerable<string> addOnChips = null)
        {
            var chips = new[]
            {
                typeof(ColorChip).FullName,
                typeof(SpriteChip).FullName,
                typeof(TilemapChip).FullName,
                typeof(FontChip).FullName,
                typeof(ControllerChip).FullName,
                typeof(DisplayChip).FullName,
                typeof(ControllerChip).FullName,
                typeof(LuaGameChip).FullName,
                typeof(MusicChip).FullName,
                typeof(SfxrSoundChip).FullName,
            };

            if (addOnChips != null)
                chips.Concat(addOnChips);

            engineRef.Engine = new PixelVisionEngine(displayTarget, inputFactory, chips);
            engineRef.Engine.chipManager.AddService(typeof(LuaService).FullName, new LuaService());
            LoadGame();
            runner.ActivateEngine(engineRef.Engine);
        }

        public void Update(float delta)
        {
            runner.Update(delta);
        }

        public void Draw()
        {
            runner.Draw();
        }

        private void LoadGame()
        {
            using (var file = File.OpenRead(filePath))
            {
                runner.ProcessFiles(engineRef.Engine, ExtractZipFromMemoryStream(file));
            }
        }

        private static Dictionary<string, byte[]> ExtractZipFromMemoryStream(Stream stream)
        {
            var zip = ZipStorer.Open(stream, FileAccess.Read);

            var dir = zip.ReadCentralDir();

            var files = new Dictionary<string, byte[]>();

            // Look for the desired file
            foreach (var entry in dir)
            {
                var fileBytes = new byte[0];
                zip.ExtractFile(entry, out fileBytes);

                files.Add(entry.ToString(), fileBytes);
            }

            zip.Close();

            return files;
        }
    }
}