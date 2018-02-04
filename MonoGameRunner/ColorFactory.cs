using Microsoft.Xna.Framework;
using PixelVisionRunner;
using System.Linq;

namespace MonoGameRunner
{
    class ColorFactory : IColorFactory
    {
        public IColor magenta => new ColorAdapter(Color.Magenta);

        public IColor clear => new ColorAdapter(Color.Transparent);

        public IColor Create(float r, float g, float b)
        {
            return new ColorAdapter(new Color(r, g, b));
        }

        public IColor[] CreateArray(int length)
        {
            return new ColorAdapter[length].Cast<IColor>().ToArray();
        }
    }
}
