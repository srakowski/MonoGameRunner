using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PixelVisionRunner;
using System;
using MonoGameRunner.Input;
using MonoGameRunner.Data;
using MonoGameRunner.Runners;

namespace MonoGameRunner
{
    public class RunnerGame : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private EngineReference engineRef;
        private RunnerWrapper runner;
        private DisplayTarget displayTarget;
        private ITextureFactory textureFactory;
        private InputFactory inputFactory;

        public RunnerGame()
        {
            graphics = new GraphicsDeviceManager(this);
            IsMouseVisible = false;
            Window.AllowUserResizing = true;
            Window.TextInput += InputStates.InputStates_TextInput;
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            base.Initialize();

            engineRef = new EngineReference();
            displayTarget = new DisplayTarget(engineRef, Window, graphics);
            textureFactory = new TextureFactory(this.GraphicsDevice);
            spriteBatch = new SpriteBatch(GraphicsDevice);
            inputFactory = new InputFactory(displayTarget);

            runner = new RunnerWrapper(engineRef, OpenPV8File, displayTarget, textureFactory, inputFactory);

            runner.Initialize();
        }

        protected override void Update(GameTime gameTime)
        {
            InputStates.Update();
            runner.Update((float)gameTime.ElapsedGameTime.TotalSeconds);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            runner.Draw();
        }

        private void OpenPV8File(Action<Stream> resolve)
        {
            // resolve(File.OpenRead("./Content/SpriteStressDemo.pv8"));
            // resolve(File.OpenRead("./Content/UIFrameworkDemo.pv8"));
            resolve(File.OpenRead("./Content/SampleLuaGame.pv8"));
            //resolve(File.OpenRead("./Content/MicroPlatformer.pv8"));
        }
    }
}
