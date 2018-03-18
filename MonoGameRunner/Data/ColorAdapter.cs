using Microsoft.Xna.Framework;
using PixelVisionRunner;

namespace MonoGameRunner.Data
{
    struct ColorAdapter : IColor
    {
        // x, y, z, w -> r, g, b, a

        private Color color;

        public float a
        {
            get { return color.ToVector4().W; }
            set { color = new Color(r, g, b, value); }
        }

        public float r
        {
            get { return color.ToVector4().X; }
            set { color = new Color(value, g, b, a); }
        }

        public float g
        {
            get { return color.ToVector4().Y; }
            set { color = new Color(r, value, b, a); }
        }

        public float b
        {
            get { return color.ToVector4().Z; }
            set { color = new Color(r, g, value, a); }
        }

        public ColorAdapter(Color color)
        {
            this.color = color;
        }
    }
}
