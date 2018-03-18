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
using System.Collections.Generic;
using System.IO;
using System.Linq;
using PixelVisionRunner.Utils;
using PixelVisionRunner;
using PixelVisionRunner.Services;
using System.IO.Compression;
using PixelVisionRunner.Chips;

namespace MonoGameRunner.Runners
{
    public class RunnerWrapper
    {
        private EngineReference engineRef;

        private SimplePromise<Stream> openPv8;

        private IDisplayTarget displayTarget;

        private IInputFactory inputFactory;

        private Runner runner;

        public RunnerWrapper(
            EngineReference engineRef,
            SimplePromise<Stream> openPv8,
            IDisplayTarget displayTarget,
            ITextureFactory textureFactory,
            IInputFactory inputFactory)
        {
            this.engineRef = engineRef;
            this.openPv8 = openPv8;
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
            };

            if (addOnChips != null)
                chips.Concat(addOnChips);

            engineRef.Engine = new PixelVisionEngine(displayTarget, inputFactory, chips);
            engineRef.Engine.chipManager.AddService(typeof(LuaService).FullName, new LuaService());

            openPv8
                .Then(LoadGame)
                .Execute();
        }

        public void Update(float delta)
        {
            runner.Update(delta);
        }

        public void Draw()
        {
            runner.Draw();
        }

        private Unit LoadGame(Stream gameContent)
        {
            runner.ProcessFiles(engineRef.Engine, ExtractZipFromMemoryStream(gameContent));
            return Unit.Value;
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