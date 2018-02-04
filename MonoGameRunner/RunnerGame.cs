﻿using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PixelVisionRunner;
using System;

namespace MonoGameRunner
{
    public class RunnerGame : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private Runner runner;
        private IDisplayTarget displayTarget;
        private ITextureFactory textureFactory;
        private IColorFactory colorFactory;

        public RunnerGame()
        {
            graphics = new GraphicsDeviceManager(this);
            IsMouseVisible = false;
            Window.AllowUserResizing = true;
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            base.Initialize();

            displayTarget = new DisplayTarget(Window, graphics);
            textureFactory = new TextureFactory(this.GraphicsDevice);
            colorFactory = new ColorFactory();
            spriteBatch = new SpriteBatch(GraphicsDevice);

            runner = new Runner(OpenPV8File, displayTarget, textureFactory, colorFactory);

            runner.Initialize();
        }

        protected override void Update(GameTime gameTime)
        {
            runner.Update((float)gameTime.ElapsedGameTime.TotalSeconds);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            runner.Draw();
        }

        private void OpenPV8File(Action<Stream> resolve)
        {
            //resolve(File.OpenRead("./Content/SpriteStressDemo.pv8"));
            resolve(File.OpenRead("./Content/UIFrameworkDemo.pv8"));
            // resolve(File.OpenRead("./Content/SampleLuaGame.pv8"));
            // resolve(File.OpenRead("./Content/MicroPlatformer.pv8"));
        }
    }
}