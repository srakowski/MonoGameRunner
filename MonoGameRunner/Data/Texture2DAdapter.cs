using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PixelVisionRunner;
using System;
using System.IO;
using System.Linq;
using PixelVisionSDK;

namespace MonoGameRunner.Data
{
    class Texture2DAdapter : ITexture2D
    {
        private Texture2D texture;

        public int width { get { return texture.Width; } }

        public int height { get { return texture.Height; } }

        public Texture2DAdapter(Texture2D texture)
        {
            this.texture = texture;
        }

        public IColor GetPixel(int x, int y)
        {
            return this.GetPixels(x, y, 1, 1)[0];
        }

        public IColor[] GetPixels()
        {
            var data = new Color[texture.Width * texture.Height];
            texture.GetData(data);
            return data
                .Select(c => new ColorAdapter(c) as IColor)
                .ToArray();
        }

        public IColor[] GetPixels(int x, int y, int width, int height)
        {
            var data = new Color[width * height];
            texture.GetData(0, new Rectangle(x, y, width, height), data, 0, data.Length);
            return data.Select(c => new ColorAdapter(c) as IColor).ToArray();
        }

        public void LoadImage(byte[] data)
        {
            var graphicsDevice = texture.GraphicsDevice;
            if (!texture.IsDisposed) texture.Dispose();
            using (var stream = new MemoryStream(data))
            {
                texture = Texture2D.FromStream(graphicsDevice, stream);
                //FlipTexture();
            }
        }

        public void UsePointFiltering()
        {
            // set filter point if this was Unity
        }

        public void Resize(int width, int height)
        {
            throw new NotImplementedException();
        }

        public void SetPixels(int x, int y, int width, int height, IColor[] pixelData)
        {
            throw new NotImplementedException();
        }

        public void SetPixels(IColor[] colorData)
        {
            throw new NotImplementedException();
        }

        public byte[] EncodeToPNG()
        {
            throw new NotImplementedException();
        }

        public void LoadTextureData(TextureData textureData, ColorData[] colors, string transColor = "#ff00ff")
        {
            throw new NotImplementedException();
        }

        public void Apply()
        {
            throw new NotImplementedException();
        }
    }
}
