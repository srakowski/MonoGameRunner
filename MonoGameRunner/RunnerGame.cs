using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGameRunner.Data;
using MonoGameRunner.Input;
using MonoGameRunner.Runners;
using PixelVisionRunner;
using PixelVisionRunner.Chips.Sfxr;

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
            SfxrSynth.AudioPlayerFactory = new Audio.AudioPlayerFactory();

            base.Initialize();

            engineRef = new EngineReference();
            displayTarget = new DisplayTarget(engineRef, Window, graphics);
            textureFactory = new TextureFactory(this.GraphicsDevice);
            spriteBatch = new SpriteBatch(GraphicsDevice);
            inputFactory = new InputFactory(displayTarget);

            runner = new RunnerWrapper("./Content/MusicDemo.pv8", engineRef, displayTarget, textureFactory, inputFactory);

            runner.Initialize();

            // forces viewport adapter to refresh position/scaling
            graphics.PreferredBackBufferWidth = graphics.PreferredBackBufferWidth;
            graphics.PreferredBackBufferHeight = graphics.PreferredBackBufferHeight;
            graphics.ApplyChanges();
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
    }
}
