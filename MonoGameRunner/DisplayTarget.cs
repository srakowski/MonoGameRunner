using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PixelVisionRunner;
using System.Linq;

namespace MonoGameRunner
{
    class DisplayTarget : IDisplayTarget
    {
        private GraphicsDeviceManager graphics;

        private Texture2D renderTexture;

        private SpriteBatch spriteBatch;

        private ViewportAdapter viewportAdapter;

        public DisplayTarget(GameWindow window, GraphicsDeviceManager graphics)
        {
            this.graphics = graphics;
            this.spriteBatch = new SpriteBatch(graphics.GraphicsDevice);
            this.viewportAdapter = new ViewportAdapter(window, graphics.GraphicsDevice, 256, 240);
        }

        public void ResetResolution(int width, int height, bool fullScreen)
        {
            renderTexture = new Texture2D(graphics.GraphicsDevice, width, height);

            viewportAdapter.VirtualWidth = width;
            viewportAdapter.VirtualHeight = height;
            viewportAdapter.Reset();

            graphics.IsFullScreen = fullScreen;
            graphics.ApplyChanges();

            // Now it's time to resize our cahcedPixels array. We calculate the total number of pixels by multiplying the width by the 
            // height. We'll use this array to make sure we have enough pixels to correctly render the DisplayChip's own pixel data.
            //var totalPixels = width * height;
            //Array.Resize(ref cachedPixels, totalPixels);

            // The last this we need to do is make sure that all of the cachedPixels are not transparent. Since Pixel Vision 8 doesn't 
            // support transparency it's important to make sure we can modify these colors before attempting to render the DisplayChip's pixel data.
            //for (var i = 0; i < totalPixels; i++)
            //{
            //    cachedPixels[i].A = 255;
            //}
        }

        public void Render(IColor[] pixels)
        {
            renderTexture.SetData(pixels.Select(p => new Color(p.r, p.g, p.b)).ToArray());

            spriteBatch.Begin(samplerState: SamplerState.PointClamp, transformMatrix: viewportAdapter.GetScaleMatrix());
            spriteBatch.Draw(renderTexture, Vector2.Zero, null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.FlipVertically, 1f);
            spriteBatch.End();
        }
    }
}
