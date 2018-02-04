using Microsoft.Xna.Framework.Graphics;
using PixelVisionRunner;

namespace MonoGameRunner
{
    class TextureFactory : ITextureFactory
    {
        private GraphicsDevice graphicsDevice;

        public TextureFactory(GraphicsDevice graphicsDevice)
        {
            this.graphicsDevice = graphicsDevice;
        }

        public ITexture2D NewTexture2D(int width, int height)
        {
            return new Texture2DAdapter(new Texture2D(this.graphicsDevice, width, height));
        }
    }
}
