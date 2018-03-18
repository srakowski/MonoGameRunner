using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGameRunner.Runners;
using MonoGameRunner.Util;
using PixelVisionRunner;
using System.Linq;

namespace MonoGameRunner.Data
{
    class DisplayTarget : IDisplayTarget
    {
        private EngineReference engineRef;

        private GraphicsDeviceManager graphics;

        private Texture2D renderTexture;

        private SpriteBatch spriteBatch;

        public ViewportAdapter ViewportAdapter { get; private set; }

        public DisplayTarget(EngineReference engineRef, GameWindow window, GraphicsDeviceManager graphics)
        {
            this.engineRef = engineRef;
            this.graphics = graphics;
            this.spriteBatch = new SpriteBatch(graphics.GraphicsDevice);
            this.ViewportAdapter = new ViewportAdapter(window, graphics.GraphicsDevice, 256, 240);
        }

        public void ResetResolution(int width, int height)
        {
            renderTexture = new Texture2D(graphics.GraphicsDevice, width, height);
            ViewportAdapter.VirtualWidth = width;
            ViewportAdapter.VirtualHeight = height;
            ViewportAdapter.Reset();
        }

        public void Render()
        {
            if (!engineRef.HasEngine) return;
            var engine = engineRef.Engine;

            var pixelMap = engine.displayChip.pixels;

            var colors = engine.colorChip.colors;

            var backgroundColor = engine.colorChip.backgroundColor;

            var pixelColors = pixelMap.Select(p =>
                (p < 0 || p >= colors.Length)
                    ? colors[backgroundColor]
                    : colors[p]
                )
                .Select(c => new Color(c.r, c.g, c.b))
                .ToArray();

            Render(pixelColors);
        }

        public void CacheColors()
        {
            if (!engineRef.HasEngine) return;
            // TODO:
        }

        private void Render(Color[] pixels)
        {
            renderTexture.SetData(pixels);
            spriteBatch.Begin(samplerState: SamplerState.PointClamp, transformMatrix: ViewportAdapter.GetScaleMatrix());
            spriteBatch.Draw(renderTexture, Vector2.Zero, null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.FlipVertically, 1f);
            spriteBatch.End();
        }
    }
}
